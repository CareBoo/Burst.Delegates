using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using UnityEngine;
using static CareBoo.Burst.Delegates.CodeGen.ValueFuncUtil;


namespace CareBoo.Burst.Delegates.CodeGen
{
    public partial class BurstDelegatePostProcessor
    {
        public void Process(TypeDefinition type)
        {
            var methodsToProcess = type.Methods
                .Where(IsCallingMethodWhere(IsMethodWithValueFuncLambdas))
                .ToArray();
            if (methodsToProcess.Length == 0) return;

            var displayStruct = CreateDisplayStruct(type);
            type.NestedTypes.Add(displayStruct);
        }

        private TypeDefinition CreateDisplayStruct(TypeDefinition type)
        {
            var displayClass = type.NestedTypes.First(t => t.Name == "<>c");
            var displayStruct = new TypeDefinition(
                @namespace: displayClass.Namespace,
                "<>s",
                TypeAttributes.NestedPrivate,
                type.Module.ImportReference(typeof(System.ValueType))
                );
            foreach (var field in displayClass.Fields)
                displayStruct.Fields.Add(field);
            return displayStruct;
        }

        private TypeDefinition CreateLambdaStruct(TypeDefinition type, MethodDefinition method)
        {
            var funcStruct = new TypeDefinition(
                @namespace: type.Namespace,
                method.Name,
                TypeAttributes.NestedPrivate,
                type.Module.ImportReference(typeof(System.ValueType))
                );
            var iFunc = GetIFuncForMethod(method);

            var funcMethod = new MethodDefinition(
                method.Name,
                MethodAttributes.Private,
                method.ReturnType)
            {
                DeclaringType = funcStruct,
                HasThis = method.HasThis,
                ExplicitThis = method.ExplicitThis,
                CallingConvention = method.CallingConvention
            };
            var funcInterface = new InterfaceImplementation(iFunc);
            return funcStruct;
        }

        private Type GetOpenIFuncForMethod(MethodDefinition method)
        {
            switch (method.Parameters.Count())
            {
                case 0: return typeof(IFunc<>);
                case 1: return typeof(IFunc<,>);
                case 2: return typeof(IFunc<,,>);
                case 3: return typeof(IFunc<,,,>);
                default:
                    throw new ArgumentOutOfRangeException("method.Parameters.Count()");
            }
        }

        private GenericInstanceType GetIFuncForMethod(MethodDefinition method)
        {
            var openIFunc = method.Module.ImportReference(GetOpenIFuncForMethod(method));
            var iFunc = new GenericInstanceType(openIFunc);
            foreach (var parameterType in method.Parameters.Select(p => p.ParameterType))
                iFunc.GenericArguments.Add(parameterType);
            iFunc.GenericArguments.Add(method.ReturnType);
            return iFunc;
        }


    }
}
