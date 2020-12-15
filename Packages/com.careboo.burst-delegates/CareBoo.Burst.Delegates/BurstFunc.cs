using System;
using Unity.Burst;
using static CareBoo.Burst.Delegates.SafetyChecks;

namespace CareBoo.Burst.Delegates
{
    public struct BurstFunc<TResult>
        : IFunc<TResult>
        where TResult : struct
    {
        readonly FunctionPointer<Func<TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke()
        {
            SupportedInBurstOnly();
            return fPtr.Invoke();
        }
    }

    public struct BurstFunc<T, TResult>
        : IFunc<T, TResult>
        where T : struct
        where TResult : struct
    {
        readonly FunctionPointer<Func<T, TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<T, TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke(T arg0)
        {
            SupportedInBurstOnly();
            return fPtr.Invoke(arg0);
        }
    }

    public struct BurstFunc<T, U, TResult>
        : IFunc<T, U, TResult>
        where T : struct
        where U : struct
        where TResult : struct
    {
        readonly FunctionPointer<Func<T, U, TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<T, U, TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke(T arg0, U arg1)
        {
            SupportedInBurstOnly();
            return fPtr.Invoke(arg0, arg1);
        }
    }

    public struct BurstFunc<T, U, V, TResult>
        : IFunc<T, U, V, TResult>
        where T : struct
        where U : struct
        where V : struct
        where TResult : struct
    {
        readonly FunctionPointer<Func<T, U, V, TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<T, U, V, TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke(T arg0, U arg1, V arg2)
        {
            SupportedInBurstOnly();
            return fPtr.Invoke(arg0, arg1, arg2);
        }
    }

    public struct BurstFunc<T, U, V, W, TResult>
        : IFunc<T, U, V, W, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where TResult : struct
    {
        readonly FunctionPointer<Func<T, U, V, W, TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<T, U, V, W, TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke(T arg0, U arg1, V arg2, W arg3)
        {
            SupportedInBurstOnly();
            return fPtr.Invoke(arg0, arg1, arg2, arg3);
        }
    }

    public struct BurstFunc<T, U, V, W, X, TResult>
        : IFunc<T, U, V, W, X, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where TResult : struct
    {
        readonly FunctionPointer<Func<T, U, V, W, X, TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<T, U, V, W, X, TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4)
        {
            SupportedInBurstOnly();
            return fPtr.Invoke(arg0, arg1, arg2, arg3, arg4);
        }
    }

    public struct BurstFunc<T, U, V, W, X, Y, TResult>
        : IFunc<T, U, V, W, X, Y, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
        where TResult : struct
    {
        readonly FunctionPointer<Func<T, U, V, W, X, Y, TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<T, U, V, W, X, Y, TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5)
        {
            SupportedInBurstOnly();
            return fPtr.Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
        }
    }

    public struct BurstFunc<T, U, V, W, X, Y, Z, TResult>
        : IFunc<T, U, V, W, X, Y, Z, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
        where Z : struct
        where TResult : struct
    {
        readonly FunctionPointer<Func<T, U, V, W, X, Y, Z, TResult>> fPtr;

        public BurstFunc(FunctionPointer<Func<T, U, V, W, X, Y, Z, TResult>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6)
        {
            SupportedInBurstOnly();
            return fPtr.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

}
