using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cosmos.Core.Common;
using Cosmos.IL2CPU.Plugs;

namespace Cosmos.Core.Plugs
{
    [Plug(Target = typeof(Cosmos.Core.Common.CPU))]
    public class CPUImpl
    {
        [PlugMethod(AssemblerName = "CPUUpdateIDTAsm")]
        public static void UpdateIDT(CPU aThis, bool aEnableInterruptsImmediately)
        {
            throw new NotImplementedException();
        }

        // Amount of RAM in MB's.
        // needs to be static, as Heap needs it before we can instantiate objects
        [PlugMethod(AssemblerName = "CPUGetAmountOfRAMAsm")]
        public static uint GetAmountOfRAM()
        {
            throw new NotImplementedException();
        }

        // needs to be static, as Heap needs it before we can instantiate objects
        [PlugMethod(AssemblerName = "CPUGetEndOfKernelAsm")]
        public static uint GetEndOfKernel()
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "CPUZeroFillAsm")]
        // TODO: implement this using REP STOSB and REPO STOSD
        public static void ZeroFill(uint aStartAddress, uint aLength)
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "CPUInitFloatAsm")]
        public static void InitFloat()
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "CPUInitSSEAsm")]
        public static void InitSSE()
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "CPUHaltAsm")]
        public static void Halt()
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "CPUDisableINTsAsm")]
        public static void DoDisableInterrupts()
        {
            throw new NotImplementedException();
        }

        [PlugMethod(AssemblerName = "CPUEnableINTsAsm")]
        public static void DoEnableInterrupts()
        {
            throw new NotImplementedException();
        }

    }
}
