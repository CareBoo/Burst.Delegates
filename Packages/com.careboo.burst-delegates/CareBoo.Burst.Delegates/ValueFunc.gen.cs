


//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CareBoo.Burst.Delegates
{

    public struct ValueFunc<TResult>
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke()
            {
                return lambda.Invoke();
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


    public struct ValueFunc<T, TResult>
        where T : struct
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke(T arg0)
            {
                return lambda.Invoke(arg0);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<T, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


    public struct ValueFunc<T, U, TResult>
        where T : struct
        where U : struct
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1)
            {
                return lambda.Invoke(arg0, arg1);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<T, U, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


    public struct ValueFunc<T, U, V, TResult>
        where T : struct
        where U : struct
        where V : struct
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, V, TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1, V arg2)
            {
                return lambda.Invoke(arg0, arg1, arg2);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<T, U, V, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


    public struct ValueFunc<T, U, V, W, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, V, W, TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1, V arg2, W arg3)
            {
                return lambda.Invoke(arg0, arg1, arg2, arg3);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<T, U, V, W, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


    public struct ValueFunc<T, U, V, W, X, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, V, W, X, TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4)
            {
                return lambda.Invoke(arg0, arg1, arg2, arg3, arg4);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<T, U, V, W, X, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


    public struct ValueFunc<T, U, V, W, X, Y, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, V, W, X, Y, TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5)
            {
                return lambda.Invoke(arg0, arg1, arg2, arg3, arg4, arg5);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<T, U, V, W, X, Y, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


    public struct ValueFunc<T, U, V, W, X, Y, Z, TResult>
        where T : struct
        where U : struct
        where V : struct
        where W : struct
        where X : struct
        where Y : struct
        where Z : struct
        where TResult : struct
    {
        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, V, W, X, Y, Z, TResult>
        {
            internal readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1, V arg2, W arg3, X arg4, Y arg5, Z arg6)
            {
                return lambda.Invoke(arg0, arg1, arg2, arg3, arg4, arg5, arg6);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> New<TLambda>(TLambda lambda = default)
            where TLambda : struct, IFunc<T, U, V, W, X, Y, Z, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }


}