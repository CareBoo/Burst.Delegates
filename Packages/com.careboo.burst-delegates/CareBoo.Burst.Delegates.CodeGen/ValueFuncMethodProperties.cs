using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Mono.Cecil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public struct ValueFuncMethodProperties
    {
        public readonly static Regex LambdaRegex = new Regex(
            @"ValueFunc`(?<NumGenericParams>[1-9]).Lambda<(?<GenericParams>[\w,]+)>$"
        );

        public readonly static Regex StructRegex = new Regex(
            @"ValueFunc`(?<NumGenericParams>[1-9]).Struct`1<(?<GenericParams>(\w+,)+)\w+>$"
        );

        public string Name { get; private set; }
        public List<string> ParameterTypes { get; private set; }
        public int GenericParameterCount { get; private set; }

        public ValueFuncMethodProperties(MethodReference methodRef)
        {
            Name = methodRef.Name;
            ParameterTypes = methodRef.HasParameters
                ? methodRef.Parameters.Select(GetParameterTypeString).ToList()
                : null;
            GenericParameterCount = methodRef.HasGenericParameters
                ? methodRef.GenericParameters.Count()
                : 0;
        }

        public override bool Equals(object obj)
        {
            return obj is ValueFuncMethodProperties other
                && Name == other.Name
                && (ParameterTypes == null || other.ParameterTypes == null
                    ? ParameterTypes == other.ParameterTypes
                    : ParameterTypes.SequenceEqual(other.ParameterTypes))
                && GenericParameterCount == other.GenericParameterCount;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 17;
                hash = hash * 23 + Name.GetHashCode();
                if (ParameterTypes != null)
                {
                    hash *= 37;
                    foreach (var type in ParameterTypes)
                        hash *= 23 + type.GetHashCode();
                }
                hash = hash * 23 + GenericParameterCount;
                return hash;
            }
        }

        public override string ToString()
        {
            var parameterTypesString = ParameterTypes != null && ParameterTypes.Count > 0
                ? string.Join(",", ParameterTypes)
                : "";
            var genericParameterString = string.Concat(Enumerable.Repeat(",", GenericParameterCount - 1));
            return $"{GetType().Name}<{Name}<{genericParameterString}>({parameterTypesString})>";
        }

        public static ValueFuncMethodProperties ReplaceValueFuncLambdasWithStructs(ValueFuncMethodProperties properties)
        {
            if (properties.ParameterTypes == null || properties.ParameterTypes.Count == 0)
                return properties;

            for (var i = 0; i < properties.ParameterTypes.Count; i++)
            {
                var parameterType = properties.ParameterTypes[i];
                if (!LambdaRegex.IsMatch(parameterType))
                    continue;
                properties.ParameterTypes[i] = LambdaRegex.Replace(parameterType, "ValueFunc`${NumGenericParams}.Struct`1<${GenericParams},>");
                properties.GenericParameterCount += 1;
            }
            return properties;
        }

        private static string GetParameterTypeString(ParameterDefinition paramDef)
        {
            var typeFullName = paramDef.ParameterType.FullName;
            if (!StructRegex.IsMatch(typeFullName))
                return typeFullName;
            return OmitStructGenericParameterFromTypeFullName(typeFullName);
        }

        private static string OmitStructGenericParameterFromTypeFullName(string typeFullName)
        {
            return StructRegex.Replace(typeFullName, "ValueFunc`${NumGenericParams}.Struct`1<${GenericParams}>");
        }
    }
}
