using Cosmos.Assembler;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm
{
    public class IOPortRead16Assembler : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            XS.Set(XSRegisters.EDX, XSRegisters.EBP, sourceDisplacement: 0x08);
            XS.Set(XSRegisters.EAX, 0);
            XS.ReadFromPortDX(XSRegisters.AX);
            XS.Push(XSRegisters.EAX);
        }
    }
}
