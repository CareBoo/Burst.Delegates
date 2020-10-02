using System.IO;
using System.Linq;
using System.Collections.Generic;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;
using Mono.Cecil;
using Mono.Cecil.Cil;
using static CareBoo.Burst.Delegates.CodeGen.ValueFuncUtil;
using System.Text;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public class BurstDelegatePostProcessor : ILPostProcessor
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
            var methodPairs = new Dictionary<ValueFuncMethodKey, ValueFuncMethodPair>();

            messageBuilder.AppendLine($"[{GetType().Name}]: post processing {compiledAssembly.Name}");
            var assemblyDefinition = AssemblyDefinitionFor(compiledAssembly);

            var lambdaMethods = GetMethods(assemblyDefinition, IsMethodWithValueFuncLambdas);
            messageBuilder.AppendLine($"Found Lambda Methods:\n{string.Join("\n", lambdaMethods.Select(m => m.FullName))}");

            foreach (var method in lambdaMethods)
            {
                methodPairs.Add(new ValueFuncMethodKey(method), new ValueFuncMethodPair { MethodWithLambdas = method });
            }

            var structMethods = GetMethods(assemblyDefinition, IsMethodWithValueFuncStructs);
            messageBuilder.AppendLine($"Found Struct Methods:\n{string.Join("\n", structMethods.Select(m => m.FullName))}");

            foreach (var method in structMethods)
            {
                var key = new ValueFuncMethodKey(method);
                if (!methodPairs.TryGetValue(key, out var pair))
                {
                    diagnostics.Add(new DiagnosticMessage { MessageData = $"Could not find lambda method with key: \"{key}\"...\nExisting keys:\n{string.Join("\n", methodPairs.Keys.Select(k => $"\"{k}\""))}", DiagnosticType = DiagnosticType.Error });
                    continue;
                }
                pair.MethodWithStructs = method;
                methodPairs[key] = pair;
                messageBuilder.AppendLine($"");
            }
            messageBuilder.AppendLine($"Found ValueFuncMethodPairs:\n{string.Join("\n", methodPairs.Values.Select(pair => $"[\"{pair.MethodWithLambdas}\", \"{pair.MethodWithStructs}\"]"))}");

            var methodsCallingLambda = GetMethods(assemblyDefinition, IsCallingMethodWhere(method => methodPairs.ContainsKey(new ValueFuncMethodKey(method))));
            messageBuilder.AppendLine($"Found methods calling valuefunc delegates:\n{string.Join("\n", methodsCallingLambda)}");

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
