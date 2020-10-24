namespace CareBoo.Burst.Delegates
{
    public interface IAction
    {
        void Invoke();
    }

    public interface IAction<T>
    {
        void Invoke(T arg0);
    }

    public interface IAction<T, U>
    {
        void Invoke(T arg0, U arg1);
    }

    public interface IAction<T, U, V>
    {
        void Invoke(T arg0, U arg1, V arg2);
    }

    public interface IAction<T, U, V, W>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3);
    }

    public interface IAction<T, U, V, W, X>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4);
    }

    public interface IAction<T, U, V, W, X, Y>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5);
    }

    public interface IAction<T, U, V, W, X, Y, Z>
    {
        void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6);
    }
}
