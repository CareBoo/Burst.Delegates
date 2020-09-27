using System;
using System.Runtime.CompilerServices;

namespace CareBoo.Burst.Delegates
{
    public unsafe struct ValueFunc<TResult>
        where TResult : struct
    {
        public delegate TResult Lambda();

        public struct Struct<TLambda>
            where TLambda : struct, IFunc<TResult>
        {
            readonly TLambda lambda;

            public TResult Invoke()
            {
                return lambda.Invoke();
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> CreateStruct<TLambda>(TLambda lambda)
            where TLambda : struct, IFunc<TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public unsafe struct ValueFunc<T, TResult>
        where T : struct
        where TResult : struct
    {
        public delegate TResult Lambda(T arg0);

        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, TResult>
        {
            readonly TLambda lambda;

            public TResult Invoke(T arg0)
            {
                return lambda.Invoke(arg0);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> CreateStruct<TLambda>(TLambda lambda)
            where TLambda : struct, IFunc<T, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public unsafe struct ValueFunc<T, U, TResult>
        where T : struct
        where U : struct
        where TResult : struct
    {
        public delegate TResult Lambda(T arg0, U arg1);

        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, TResult>
        {
            readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1)
            {
                return lambda.Invoke(arg0, arg1);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> CreateStruct<TLambda>(TLambda lambda)
            where TLambda : struct, IFunc<T, U, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }

    public unsafe struct ValueFunc<T, U, V, TResult>
        where T : struct
        where U : struct
        where V : struct
        where TResult : struct
    {
        public delegate TResult Lambda(T arg0, U arg1, V arg2);

        public struct Struct<TLambda>
            where TLambda : struct, IFunc<T, U, V, TResult>
        {
            readonly TLambda lambda;

            public TResult Invoke(T arg0, U arg1, V arg2)
            {
                return lambda.Invoke(arg0, arg1, arg2);
            }

            internal Struct(TLambda lambda)
            {
                this.lambda = lambda;
            }
        }

        public static Struct<TLambda> CreateStruct<TLambda>(TLambda lambda)
            where TLambda : struct, IFunc<T, U, V, TResult>
        {
            return new Struct<TLambda>(lambda);
        }
    }
}