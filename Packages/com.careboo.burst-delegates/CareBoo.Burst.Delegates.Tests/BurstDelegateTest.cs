using CareBoo.Burst.Delegates;
using NUnit.Framework;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

[BurstCompile]
internal class BurstDelegateTests
{
    [BurstCompile]
    public struct CallFuncJob<TFunc> : IJob
        where TFunc : struct, IFunc<int, int>
    {
        public TFunc Func;
        public NativeArray<int> In;
        public NativeArray<int> Out;

        public void Execute()
        {
            Out[0] = Func.Invoke(In[0]);
        }
    }

    public static CallFuncJob<TFunc> NewCallFuncJob<TFunc>(
        ValueFunc<int, int>.Impl<TFunc> func,
        NativeArray<int> input,
        NativeArray<int> output
    ) where TFunc : struct, IFunc<int, int>
    {
        return new CallFuncJob<TFunc> { Func = func.Lambda, In = input, Out = output };
    }

    [BurstCompile]
    public static int Add(int x, int y) => x + y;

    public struct AddStruct : IFunc<int, int, int>
    {
        public int Invoke(int x, int y) => x + y;
    }


    [Test]
    public void TestValueFuncCanInvokeInsideOfBurstedCode()
    {
        var addFunc = ValueFunc<int, int, int>.New<AddStruct>();
        using var input = new NativeArray<int>(new int[1], Allocator.Persistent);
        using var output = new NativeArray<int>(new int[1], Allocator.Persistent);
        var expected = Add(4, input[0]);
        NewCallFuncJob(addFunc.PartialInvoke(4), input, output).Run();
        var actual = output[0];
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestValueFuncCanInvokeOutsideOfBurstedCode()
    {
        var addFunc = ValueFunc<int, int, int>.New<AddStruct>();
        using var input = new NativeArray<int>(new int[1], Allocator.Persistent);
        using var output = new NativeArray<int>(new int[1], Allocator.Persistent);
        var expected = Add(4, input[0]);
        var actual = addFunc.PartialInvoke(4).Invoke(input[0]);
        Assert.AreEqual(expected, actual);
    }
}
