using System;
using System.Linq;
using Mono.Cecil;
using static CareBoo.Burst.Delegates.CodeGen.ValueFuncUtil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public struct ValueFuncMethodKey : IEquatable<ValueFuncMethodKey>
    {
        public string Key { get; private set; }

        private ValueFuncMethodKey(string key)
        {
            Key = key;
        }

        public ValueFuncMethodKey(MethodReference methodRef)
        {
            var isLambda = IsMethodWithValueFuncLambdas(methodRef);
            var isStruct = IsMethodWithValueFuncStructs(methodRef);
            if (!isLambda && !isStruct)
            {
                Key = null;
            }

            var name = methodRef.Name;
            var parameterStrings = methodRef.HasParameters
                ? methodRef.Parameters.Select(GetParameterTypeString).ToList()
                : Enumerable.Empty<string>();
            var genericCount = methodRef.HasGenericParameters
                ? methodRef.GenericParameters.Count()
                : 0;
            if (isStruct)
                genericCount -= 1;

            Key = $"{name}{string.Join(string.Empty, parameterStrings)}{genericCount}";
        }

        public override bool Equals(object obj)
        {
            return obj is ValueFuncMethodKey other
                && Key == other.Key;
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Key;
        }

        public static implicit operator string(ValueFuncMethodKey key)
        {
            return key.Key;
        }

        public static implicit operator ValueFuncMethodKey(string key)
        {
            return new ValueFuncMethodKey(key);
        }

        private static string GetParameterTypeString(ParameterDefinition paramDef)
        {
            var typeFullName = paramDef.ParameterType.FullName;
            if (!StructRegex.IsMatch(typeFullName))
                return typeFullName;
            return StructToLambdaTypeFullName(typeFullName);
        }

        private static string StructToLambdaTypeFullName(string typeFullName)
        {
            return StructRegex.Replace(typeFullName, "ValueFunc`${NumGenericParams}/Lambda<${GenericParams}>");
        }

        bool IEquatable<ValueFuncMethodKey>.Equals(ValueFuncMethodKey other)
        {
            return Key == other.Key;
        }
    }
}
