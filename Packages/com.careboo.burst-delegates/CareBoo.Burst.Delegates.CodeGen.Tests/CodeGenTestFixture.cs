using System;
using CareBoo.Burst.Delegates;

internal class CodeGenTestFixture
{
    private struct DisplayStruct
    {
        public int a;
        public int b;
    }

    private struct AEqualsFunc : IFunc<int, bool>
    {
        public DisplayStruct closure;

        public bool Invoke(int arg0)
        {
            return closure.a == arg0;
        }
    }

    private struct BEqualsFunc : IFunc<int, bool>
    {
        public DisplayStruct closure;

        public bool Invoke(int arg0)
        {
            return closure.b == arg0;
        }
    }

    public static void Test<TImpl>(ValueFunc<int, bool>.Struct<TImpl> func)
        where TImpl : struct, IFunc<int, bool>
    {
    }

    public static void Test(ValueFunc<int, bool>.Lambda func)
    {
    }

    public void IndirectTest(ValueFunc<int, bool>.Lambda func)
    {
        Test(func);
    }

    public void Input()
    {
        var a = 1;
        var b = 2;
        Test((int arg0) => a == arg0);
        Test((int arg0) => b == arg0);
    }

    public void Expected()
    {
        var a = 1;
        var b = 1;
        var closure = new DisplayStruct { a = a, b = b };
        var aFuncStruct = new AEqualsFunc { closure = closure };
        var aFunc = ValueFunc<int, bool>.CreateStruct(aFuncStruct);
        Test(aFunc);
        var bFuncStruct = new BEqualsFunc { closure = closure };
        var bFunc = ValueFunc<int, bool>.CreateStruct(bFuncStruct);
        Test(bFunc);
    }
}
