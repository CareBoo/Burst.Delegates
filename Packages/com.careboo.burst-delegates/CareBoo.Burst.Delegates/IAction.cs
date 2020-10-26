﻿namespace CareBoo.Burst.Delegates
{
    public interface IAction
    {
        void Invoke();
    }

    public interface IAction<in T>
    {
        void Invoke(T arg0);
    }

    public interface IAction<in T, in U>
    {
        void Invoke(T arg0, U arg1);
    }

    public interface IAction<in T, in U, in V>
    {
        void Invoke(T arg0, U arg1, V arg2);
    }

    public interface IAction<in T, in U, in V, in W>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3);
    }

    public interface IAction<in T, in U, in V, in W, in X>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4);
    }

    public interface IAction<in T, in U, in V, in W, in X, in Y>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5);
    }

    public interface IAction<in T, in U, in V, in W, in X, in Y, in Z>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6);
    }
}
