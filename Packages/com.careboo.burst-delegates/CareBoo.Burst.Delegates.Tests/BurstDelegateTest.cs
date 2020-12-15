using CareBoo.Burst.Delegates;
using NUnit.Framework;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;

internal class BurstDelegateTests
{
    public enum FuncFlags
    {
        None,
        BurstCalled = 1,
        ValueFuncCalled = 2,
    }

    [BurstCompile]
    public struct CallFuncJob : IJob
    {
        [ReadOnly]
        public ValueFunc<int, int>.Struct<BurstFunc<int, int>> Func;

        [ReadOnly]
        public NativeArray<int> Input;

        [WriteOnly]
        public NativeArray<int> Output;

        public void Execute()
        {
            Output[0] = Func.Invoke(Input[0]);
        }
    }

    public static int Add4(int val) => val + 4;


    [Test]
    public void TestCannotInvokeOutsideOfBurstedCode()
    {
        using (var input = new NativeArray<int>(new int[1], Allocator.Persistent))
        using (var output = new NativeArray<int>(new int[1], Allocator.Persistent))
        {
        }
    }
}
