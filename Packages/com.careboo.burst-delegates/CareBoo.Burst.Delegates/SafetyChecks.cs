using System;
using Unity.Burst;

namespace CareBoo.Burst.Delegates
{
    internal static class SafetyChecks
    {
        [BurstDiscard]
        public static void SupportedInBurstOnly()
        {
            throw new NotSupportedException($"Usage of BurstAction and BurstFunc is only supported in Burst-compiled code.");
        }
    }
}
