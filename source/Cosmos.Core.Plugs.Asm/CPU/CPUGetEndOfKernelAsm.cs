﻿using Cosmos.Assembler;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm.Assemblers.CPU
{
    public class CPUGetEndOfKernelAsm : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            XS.Push("_end_code");
        }
    }
}
