using System;
using NUnit.Framework;
using Mono.Cecil;
using System.Linq;
using System.Collections.Generic;
using CareBoo.Burst.Delegates;
using CareBoo.Burst.Delegates.CodeGen;
using UnityEngine;
using System.Text;

internal class ILPrinter : BaseProcessorTest
{
    [Test, Parallelizable]
    public void PrintLambdaIL()
    {
        var method = GetMethodDefinition<ValueFuncTest>(nameof(ValueFuncTest.CallLambda));
        PrintIL(method);
    }

    [Test, Parallelizable]
    public void PrintStructIL()
    {
        var method = GetMethodDefinition<ValueFuncTest>(nameof(ValueFuncTest.CallStruct));
        PrintIL(method);
    }

    [Test, Parallelizable]
    public void PrintTestIL()
    {
        var method = GetMethodDefinition<ValueFuncTest>(nameof(ValueFuncTest.CallingTestMethodShouldReturnPassedInLambda));
        PrintIL(method);
    }

    [Test, Parallelizable]
    public void PrintIndirectTestIL()
    {
        var method = GetMethodDefinition<CodeGenTestFixture>(nameof(CodeGenTestFixture.IndirectTest));
        PrintIL(method);
    }

    [Test, Parallelizable]
    public void PrintInputIL()
    {
        var method = GetMethodDefinition<CodeGenTestFixture>(nameof(CodeGenTestFixture.Input));
        PrintIL(method);
    }

    [Test, Parallelizable]
    public void PrintExpectedIL()
    {
        var method = GetMethodDefinition<CodeGenTestFixture>(nameof(CodeGenTestFixture.Expected));
        PrintIL(method);
    }

    [Test, Parallelizable]
    public void PrintCodeGenFixtureNestedTypes()
    {
        PrintIL(GetTypeDefinition(typeof(CodeGenTestFixture)));
    }

    [Test, Parallelizable]
    public void PrintDisplayClassMethods()
    {
        var type = GetTypeDefinition(typeof(CodeGenTestFixture));
        foreach (var method in type.NestedTypes.Where(t => t.Name.Contains("DisplayClass")).SelectMany(t => t.Methods))
            PrintIL(method);
    }

    [Test, Parallelizable]
    public void PrintValueDelegateStructMethods()
    {
        var type = GetTypeDefinition(typeof(CodeGenTestFixture));
        foreach (var method in type.NestedTypes.Where(t => t.Name.Contains("EqualsFunc")).SelectMany(t => t.Methods))
            PrintIL(method);
    }

    void PrintIL(MethodDefinition method)
    {
        Debug.Log($"IL for method \"{method.FullName}\":\n{string.Join("\n", method.Body.Variables.Select(v => $"{v}: {v.VariableType}"))}\n{string.Join("\n", method.Body.Instructions)}");
    }

    void PrintIL(TypeDefinition type)
    {
        var msg = new StringBuilder();
        msg.Append($"IL for type \"{type.FullName}\":")
            .Append("\n")
            .Append("Nested types:")
            .Append("\n")
            .Append($"{string.Join("\n", type.NestedTypes)}");
        Debug.Log(msg.ToString());
    }
}
