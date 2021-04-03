using System;
using System.Text.RegularExpressions;
using CareBoo.Burst.Delegates;
using NUnit.Framework;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.TestTools;

[BurstCompile]
internal class BurstDelegateTests
{
    [BurstCompile]
    public struct CallFuncJob : IJob
    {
        [ReadOnly]
        public BurstFunc<int, int> Func;

        [ReadOnly]
        public NativeArray<int> Input;

        [WriteOnly]
        public NativeArray<int> Output;

        public void Execute()
        {
            Output[0] = Func.Invoke(Input[0]);
        }
    }

    [BurstCompile]
    public static int Add4(int val) => val + 4;

    public static unsafe readonly BurstFunc<int, int> Add4Func = new BurstFunc<int, int>(&Add4);

    [Test]
    public void TestCanInvokeInsideOfBurstedCode()
    {
        using (var input = new NativeArray<int>(new int[1], Allocator.Persistent))
        using (var output = new NativeArray<int>(new int[1], Allocator.Persistent))
        {
            var expected = Add4(input[0]);
            new CallFuncJob { Func = Add4Func, Input = input, Output = output }.Run();
            var actual = output[0];
            Assert.AreEqual(expected, actual);
        }
    }

    [Test]
    public void TestCanInvokeOutsideOfBurstedCode()
    {
        using (var input = new NativeArray<int>(new int[1], Allocator.Persistent))
        using (var output = new NativeArray<int>(new int[1], Allocator.Persistent))
        {
            var expected = Add4(input[0]);
            var actual = Add4Func.Invoke(input[0]);
            Assert.AreEqual(expected, actual);
        }
    }
}
