using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public struct ValueFuncMethodPair
    {
        public MethodDefinition MethodWithLambdas { get; private set; }

        public MethodDefinition MethodWithStructs { get; private set; }

        public ValueFuncMethodPair(MethodDefinition methodWithLambdas, MethodDefinition methodWithStructs)
        {
            MethodWithLambdas = methodWithLambdas;
            MethodWithStructs = methodWithStructs;
        }
    }
}
