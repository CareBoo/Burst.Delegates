using System;
using System.Collections.Generic;

namespace CareBoo.Burst.Delegates
{
    public static class DelegateCache<T> where T : Delegate
    {
        private static Dictionary<IntPtr, T> dict;
        private static Dictionary<IntPtr, T> Dict => dict ??= new Dictionary<IntPtr, T>();

        public static T GetDelegate(IntPtr ptr) => Dict[ptr];

        public static void SetDelegate(IntPtr ptr, T d)
        {
            Dict[ptr] = d;
        }
    }
}
