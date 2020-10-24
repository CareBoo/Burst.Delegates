using System;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public class ValueDelegateStructDefinition
    {
        private readonly TypeDefinition displayStruct;
        private readonly TypeDefinition displayClass;
        private readonly MethodDefinition lambdaMethod;

        public TypeDefinition Definition { get; }
        public FieldDefinition ClosureField { get; }
        public MethodDefinition InvokeMethod { get; }
        public InterfaceImplementation DelegateInterface { get; }
        public ModuleDefinition Module => displayClass.Module;

        public ValueDelegateStructDefinition(TypeDefinition displayStruct, TypeDefinition displayClass, MethodDefinition lambdaMethod)
        {
            this.displayStruct = displayStruct;
            this.displayClass = displayClass;
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
            var @namespace = displayStruct.Namespace;
            var name = "<>c__" + lambdaMethod.Name;
            var attributes = displayStruct.Attributes;
            var structType = displayStruct.BaseType;
            return new TypeDefinition(@namespace, name, attributes, structType);
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
            invokeMethod.Body = new MethodBody(lambdaMethod);
            invokeMethod.Body.Instructions.Clear();
            var processor = invokeMethod.Body.GetILProcessor();
            foreach (var instruction in lambdaMethod.Body.Instructions)
            {
                if (IsReferencingClosureField(instruction))
                    FixClosureFieldReference(instruction, processor);
                else
                    processor.Append(instruction);
            }
            return invokeMethod;
        }

        InterfaceImplementation InitDelegateInterface()
        {
            return new InterfaceImplementation(InitDelegateInterfaceTypeReference());
        }

        bool IsReferencingClosureField(Instruction instruction)
        {
            return instruction.OpCode == OpCodes.Ldfld
                && instruction.Operand is FieldReference fieldReference
                && fieldReference.DeclaringType.FullName == displayClass.FullName;
        }

        void FixClosureFieldReference(Instruction instruction, ILProcessor processor)
        {
            var loadDisplayStructInstruction = processor.Create(OpCodes.Ldflda, ClosureField);
            processor.Append(loadDisplayStructInstruction);

            var displayStructFieldRef = ClosureField.FieldType.Resolve().Fields.First(f => f.Name == ((FieldReference)instruction.Operand).Name);
            var loadDisplayStructFieldInstruction = processor.Create(OpCodes.Ldfld, displayStructFieldRef);
            processor.Append(loadDisplayStructFieldInstruction);
        }

        TypeReference InitDelegateInterfaceTypeReference()
        {
            var voidType = Module.ImportReference(typeof(void));
            var lambdaParameters = lambdaMethod.Parameters;
            var paramCount = lambdaParameters.Count;
            var isAction = lambdaMethod.ReturnType.FullName == voidType.FullName;
            Type type = GetDelegateInterfaceType(isAction, paramCount);
            var typeRef = Module.ImportReference(type);
            if (isAction && paramCount == 0)
                return typeRef;

            var genericTypeRef = new GenericInstanceType(typeRef);
            foreach (var parameter in lambdaParameters)
                genericTypeRef.GenericArguments.Add(parameter.ParameterType);
            if (!isAction)
                genericTypeRef.GenericArguments.Add(lambdaMethod.ReturnType);
            return genericTypeRef;
        }

        Type GetDelegateInterfaceType(bool isAction, int paramCount)
        {
            switch (paramCount)
            {
                case 0:
                    return isAction ? typeof(IAction) : typeof(IFunc<>);
                case 1:
                    return isAction ? typeof(IAction<>) : typeof(IFunc<,>);
                case 2:
                    return isAction ? typeof(IAction<,>) : typeof(IFunc<,,>);
                case 3:
                    return isAction ? typeof(IAction<,,>) : typeof(IFunc<,,,>);
                case 4:
                    return isAction ? typeof(IAction<,,,>) : typeof(IFunc<,,,,>);
                case 5:
                    return isAction ? typeof(IAction<,,,,>) : typeof(IFunc<,,,,,>);
                case 6:
                    return isAction ? typeof(IAction<,,,,,>) : typeof(IFunc<,,,,,,>);
                case 7:
                    return isAction ? typeof(IAction<,,,,,,>) : typeof(IFunc<,,,,,,,>);
                default:
                    throw new NotSupportedException("delegates with over 7 parameters are not supported");
            }
        }
    }
}