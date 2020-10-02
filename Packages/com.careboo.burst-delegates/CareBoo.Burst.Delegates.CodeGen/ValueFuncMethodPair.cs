using Mono.Cecil;

namespace CareBoo.Burst.Delegates.CodeGen
{
    public struct ValueFuncMethodPair
    {
        public MethodDefinition MethodWithLambdas;
        public MethodDefinition MethodWithStructs;
    }
}
