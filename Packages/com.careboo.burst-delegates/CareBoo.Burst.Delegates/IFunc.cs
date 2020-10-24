namespace CareBoo.Burst.Delegates
{
    public interface IFunc<TResult>
    {
        TResult Invoke();
    }

    public interface IFunc<T, TResult>
    {
        TResult Invoke(T arg0);
    }

    public interface IFunc<T, U, TResult>
    {
        TResult Invoke(T arg0, U arg1);
    }

    public interface IFunc<T, U, V, TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2);
    }

    public interface IFunc<T, U, V, W, TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3);
    }

    public interface IFunc<T, U, V, W, X, TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4);
    }

    public interface IFunc<T, U, V, W, X, Y, TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5);
    }

    public interface IFunc<T, U, V, W, X, Y, Z, TResult>
    {
        TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6);
    }
}