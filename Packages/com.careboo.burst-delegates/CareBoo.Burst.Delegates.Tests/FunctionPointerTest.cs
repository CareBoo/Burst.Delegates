using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Collections.LowLevel.Unsafe;
using NUnit.Framework;

[BurstCompile]
internal class FunctionPointerTest
{
    [BurstCompile]
    public unsafe struct CallFuncJob : IJob
    {
        [ReadOnly]
        [NativeDisableUnsafePtrRestriction]
        public IntPtr FuncPtr;

        [ReadOnly]
        public NativeArray<int> Input;

        [WriteOnly]
        public NativeArray<int> Output;

        public void Execute()
        {
            Output[0] = ((delegate*<int, int>)FuncPtr)(Input[0]);
        }
    }

    [BurstCompile]
    public static int Add4(int val) => val + 4;

    static unsafe void CallFuncWithJob(NativeArray<int> input, NativeArray<int> output)
    {
        delegate*<int, int> funcPtr = &Add4;
        new CallFuncJob { FuncPtr = (IntPtr)funcPtr, Input = input, Output = output }.Run();
    }

    [Test]
    public void TestCanInvokeInsideOfBurstedCode()
    {
        using var input = new NativeArray<int>(new int[1], Allocator.Persistent);
        using var output = new NativeArray<int>(new int[1], Allocator.Persistent);
        var expected = Add4(input[0]);
        CallFuncWithJob(input, output);
        var actual = output[0];
        Assert.AreEqual(expected, actual);
    }
}
