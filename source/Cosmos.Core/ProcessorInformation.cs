using System;
using Cosmos.IL2CPU.Plugs;

namespace Cosmos.Core
{
    public unsafe class ProcessorInformation
    {
        /* The following three int*-pointers are needed for the lea instruction due to the following reason:
 *      When comiling, the IL-code will be translated into x86-ASM, which has specific and unique names for local variables.
 *      To access these local variables, I have to pass their excat name to the instruction in question. This is rather
 *      difficult with reflection, if these variables reside in the local function scope. For this reason, I move the
 *      pointer to class scope to access them quicker and more easily
 */
        private static int* __cyclesrdtscptr, __raterdmsrptr, __vendortargetptr;
        private static long __ticktate = -1;

        /// <summary>
        /// Returns the Processor's vendor name
        /// </summary>
        /// <returns>CPU Vendor name</returns>
        public static string GetVendorName()
        {
            if (CanReadCPUID() > 0)
            {
                int[] raw = new int[3];

                fixed (int* ptr = raw)
                    FetchCPUVendor(ptr);

                return new string(new char[] {
                    (char)(raw[0] >> 24),
                    (char)((raw[0] >> 16) & 0xff),
                    (char)((raw[0] >> 8) & 0xff),
                    (char)(raw[0] & 0xff),
                    (char)(raw[1] >> 24),
                    (char)((raw[1] >> 16) & 0xff),
                    (char)((raw[1] >> 8) & 0xff),
                    (char)(raw[1] & 0xff),
                    (char)(raw[2] >> 24),
                    (char)((raw[2] >> 16) & 0xff),
                    (char)((raw[2] >> 8) & 0xff),
                    (char)(raw[2] & 0xff),
                });
            }
            else
                return "\0";
        }

        /// <summary>
        /// Returns the number of CPU cycles since startup
        /// </summary>
        /// <returns>Number of CPU cycles</returns>
        public static long GetCycleCount()
        {
            int[] val = new int[2];

            fixed (int* ptr = val)
                __cyclesrdtsc(ptr);

            return ((long)val[0] << 32) | (uint)val[1];
        }

        /// <summary>
        /// Returns the CPU cycle rate (in cycles/µs)
        /// </summary>
        /// <returns>CPU cycle rate</returns>
        public static long GetCycleRate()
        {
            if (__ticktate == -1)
            {
                int[] raw = new int[4];

                fixed (int* ptr = raw)
                    __raterdmsr(ptr);

                ulong l1 = (ulong)__maxrate();
                ulong l2 = ((ulong)raw[0] << 32) | (uint)raw[1];
                ulong l3 = ((ulong)raw[2] << 32) | (uint)raw[3];

                __ticktate = (long)l2; // (long)((double)l1 * l3 / l2);
            }

            return __ticktate;
        }

        /// <summary>
        /// Copies the maximum cpu rate set by the bios at startup to the given int pointer
        /// </summary>
        [PlugMethod(AssemblerName = "ProcessorInformationMaxRate")]
        private static int __maxrate()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copies the cycle count to the given int pointer
        /// </summary>
        [PlugMethod(AssemblerName = "ProcessorInformationCyclesRdtsc")]
        private static void __cyclesrdtsc(int* target)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copies the cycle rate to the given int pointer
        /// </summary>
        [PlugMethod(AssemblerName = "ProcessorInformationRateRdmsr")]
        private static void __raterdmsr(int* target)
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "ProcessorInformationFetchCPUVendor")]
        internal static void FetchCPUVendor(int* target)
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "ProcessorInformationCanReadCPUID")]
        internal static int CanReadCPUID()
        {
            throw new NotImplementedException();
        }
    }
}
