using System.Linq;
using System.Reflection;
using Mono.Cecil;

namespace CareBoo.Burst.Delegates.CodeGen.PostProcessing
{
    internal class ReflectionImporterProvider : IReflectionImporterProvider
    {
        public IReflectionImporter GetReflectionImporter(ModuleDefinition module)
        {
            return new ReflectionImporter(module);
        }
    }

    internal class ReflectionImporter : DefaultReflectionImporter
    {
        private const string SystemPrivateCoreLib = "System.Private.CoreLib";
        private AssemblyNameReference _correctCorlib;

        public ReflectionImporter(ModuleDefinition module) : base(module)
        {
            _correctCorlib = module.AssemblyReferences.FirstOrDefault(a => a.Name == "mscorlib" || a.Name == "netstandard" || a.Name == SystemPrivateCoreLib);
        }

        public override AssemblyNameReference ImportReference(AssemblyName reference)
        {
            if (_correctCorlib != null && reference.Name == SystemPrivateCoreLib)
                return _correctCorlib;

            return base.ImportReference(reference);
        }
    }
}
