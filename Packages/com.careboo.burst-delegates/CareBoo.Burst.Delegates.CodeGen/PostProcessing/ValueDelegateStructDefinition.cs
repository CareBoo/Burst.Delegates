using System;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public class ValueDelegateStructDefinition
    {
        private readonly TypeDefinition displayStruct;
        private readonly MethodDefinition lambdaMethod;

        public TypeDefinition Definition { get; }
        public FieldDefinition ClosureField { get; }
        public MethodDefinition InvokeMethod { get; }
        public InterfaceImplementation DelegateInterface { get; }

        public ValueDelegateStructDefinition(TypeDefinition displayStruct, MethodDefinition lambdaMethod)
        {
            this.displayStruct = displayStruct;
            this.lambdaMethod = lambdaMethod;

            Definition = InitDefinition();
            ClosureField = InitClosureField();
            InvokeMethod = InitInvokeMethod();
            DelegateInterface = InitDelegateInterface();

            Definition.Fields.Add(ClosureField);
            Definition.Methods.Add(InvokeMethod);
            Definition.Interfaces.Add(DelegateInterface);
        }

        TypeDefinition InitDefinition()
        {
            return new TypeDefinition(
                @namespace: displayStruct.Namespace,
                name: "<>c__" + lambdaMethod.Name,
                attributes: displayStruct.Attributes,
                displayStruct.Module.ImportReference(typeof(ValueType))
                );
        }

        FieldDefinition InitClosureField()
        {
            return new FieldDefinition(
                name: "closure",
                attributes: FieldAttributes.Private,
                fieldType: displayStruct
                );
        }

        MethodDefinition InitInvokeMethod()
        {
            var invokeMethod = new MethodDefinition(
                name: "Invoke",
                attributes: MethodAttributes.Public,
                returnType: lambdaMethod.ReturnType
                );
            foreach (var parameter in lambdaMethod.Parameters)
                invokeMethod.Parameters.Add(parameter);
            foreach (var genericParameter in lambdaMethod.GenericParameters)
                invokeMethod.GenericParameters.Add(genericParameter);
            invokeMethod.Body = new MethodBody(lambdaMethod);
            foreach (var instruction in invokeMethod.Body.Instructions)
                if (IsReferencingClosureField(instruction))
                    FixClosureFieldReference(instruction);
            return invokeMethod;
        }

        InterfaceImplementation InitDelegateInterface()
        {
            return new InterfaceImplementation(InitDelegateInterfaceTypeReference());
        }

        TypeReference InitDelegateInterfaceTypeReference()
        {
            var voidType = Definition.Module.ImportReference(typeof(void));
            var lambdaParameters = lambdaMethod.Parameters;
            var paramCount = lambdaParameters.Count;
            var isAction = lambdaMethod.ReturnType.FullName == voidType.FullName;
            Type type;
            switch (paramCount)
            {
                case 0:
                    type = isAction ? typeof(IAction) : typeof(IFunc<>); break;
                case 1:
                    type = isAction ? typeof(IAction<>) : typeof(IFunc<,>); break;
                case 2:
                    type = isAction ? typeof(IAction<,>) : typeof(IFunc<,,>); break;
                case 3:
                    type = isAction ? typeof(IAction<,,>) : typeof(IFunc<,,,>); break;
                default:
                    throw new NotSupportedException("methods with over 3 parameters are not supported");
            }
            var typeRef = Definition.Module.ImportReference(type);
            if (isAction && paramCount == 0)
                return typeRef;

            var genericTypeRef = new GenericInstanceType(typeRef);
            foreach (var parameter in lambdaParameters)
                genericTypeRef.GenericArguments.Add(parameter.ParameterType);
            if (!isAction)
                genericTypeRef.GenericArguments.Add(lambdaMethod.ReturnType);
            return genericTypeRef;
        }

        bool IsReferencingClosureField(Instruction instruction)
        {
            return false;
        }

        void FixClosureFieldReference(Instruction instruction)
        {
            throw new NotImplementedException();
        }
    }
}