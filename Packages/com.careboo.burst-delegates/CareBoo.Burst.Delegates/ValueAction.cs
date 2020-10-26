namespace CareBoo.Burst.Delegates
{
    public struct ValueAction
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction
        {
            readonly TLambda lambda;

            public void Invoke()
            {
                lambda.Invoke();
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public struct ValueAction<T>
        where T : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction<T>
        {
            readonly TLambda lambda;

            public void Invoke(T arg0)
            {
                lambda.Invoke(arg0);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction<T>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public struct ValueAction<T, U>
        where T : struct
        where U : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction<T, U>
        {
            readonly TLambda lambda;

            public void Invoke(T arg0, U arg1)
            {
                lambda.Invoke(arg0, arg1);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction<T, U>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public struct ValueAction<T, U, V>
        where T : struct
        where U : struct
        where V : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction<T, U, V>
        {
            readonly TLambda lambda;

            public void Invoke(T arg0, U arg1, V arg2)
            {
                lambda.Invoke(arg0, arg1, arg2);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction<T, U, V>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public struct ValueAction<T, U, V, W>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction<T, U, V, W>
        {
            readonly TLambda lambda;

            public void Invoke(T arg0, U arg1, V arg2, W arg3)
            {
                lambda.Invoke(arg0, arg1, arg2, arg3);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction<T, U, V, W>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public struct ValueAction<T, U, V, W, X>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction<T, U, V, W, X>
        {
            readonly TLambda lambda;

            public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4)
            {
                lambda.Invoke(arg0, arg1, arg2, arg3, arg4);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction<T, U, V, W, X>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public struct ValueAction<T, U, V, W, X, Y>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction<T, U, V, W, X, Y>
        {
            readonly TLambda lambda;

            public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5)
            {
                lambda.Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction<T, U, V, W, X, Y>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public struct ValueAction<T, U, V, W, X, Y, Z>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
        where Z : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IAction<T, U, V, W, X, Y, Z>
        {
            readonly TLambda lambda;

            public void Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6)
            {
                lambda.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda)
            where TLambda : struct, IAction<T, U, V, W, X, Y, Z>
        {
            return new Struct<TLambda>(lambda);
        }
    }
}
