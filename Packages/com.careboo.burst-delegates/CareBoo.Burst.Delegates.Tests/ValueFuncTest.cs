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
    public void ValueFuncInvokeCanBeRun()
    {
        var expected = 42;
        var actual = ValueFunc<int>.CreateStruct<MeaningOfLifeFunc>(default).Invoke();
        Assert.AreEqual(expected, actual);
    }
}
