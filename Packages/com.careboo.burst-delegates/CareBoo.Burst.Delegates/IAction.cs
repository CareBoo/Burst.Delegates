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
}
