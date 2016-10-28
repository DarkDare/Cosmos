using Cosmos.Assembler;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm
{
    public class IOPortWrite32Assembler : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            XS.Set(XSRegisters.EDX, XSRegisters.EBP, sourceDisplacement: 0x0C);
            XS.Set(XSRegisters.EAX, XSRegisters.EBP, sourceDisplacement: 0x08);
            XS.WriteToPortDX(XSRegisters.EAX);
        }
    }
}
