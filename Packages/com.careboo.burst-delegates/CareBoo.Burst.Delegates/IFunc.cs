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
}