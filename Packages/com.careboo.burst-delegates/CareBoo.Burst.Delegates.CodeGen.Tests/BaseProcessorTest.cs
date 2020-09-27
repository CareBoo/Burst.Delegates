using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Mono.Cecil;
using Mono.Cecil.Cil;

internal abstract class BaseProcessorTest
{
    static MemoryStream PdbStreamFor(string assemblyLocation)
    {
        var file = Path.ChangeExtension(assemblyLocation, ".pdb");
        if (!File.Exists(file))
            return null;
        return new MemoryStream(File.ReadAllBytes(file));
    }

    private class OnDemandResolver : IAssemblyResolver
    {
        public void Dispose()
        {
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name)
        {
            return Resolve(name, new ReaderParameters(ReadingMode.Deferred));
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
        {
            var assembly = AppDomain.CurrentDomain.GetAssemblies().First(a => a.GetName().Name == name.Name);
            var fileName = assembly.Location;
            parameters.AssemblyResolver = this;
            parameters.SymbolStream = PdbStreamFor(fileName);
            var bytes = File.ReadAllBytes(fileName);
            return AssemblyDefinition.ReadAssembly(new MemoryStream(bytes), parameters);
        }
    }

    public AssemblyDefinition GetAssemblyForType(Type type)
    {
        var assemblyLocation = type.Assembly.Location;
        var resolver = new OnDemandResolver();
        return AssemblyDefinition.ReadAssembly(assemblyLocation, new ReaderParameters(ReadingMode.Immediate)
        {
            ReadSymbols = true,
            ThrowIfSymbolsAreNotMatching = true,
            SymbolReaderProvider = new PortablePdbReaderProvider(),
            AssemblyResolver = resolver,
            SymbolStream = PdbStreamFor(assemblyLocation)
        });
    }

    public TypeDefinition GetTypeDefinition(Type type)
    {
        var ad = GetAssemblyForType(type);
        var typeReference = ad.MainModule.ImportReference(type);
        return typeReference.Resolve();
    }

    public MethodDefinition GetMethodDefinition(MethodBase method)
    {
        var ad = GetAssemblyForType(method.DeclaringType);
        return ad.MainModule.ImportReference(method).Resolve();
    }

    public MethodDefinition GetMethodDefinition<T>(Expression<Func<T, Delegate>> expression)
    {
        if (expression.Body is MethodCallExpression methodCallExpression)
        {
            return GetMethodDefinition(methodCallExpression.Method);
        }
        return null;
    }

    public MethodDefinition GetMethodDefinition<T>(string methodName, int genericCount)
    {
        var td = GetTypeDefinition(typeof(T));
        return td.Methods.FirstOrDefault(
            m => m.Name == methodName
            && genericCount == m.GenericParameters.Count);
    }

    public MethodDefinition GetMethodDefinition(Delegate d)
    {
        return GetMethodDefinition(d.Method);
    }
}