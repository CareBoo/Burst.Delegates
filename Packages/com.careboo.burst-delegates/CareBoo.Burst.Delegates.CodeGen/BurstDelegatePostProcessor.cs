using System.IO;
using System.Linq;
using System.Collections.Generic;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using Mono.Cecil;
using Mono.Cecil.Cil;
using static CareBoo.Burst.Delegates.CodeGen.ValueFuncUtil;
using System.Text;
using System;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public partial class BurstDelegatePostProcessor : ILPostProcessor
    {
        public override ILPostProcessor GetInstance()
        {
            return this;
        }

        public override ILPostProcessResult Process(ICompiledAssembly compiledAssembly)
        {
            if (!WillProcess(compiledAssembly)) return null;

            var diagnostics = new List<DiagnosticMessage>();
            var messageBuilder = new StringBuilder();

            messageBuilder.AppendLine($"[{GetType().Name}]: post processing {compiledAssembly.Name}");
            var assemblyDefinition = AssemblyDefinitionFor(compiledAssembly);

            var methodsCallingLambda = GetMethods(assemblyDefinition).Where(IsCallingMethodWhere(IsMethodWithValueFuncLambdas));
            messageBuilder.AppendLine($"Found methods calling valuefunc delegates:\n{string.Join("\n\n", methodsCallingLambda.Select(m => string.Join("\n", m.Body.Instructions)))}");
            foreach (var type in methodsCallingLambda.First().DeclaringType.NestedTypes)
            {
                type.BaseType = assemblyDefinition.MainModule.ImportReference(typeof(ValueType));
                messageBuilder.AppendLine($"Nested {(type.IsValueType ? "struct" : "class")}: {type}");
            }

            diagnostics.Add(new DiagnosticMessage { MessageData = messageBuilder.ToString(), DiagnosticType = DiagnosticType.Warning });
            return new ILPostProcessResult(null, diagnostics);
        }

        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            return compiledAssembly.References.Any(f => Path.GetFileName(f) == "CareBoo.Burst.Delegates.dll") &&
                !compiledAssembly.Name.Contains("CodeGen.Tests");
        }

        internal static AssemblyDefinition AssemblyDefinitionFor(ICompiledAssembly compiledAssembly)
        {
            var resolver = new PostProcessing.AssemblyResolver(compiledAssembly);
            var readerParameters = new ReaderParameters
            {
                SymbolStream = new MemoryStream(compiledAssembly.InMemoryAssembly.PdbData.ToArray()),
                SymbolReaderProvider = new PortablePdbReaderProvider(),
                AssemblyResolver = resolver,
                ReflectionImporterProvider = new PostProcessing.ReflectionImporterProvider(),
                ReadingMode = ReadingMode.Immediate
            };

            var peStream = new MemoryStream(compiledAssembly.InMemoryAssembly.PeData.ToArray());
            var assemblyDefinition = AssemblyDefinition.ReadAssembly(peStream, readerParameters);

            //apparently, it will happen that when we ask to resolve a type that lives inside Unity.Entities, and we
            //are also postprocessing Unity.Entities, type resolving will fail, because we do not actually try to resolve
            //inside the assembly we are processing. Let's make sure we do that, so that we can use postprocessor features inside
            //unity.entities itself as well.
            resolver.AddAssemblyDefinitionBeingOperatedOn(assemblyDefinition);

            return assemblyDefinition;
        }
    }
}
