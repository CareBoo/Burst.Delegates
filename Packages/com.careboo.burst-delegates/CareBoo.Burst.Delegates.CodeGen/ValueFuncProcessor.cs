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
            @"ValueFunc`(?<NumGenericParams>[1-9]).Lambda<(?<GenericParams>[\w.<>,]+)>$",
            RegexOptions.Compiled
        );

        public readonly static Regex StructRegex = new Regex(
            @"ValueFunc`(?<NumGenericParams>[1-9]).Struct`1<(?<GenericParams>[\w.<>,]+),[\w.<>]+>$",
            RegexOptions.Compiled
        );

        public static IEnumerable<MethodDefinition> GetMethods(TypeDefinition typeDefinition, Func<MethodDefinition, bool> predicate)
        {
            return typeDefinition.Methods.Where(predicate);
        }

        public static IEnumerable<MethodDefinition> GetMethods(ModuleDefinition moduleDefinition, Func<MethodDefinition, bool> predicate)
        {
            return moduleDefinition.Types.SelectMany(td => GetMethods(td, predicate));
        }

        public static IEnumerable<MethodDefinition> GetMethods(AssemblyDefinition assemblyDefinition, Func<MethodDefinition, bool> predicate)
        {
            return assemblyDefinition.Modules.SelectMany(md => GetMethods(md, predicate));
        }

        public static bool IsMethodWithValueFuncLambdas(MethodReference md)
        {
            return md.HasParameters
                && md.Parameters.Select(p => p.ParameterType.FullName).Any(LambdaRegex.IsMatch);
        }

        public static bool IsMethodWithValueFuncStructs(MethodReference md)
        {
            return md.HasParameters
                && md.Parameters.Select(p => p.ParameterType.FullName).Any(StructRegex.IsMatch);
        }
    }
}
