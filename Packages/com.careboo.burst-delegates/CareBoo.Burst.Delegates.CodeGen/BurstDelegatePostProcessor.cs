using System.IO;
using System.Linq;
using System.Collections.Generic;
using Unity.CompilationPipeline.Common.Diagnostics;
using Unity.CompilationPipeline.Common.ILPostProcessing;

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

            var diagnostics = new List<DiagnosticMessage>()
            {
                new DiagnosticMessage { MessageData = $"[{GetType().Name}]: post processing {compiledAssembly.Name}", DiagnosticType = DiagnosticType.Warning }
            };
            return new ILPostProcessResult(null, diagnostics);
        }

        public override bool WillProcess(ICompiledAssembly compiledAssembly)
        {
            return compiledAssembly.References.Any(f => Path.GetFileName(f) == "CareBoo.Burst.Delegates.dll") &&
                !compiledAssembly.Name.Contains("CodeGen.Tests");
        }
    }
}
