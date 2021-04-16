using CareBoo.Burst.Delegates;
using NUnit.Framework;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

[BurstCompile]
internal class BurstDelegateTests
{
    [BurstCompile]
    public struct CallFuncJob<TImpl> : IJob
        where TImpl : struct, IFunc<int, int>
    {
        public ValueFunc<int, int>.Impl<TImpl> Func;
        public NativeArray<int> In;
        public NativeArray<int> Out;

        public void Execute()
        {
            Out[0] = Func.Invoke(In[0]);
        }
    }

    [BurstCompile]
    public static int Add4(int val) => val + 4;

    public static readonly BurstFunc<int, int> Add4Func = BurstFunc<int, int>.Compile(Add4);

    [Test]
    public void TestCompiledPointerCanInvokeInsideOfBurstedCode()
    {
        using var input = new NativeArray<int>(new int[1], Allocator.Persistent);
        using var output = new NativeArray<int>(new int[1], Allocator.Persistent);
        var expected = Add4(input[0]);
        new CallFuncJob<BurstFunc<int, int>> { Func = ValueFunc<int, int>.New(Add4Func), In = input, Out = output }.Run();
        var actual = output[0];
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TestCanInvokeOutsideOfBurstedCode()
    {
        using var input = new NativeArray<int>(new int[1], Allocator.Persistent);
        using var output = new NativeArray<int>(new int[1], Allocator.Persistent);
        var expected = Add4(input[0]);
        var actual = Add4Func.Invoke(input[0]);
        Assert.AreEqual(expected, actual);
    }
}
