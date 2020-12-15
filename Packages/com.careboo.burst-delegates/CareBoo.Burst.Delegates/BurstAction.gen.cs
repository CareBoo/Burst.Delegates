



//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Unity.Burst;
using static CareBoo.Burst.Delegates.SafetyChecks;

namespace CareBoo.Burst.Delegates
{

    public struct BurstAction
        : IAction
    {
        readonly FunctionPointer<Action> functionPointer;

        public BurstAction(FunctionPointer<Action> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke()
        {
            SupportedInBurstOnly();
            functionPointer.Invoke();
        }
    }


    public struct BurstAction<T>
        : IAction<T>
        where T : struct
    {
        readonly FunctionPointer<Action<T>> functionPointer;

        public BurstAction(FunctionPointer<Action<T>> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke(T arg0)
        {
            SupportedInBurstOnly();
            functionPointer.Invoke(arg0);
        }
    }


    public struct BurstAction<T, U>
        : IAction<T, U>
        where T : struct
        where U : struct
    {
        readonly FunctionPointer<Action<T, U>> functionPointer;

        public BurstAction(FunctionPointer<Action<T, U>> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke(T arg0, U arg1)
        {
            SupportedInBurstOnly();
            functionPointer.Invoke(arg0, arg1);
        }
    }


    public struct BurstAction<T, U, V>
        : IAction<T, U, V>
        where T : struct
        where U : struct
        where V : struct
    {
        readonly FunctionPointer<Action<T, U, V>> functionPointer;

        public BurstAction(FunctionPointer<Action<T, U, V>> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke(T arg0, U arg1, V arg2)
        {
            SupportedInBurstOnly();
            functionPointer.Invoke(arg0, arg1, arg2);
        }
    }


    public struct BurstAction<T, U, V, W>
        : IAction<T, U, V, W>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
    {
        readonly FunctionPointer<Action<T, U, V, W>> functionPointer;

        public BurstAction(FunctionPointer<Action<T, U, V, W>> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3)
        {
            SupportedInBurstOnly();
            functionPointer.Invoke(arg0, arg1, arg2, arg3);
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
        readonly FunctionPointer<Action<T, U, V, W, X>> functionPointer;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X>> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4)
        {
            SupportedInBurstOnly();
            functionPointer.Invoke(arg0, arg1, arg2, arg3, arg4);
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
        readonly FunctionPointer<Action<T, U, V, W, X, Y>> functionPointer;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X, Y>> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5)
        {
            SupportedInBurstOnly();
            functionPointer.Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
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
        readonly FunctionPointer<Action<T, U, V, W, X, Y, Z>> functionPointer;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X, Y, Z>> functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6)
        {
            SupportedInBurstOnly();
            functionPointer.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }
    }


}