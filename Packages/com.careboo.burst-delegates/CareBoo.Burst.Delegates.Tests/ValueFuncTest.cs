using NUnit.Framework;
using CareBoo.Burst.Delegates;
using Unity.Jobs;
using Unity.Burst;

internal class ValueFuncTest
{
    public struct DisplayStruct
    {
        public int Value;
    }

    [BurstCompile]
    public struct AddOneJob<TFunc> : IJob
        where TFunc : struct, IFunc<int, int>
    {
        public ValueFunc<int, int>.Struct<TFunc> Impl;

        public void Execute()
        {
            Impl.Invoke(0);
        }
    }

    public struct EchoFunc : IFunc<int, int>
    {
        public DisplayStruct DisplayStruct;

        public int Invoke(int val)
        {
            return val;
        }
    }

    public struct AddOneFunc : IFunc<int, int>
    {
        public DisplayStruct DisplayStruct;

        public int Invoke(int a)
        {
            return a + 1;
        }
    }

    [Test, Parallelizable]
    public void ValueFuncStructInvokeCanBeRun()
    {
        var expected = 42;
        var actual = ValueFunc<int, int>.CreateStruct<EchoFunc>(default).Invoke(expected);
        Assert.AreEqual(expected, actual);
    }

    public int TestMethod<TImpl>(int arg0, ValueFunc<int, int>.Struct<TImpl> arg1, int arg2)
        where TImpl : struct, IFunc<int, int>
    {
        return arg1.Invoke(arg2);
    }

    public int TestMethod(int arg0, ValueFunc<int, int>.Lambda arg1, int arg2)
    {
        return -1;
    }

    /*
        IL_0000: ldloca.s V_1
        IL_0002: initobj ValueFuncTest/DisplayStruct
        IL_0008: ldloca.s V_1
        IL_000a: ldc.i4.s 39
        IL_000c: stfld System.Int32 ValueFuncTest/DisplayStruct::Value
        IL_0011: ldloc.1
        IL_0012: stloc.0
    IL_0013: ldarg.0
    IL_0014: ldc.i4.s 39
        IL_0016: ldloca.s V_2
        IL_0018: initobj ValueFuncTest/EchoFunc
        IL_001e: ldloca.s V_2
        IL_0020: ldloc.0
        IL_0021: stfld ValueFuncTest/DisplayStruct ValueFuncTest/EchoFunc::DisplayStruct
        IL_0026: ldloc.2
        IL_0027: call CareBoo.Burst.Delegates.ValueFunc`2/Struct`1<!0,!1,!!0> CareBoo.Burst.Delegates.ValueFunc`2<System.Int32,System.Int32>::CreateStruct<ValueFuncTest/EchoFunc>(!!0)
    IL_002c: ldc.i4.s 39
    IL_002e: call System.Int32 ValueFuncTest::TestMethod<ValueFuncTest/EchoFunc>(System.Int32,CareBoo.Burst.Delegates.ValueFunc`2/Struct`1<System.Int32,System.Int32,TImpl>,System.Int32)
    IL_0033: pop
    IL_0034: ldarg.0
    IL_0035: ldc.i4.s 39
        IL_0037: ldloca.s V_3
        IL_0039: initobj ValueFuncTest/AddOneFunc
        IL_003f: ldloca.s V_3
        IL_0041: ldloc.0
        IL_0042: stfld ValueFuncTest/DisplayStruct ValueFuncTest/AddOneFunc::DisplayStruct
        IL_0047: ldloc.3
        IL_0048: call CareBoo.Burst.Delegates.ValueFunc`2/Struct`1<!0,!1,!!0> CareBoo.Burst.Delegates.ValueFunc`2<System.Int32,System.Int32>::CreateStruct<ValueFuncTest/AddOneFunc>(!!0)
    IL_004d: ldc.i4.s 39
        IL_004f: call System.Int32 ValueFuncTest::TestMethod<ValueFuncTest/AddOneFunc>(System.Int32,CareBoo.Burst.Delegates.ValueFunc`2/Struct`1<System.Int32,System.Int32,TImpl>,System.Int32)
    IL_0054: pop
    IL_0055: ret
    */
    public void CallStruct()
    {
        var displayStruct = new DisplayStruct { Value = 39 };
        TestMethod(39, ValueFunc<int, int>.CreateStruct(new EchoFunc { DisplayStruct = displayStruct }), 39);
        TestMethod(39, ValueFunc<int, int>.CreateStruct(new AddOneFunc { DisplayStruct = displayStruct }), 39);
    }

    /*
        IL_0000: newobj System.Void ValueFuncTest/<>c__DisplayClass7_0::.ctor()
        IL_0005: stloc.0
        IL_0006: ldloc.0
        IL_0007: ldc.i4.s 39
        IL_0009: stfld System.Int32 ValueFuncTest/<>c__DisplayClass7_0::closureValA
        IL_000e: ldloc.0
        IL_000f: ldc.i4.s 32
        IL_0011: stfld System.Int32 ValueFuncTest/<>c__DisplayClass7_0::closureValB
    IL_000e: ldarg.0
    IL_000f: ldc.i4.s 39
        IL_0011: ldloc.0
        IL_0012: ldftn System.Int32 ValueFuncTest/<>c__DisplayClass7_0::<CallLambda>b__0(System.Int32)
        IL_0018: newobj System.Void CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32>::.ctor(System.Object,System.IntPtr)
    IL_001d: ldc.i4.s 39
    IL_001f: call System.Int32 ValueFuncTest::TestMethod(System.Int32,CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32>,System.Int32)
    IL_0024: pop
    IL_0025: ldarg.0
    IL_0026: ldc.i4.s 39
        IL_0028: ldloc.0
        IL_0029: ldftn System.Int32 ValueFuncTest/<>c__DisplayClass7_0::<CallLambda>b__1(System.Int32)
        IL_002f: newobj System.Void CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32>::.ctor(System.Object,System.IntPtr)
    IL_0034: ldc.i4.s 39
        IL_0036: call System.Int32 ValueFuncTest::TestMethod(System.Int32,CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32>,System.Int32)
    IL_003b: pop
    IL_003c: ret
    */
    public void CallLambda()
    {
        var closureValA = 39;
        TestMethod(39, (int val) => val + closureValA, 39);
        TestMethod(39, (int a) => a, 39);
    }

    /*
    IL_0000: ldc.i4.s 42
    IL_0002: stloc.0
    IL_0003: ldarg.0
    IL_0004: ldsfld CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32> ValueFuncTest/<>c::<>9__8_0
    IL_0009: dup
    IL_000a: brtrue.s IL_0023
    IL_000c: pop
    IL_000d: ldsfld ValueFuncTest/<>c ValueFuncTest/<>c::<>9
    IL_0012: ldftn System.Int32 ValueFuncTest/<>c::<CallingTestMethodShouldReturnPassedInLambda>b__8_0(System.Int32)
    IL_0018: newobj System.Void CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32>::.ctor(System.Object,System.IntPtr)
    IL_001d: dup
    IL_001e: stsfld CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32> ValueFuncTest/<>c::<>9__8_0
    IL_0023: ldloc.0
    IL_0024: call System.Int32 ValueFuncTest::TestMethod(CareBoo.Burst.Delegates.ValueFunc`2/Lambda<System.Int32,System.Int32>,System.Int32)
    IL_0029: stloc.1
    IL_002a: ldloc.0
    IL_002b: box System.Int32
    IL_0030: ldloc.1
    IL_0031: box System.Int32
    IL_0036: call System.Void NUnit.Framework.Assert::AreEqual(System.Object,System.Object)
    IL_003b: ret
    */
    [Test]
    public void CallingTestMethodShouldReturnPassedInLambda()
    {
        var expected = 42;
        var actual = TestMethod(39, (int val) => val, expected);
        Assert.AreEqual(expected, actual);
    }
}
