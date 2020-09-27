using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public struct ValueFuncTypeDefinition
    {
        readonly TypeDefinition typeDefinition;

        public List<ValueFuncMethodPair> ValueFuncMethods { get; private set; }

        public ValueFuncTypeDefinition(TypeDefinition typeDefinition)
        {
            this.typeDefinition = typeDefinition;
            ValueFuncMethods = GetValueFuncMethods(typeDefinition);
        }

        private static List<ValueFuncMethodPair> GetValueFuncMethods(TypeDefinition typeDefinition)
        {
            var valueFuncMethods = new List<ValueFuncMethodPair>();
            if (!typeDefinition.HasMethods)
                return valueFuncMethods;

            var lambdaMethods = new Dictionary<ValueFuncMethodProperties, MethodDefinition>();
            var structMethods = new Dictionary<ValueFuncMethodProperties, MethodDefinition>();

            foreach (var method in typeDefinition.Methods)
            {
                if (!method.HasParameters)
                    continue;

                if (IsMethodWithValueFuncLambdas(method))
                    lambdaMethods.Add(new ValueFuncMethodProperties(method), method);
                else if (IsMethodWithValueFuncStructs(method))
                    structMethods.Add(new ValueFuncMethodProperties(method), method);
            }

            foreach (var lambda in lambdaMethods)
            {
                var structKey = ValueFuncMethodProperties.ReplaceValueFuncLambdasWithStructs(lambda.Key);
                var structMethod = structMethods[structKey];
                valueFuncMethods.Add(new ValueFuncMethodPair(lambda.Value, structMethod));
            }
            return valueFuncMethods;
        }

        public static implicit operator ValueFuncTypeDefinition(TypeDefinition typeDefinition)
        {
            return new ValueFuncTypeDefinition(typeDefinition);
        }

        public static implicit operator TypeDefinition(ValueFuncTypeDefinition valueFuncTypeDefinition)
        {
            return valueFuncTypeDefinition.typeDefinition;
        }

        private static bool IsMethodWithValueFuncLambdas(MethodDefinition method)
        {
            return IsMethodWithParametersMatchingRegex(method, ValueFuncMethodProperties.LambdaRegex);
        }

        private static bool IsMethodWithValueFuncStructs(MethodDefinition method)
        {
            return IsMethodWithParametersMatchingRegex(method, ValueFuncMethodProperties.StructRegex);
        }

        private static bool IsMethodWithParametersMatchingRegex(MethodDefinition method, Regex regex)
        {
            if (!method.HasParameters)
                return false;

            var parameterTypeNames = method.Parameters.Select(p => p.ParameterType.FullName);
            return parameterTypeNames.Any(name => regex.IsMatch(name));
        }
    }
}
