using System;
using Unity.Burst;
using static CareBoo.Burst.Delegates.SafetyChecks;

namespace CareBoo.Burst.Delegates
{
    public struct BurstAction
        : IAction
    {
        readonly FunctionPointer<Action> fPtr;

        public BurstAction(FunctionPointer<Action> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke()
        {
            SupportedInBurstOnly();
            fPtr.Invoke();
        }
    }

    public struct BurstAction<T>
        : IAction<T>
        where T : struct
    {
        readonly FunctionPointer<Action<T>> fPtr;

        public BurstAction(FunctionPointer<Action<T>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke(T arg0)
        {
            SupportedInBurstOnly();
            fPtr.Invoke(arg0);
        }
    }

    public struct BurstAction<T, U>
        : IAction<T, U>
        where T : struct
        where U : struct
    {
        readonly FunctionPointer<Action<T, U>> fPtr;

        public BurstAction(FunctionPointer<Action<T, U>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke(T arg0, U arg1)
        {
            SupportedInBurstOnly();
            fPtr.Invoke(arg0, arg1);
        }
    }

    public struct BurstAction<T, U, V>
        : IAction<T, U, V>
        where T : struct
        where U : struct
        where V : struct
    {
        readonly FunctionPointer<Action<T, U, V>> fPtr;

        public BurstAction(FunctionPointer<Action<T, U, V>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke(T arg0, U arg1, V arg2)
        {
            SupportedInBurstOnly();
            fPtr.Invoke(arg0, arg1, arg2);
        }
    }

    public struct BurstAction<T, U, V, W>
        : IAction<T, U, V, W>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
    {
        readonly FunctionPointer<Action<T, U, V, W>> fPtr;

        public BurstAction(FunctionPointer<Action<T, U, V, W>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3)
        {
            SupportedInBurstOnly();
            fPtr.Invoke(arg0, arg1, arg2, arg3);
        }
    }

    public struct BurstAction<T, U, V, W, X>
        : IAction<T, U, V, W, X>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
    {
        readonly FunctionPointer<Action<T, U, V, W, X>> fPtr;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4)
        {
            SupportedInBurstOnly();
            fPtr.Invoke(arg0, arg1, arg2, arg3, arg4);
        }
    }

    public struct BurstAction<T, U, V, W, X, Y>
        : IAction<T, U, V, W, X, Y>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
    {
        readonly FunctionPointer<Action<T, U, V, W, X, Y>> fPtr;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X, Y>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5)
        {
            SupportedInBurstOnly();
            fPtr.Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
        }
    }

    public struct BurstAction<T, U, V, W, X, Y, Z>
        : IAction<T, U, V, W, X, Y, Z>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
        where Z : struct
    {
        readonly FunctionPointer<Action<T, U, V, W, X, Y, Z>> fPtr;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X, Y, Z>> fPtr)
        {
            this.fPtr = fPtr;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6)
        {
            SupportedInBurstOnly();
            fPtr.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }

}
