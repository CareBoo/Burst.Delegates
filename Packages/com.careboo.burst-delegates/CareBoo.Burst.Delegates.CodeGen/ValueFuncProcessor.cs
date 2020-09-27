using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public class ValueFuncProcessor
    {
        public readonly static Regex LambdaRegex = new Regex(
            @"ValueFunc`(?<NumGenericParams>[1-9]).Lambda<(?<GenericParams>[\w,]+)>$",
            RegexOptions.Compiled
        );

        public readonly static Regex StructRegex = new Regex(
            @"ValueFunc`(?<NumGenericParams>[1-9]).Struct`1<(?<GenericParams>(\w+,)+)\w+>$",
            RegexOptions.Compiled
        );

        public static IEnumerable<MethodDefinition> GetAllMethods(TypeDefinition typeDefinition, Func<MethodDefinition, bool> predicate)
        {
            return typeDefinition.Methods.Where(predicate);
        }

        public static IEnumerable<MethodDefinition> GetAllMethods(ModuleDefinition moduleDefinition, Func<MethodDefinition, bool> predicate)
        {
            return moduleDefinition.Types.SelectMany(td => GetAllMethods(td, predicate));
        }

        public static IEnumerable<MethodDefinition> GetAllMethods(AssemblyDefinition assemblyDefinition, Func<MethodDefinition, bool> predicate)
        {
            return assemblyDefinition.Modules.SelectMany(md => GetAllMethods(md, predicate));
        }

        public static bool IsMethodWithValueFuncLambdas(MethodDefinition md)
        {
            return md.HasParameters
                && md.Parameters.Select(p => p.ParameterType.FullName).Any(LambdaRegex.IsMatch);
        }

        public static bool IsMethodWithValueFuncStructs(MethodDefinition md)
        {
            return md.HasParameters
                && md.Parameters.Select(p => p.ParameterType.FullName).Any(StructRegex.IsMatch);
        }
    }
}
