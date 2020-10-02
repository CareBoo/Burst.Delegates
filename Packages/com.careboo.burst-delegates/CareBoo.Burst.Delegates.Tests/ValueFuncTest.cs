using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using CareBoo;
using CareBoo.Burst.Delegates;

internal class ValueFuncTest
{
    public struct MeaningOfLifeFunc : IFunc<int>
    {
        public int Invoke()
        {
            return 42;
        }
    }

    [Test, Parallelizable]
    public void ValueFuncStructInvokeCanBeRun()
    {
        var expected = 42;
        var actual = ValueFunc<int>.CreateStruct<MeaningOfLifeFunc>(default).Invoke();
        Assert.AreEqual(expected, actual);
    }

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
