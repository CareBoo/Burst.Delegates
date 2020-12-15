﻿namespace CareBoo.Burst.Delegates
{
    public interface IFunc<out TResult>
    {
        TResult Invoke();
    }

    public interface IFunc<in T, out TResult>
    {
        TResult Invoke(T arg0);
    }

    public interface IFunc<in T, in U, out TResult>
    {
        TResult Invoke(T arg0, U arg1);
    }

    public interface IFunc<in T, in U, in V, out TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2);
    }

    public interface IFunc<in T, in U, in V, in W, out TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3);
    }

    public interface IFunc<in T, in U, in V, in W, in X, out TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4);
    }

    public interface IFunc<in T, in U, in V, in W, in X, in Y, out TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5);
    }

    public interface IFunc<in T, in U, in V, in W, in X, in Y, in Z, out TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6);
    }
}