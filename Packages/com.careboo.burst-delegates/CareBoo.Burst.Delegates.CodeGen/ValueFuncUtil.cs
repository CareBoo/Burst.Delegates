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

        public static IEnumerable<MethodDefinition> GetMethods(TypeDefinition typeDefinition)
        {
            return typeDefinition.Methods;
        }

        public static IEnumerable<MethodDefinition> GetMethods(ModuleDefinition moduleDefinition)
        {
            return moduleDefinition.Types.SelectMany(td => GetMethods(td));
        }

        public static IEnumerable<MethodDefinition> GetMethods(AssemblyDefinition assemblyDefinition)
        {
            return assemblyDefinition.Modules.SelectMany(md => GetMethods(md));
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

        public static void ConvertToValueFuncStructMethod(MethodReference lambdaMethod)
        {
            var lambdaParameters = lambdaMethod.Parameters.Where(p => LambdaRegex.IsMatch(p.ParameterType.FullName));
        }

        public static void ConvertToValueFuncStructParameter(ParameterDefinition lambdaParameter)
        {

        }
    }
}
