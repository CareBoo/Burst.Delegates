



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

namespace CareBoo.Burst.Delegates
{

    public struct BurstAction
        : IAction
    {
        readonly FunctionPointer<Action> functionPointer;

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke()
        {
            CheckBurst();

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke();
        }

        [BurstDiscard]
        private void CheckBurst()
        {
            burstEnabled = false;
            DelegateCache<Action>.GetDelegate(functionPointer.Value).Invoke();
        }

        public static BurstAction Compile(Action action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action>.SetDelegate(functionPointer.Value, action);
            return new BurstAction(functionPointer);
        }

        public static implicit operator ValueAction.Struct<BurstAction>(BurstAction burstAction)
        {
            return ValueAction.New(burstAction);
        }

        public static implicit operator BurstAction(ValueAction.Struct<BurstAction> valueAction)
        {
            return valueAction.lambda;
        }
    }


    public struct BurstAction<T>
        : IAction<T>
        where T : struct
    {
        readonly FunctionPointer<Action<T>> functionPointer;

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action<T>> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke(T arg0)
        {
            CheckBurst(arg0);

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke(arg0);
        }

        [BurstDiscard]
        private void CheckBurst(T arg0)
        {
            burstEnabled = false;
            DelegateCache<Action<T>>.GetDelegate(functionPointer.Value).Invoke(arg0);
        }

        public static BurstAction<T> Compile(Action<T> action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action<T>>.SetDelegate(functionPointer.Value, action);
            return new BurstAction<T>(functionPointer);
        }

        public static implicit operator ValueAction<T>.Struct<BurstAction<T>>(BurstAction<T> burstAction)
        {
            return ValueAction<T>.New(burstAction);
        }

        public static implicit operator BurstAction<T>(ValueAction<T>.Struct<BurstAction<T>> valueAction)
        {
            return valueAction.lambda;
        }
    }


    public struct BurstAction<T, U>
        : IAction<T, U>
        where T : struct
        where U : struct
    {
        readonly FunctionPointer<Action<T, U>> functionPointer;

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action<T, U>> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke(T arg0, U arg1)
        {
            CheckBurst(arg0, arg1);

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke(arg0, arg1);
        }

        [BurstDiscard]
        private void CheckBurst(T arg0, U arg1)
        {
            burstEnabled = false;
            DelegateCache<Action<T, U>>.GetDelegate(functionPointer.Value).Invoke(arg0, arg1);
        }

        public static BurstAction<T, U> Compile(Action<T, U> action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action<T, U>>.SetDelegate(functionPointer.Value, action);
            return new BurstAction<T, U>(functionPointer);
        }

        public static implicit operator ValueAction<T, U>.Struct<BurstAction<T, U>>(BurstAction<T, U> burstAction)
        {
            return ValueAction<T, U>.New(burstAction);
        }

        public static implicit operator BurstAction<T, U>(ValueAction<T, U>.Struct<BurstAction<T, U>> valueAction)
        {
            return valueAction.lambda;
        }
    }


    public struct BurstAction<T, U, V>
        : IAction<T, U, V>
        where T : struct
        where U : struct
        where V : struct
    {
        readonly FunctionPointer<Action<T, U, V>> functionPointer;

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action<T, U, V>> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke(T arg0, U arg1, V arg2)
        {
            CheckBurst(arg0, arg1, arg2);

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke(arg0, arg1, arg2);
        }

        [BurstDiscard]
        private void CheckBurst(T arg0, U arg1, V arg2)
        {
            burstEnabled = false;
            DelegateCache<Action<T, U, V>>.GetDelegate(functionPointer.Value).Invoke(arg0, arg1, arg2);
        }

        public static BurstAction<T, U, V> Compile(Action<T, U, V> action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action<T, U, V>>.SetDelegate(functionPointer.Value, action);
            return new BurstAction<T, U, V>(functionPointer);
        }

        public static implicit operator ValueAction<T, U, V>.Struct<BurstAction<T, U, V>>(BurstAction<T, U, V> burstAction)
        {
            return ValueAction<T, U, V>.New(burstAction);
        }

        public static implicit operator BurstAction<T, U, V>(ValueAction<T, U, V>.Struct<BurstAction<T, U, V>> valueAction)
        {
            return valueAction.lambda;
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

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action<T, U, V, W>> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3)
        {
            CheckBurst(arg0, arg1, arg2, arg3);

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke(arg0, arg1, arg2, arg3);
        }

        [BurstDiscard]
        private void CheckBurst(T arg0, U arg1, V arg2, W arg3)
        {
            burstEnabled = false;
            DelegateCache<Action<T, U, V, W>>.GetDelegate(functionPointer.Value).Invoke(arg0, arg1, arg2, arg3);
        }

        public static BurstAction<T, U, V, W> Compile(Action<T, U, V, W> action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action<T, U, V, W>>.SetDelegate(functionPointer.Value, action);
            return new BurstAction<T, U, V, W>(functionPointer);
        }

        public static implicit operator ValueAction<T, U, V, W>.Struct<BurstAction<T, U, V, W>>(BurstAction<T, U, V, W> burstAction)
        {
            return ValueAction<T, U, V, W>.New(burstAction);
        }

        public static implicit operator BurstAction<T, U, V, W>(ValueAction<T, U, V, W>.Struct<BurstAction<T, U, V, W>> valueAction)
        {
            return valueAction.lambda;
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

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X>> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4)
        {
            CheckBurst(arg0, arg1, arg2, arg3, arg4);

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke(arg0, arg1, arg2, arg3, arg4);
        }

        [BurstDiscard]
        private void CheckBurst(T arg0, U arg1, V arg2, W arg3, X arg4)
        {
            burstEnabled = false;
            DelegateCache<Action<T, U, V, W, X>>.GetDelegate(functionPointer.Value).Invoke(arg0, arg1, arg2, arg3, arg4);
        }

        public static BurstAction<T, U, V, W, X> Compile(Action<T, U, V, W, X> action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action<T, U, V, W, X>>.SetDelegate(functionPointer.Value, action);
            return new BurstAction<T, U, V, W, X>(functionPointer);
        }

        public static implicit operator ValueAction<T, U, V, W, X>.Struct<BurstAction<T, U, V, W, X>>(BurstAction<T, U, V, W, X> burstAction)
        {
            return ValueAction<T, U, V, W, X>.New(burstAction);
        }

        public static implicit operator BurstAction<T, U, V, W, X>(ValueAction<T, U, V, W, X>.Struct<BurstAction<T, U, V, W, X>> valueAction)
        {
            return valueAction.lambda;
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

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X, Y>> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5)
        {
            CheckBurst(arg0, arg1, arg2, arg3, arg4, arg5);

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
        }

        [BurstDiscard]
        private void CheckBurst(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5)
        {
            burstEnabled = false;
            DelegateCache<Action<T, U, V, W, X, Y>>.GetDelegate(functionPointer.Value).Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
        }

        public static BurstAction<T, U, V, W, X, Y> Compile(Action<T, U, V, W, X, Y> action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action<T, U, V, W, X, Y>>.SetDelegate(functionPointer.Value, action);
            return new BurstAction<T, U, V, W, X, Y>(functionPointer);
        }

        public static implicit operator ValueAction<T, U, V, W, X, Y>.Struct<BurstAction<T, U, V, W, X, Y>>(BurstAction<T, U, V, W, X, Y> burstAction)
        {
            return ValueAction<T, U, V, W, X, Y>.New(burstAction);
        }

        public static implicit operator BurstAction<T, U, V, W, X, Y>(ValueAction<T, U, V, W, X, Y>.Struct<BurstAction<T, U, V, W, X, Y>> valueAction)
        {
            return valueAction.lambda;
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

        bool burstEnabled;

        public BurstAction(FunctionPointer<Action<T, U, V, W, X, Y, Z>> functionPointer)
        {
            this.functionPointer = functionPointer;
            burstEnabled = true;
        }

        public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6)
        {
            CheckBurst(arg0, arg1, arg2, arg3, arg4, arg5, arg6);

            Unity.Burst.CompilerServices.Hint.Assume(burstEnabled);
            if (burstEnabled)
                functionPointer.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        [BurstDiscard]
        private void CheckBurst(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6)
        {
            burstEnabled = false;
            DelegateCache<Action<T, U, V, W, X, Y, Z>>.GetDelegate(functionPointer.Value).Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
        }

        public static BurstAction<T, U, V, W, X, Y, Z> Compile(Action<T, U, V, W, X, Y, Z> action)
        {
            var functionPointer = BurstCompiler.CompileFunctionPointer(action);
            DelegateCache<Action<T, U, V, W, X, Y, Z>>.SetDelegate(functionPointer.Value, action);
            return new BurstAction<T, U, V, W, X, Y, Z>(functionPointer);
        }

        public static implicit operator ValueAction<T, U, V, W, X, Y, Z>.Struct<BurstAction<T, U, V, W, X, Y, Z>>(BurstAction<T, U, V, W, X, Y, Z> burstAction)
        {
            return ValueAction<T, U, V, W, X, Y, Z>.New(burstAction);
        }

        public static implicit operator BurstAction<T, U, V, W, X, Y, Z>(ValueAction<T, U, V, W, X, Y, Z>.Struct<BurstAction<T, U, V, W, X, Y, Z>> valueAction)
        {
            return valueAction.lambda;
        }
    }


}