using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public static class ValueFuncUtil
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

        public static bool IsMethodWithValueFuncLambdas(MethodReference mref)
        {
            return mref.HasParameters
                && mref.Parameters.Select(p => p.ParameterType.FullName).Any(LambdaRegex.IsMatch);
        }

        public static bool IsMethodWithValueFuncStructs(MethodReference mref)
        {
            return mref.HasParameters
                && mref.Parameters.Select(p => p.ParameterType.FullName).Any(StructRegex.IsMatch);
        }

        public static Func<MethodDefinition, bool> IsCallingMethodWhere(Func<MethodReference, bool> predicate)
        {
            return (caller) =>
            {
                return caller.HasBody
                    && caller.Body.Instructions.Any(instruction =>
                        instruction.OpCode == OpCodes.Call
                        && instruction.Operand is MethodReference methodCalled
                        && predicate(methodCalled));
            };
        }
    }
}
