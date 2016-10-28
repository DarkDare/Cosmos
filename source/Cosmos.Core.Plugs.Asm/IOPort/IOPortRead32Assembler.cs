using System;
using Cosmos.Assembler;
using Cosmos.IL2CPU.Plugs;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm
{
    public class IOPortRead32Assembler : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            XS.Set(XSRegisters.EDX, XSRegisters.EBP, sourceDisplacement: 0x08);
            XS.ReadFromPortDX(XSRegisters.EAX);
            XS.Push(XSRegisters.EAX);
        }
    }
}
