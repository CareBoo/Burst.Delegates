using System;
using NUnit.Framework;
using Mono.Cecil;
using System.Linq;
using System.Collections.Generic;
using CareBoo.Burst.Delegates;
using CareBoo.Burst.Delegates.CodeGen;
using UnityEngine;

internal class ValueFuncTest : BaseProcessorTest
{
    public int TestMethod<TImpl>(ValueFunc<int, int>.Struct<TImpl> func, int val)
        where TImpl : struct, IFunc<int, int>
    {
        return func.Invoke(val);
    }

    public int TestMethod(ValueFunc<int, int>.Lambda func, int val)
    {
        return -1;
    }

    [Test]
    public void CallingTestMethodShouldReturnPassedInLambda()
    {
        var expected = 42;
        var actual = TestMethod((int val) => val, expected);
        Assert.AreEqual(expected, actual);
    }
}
