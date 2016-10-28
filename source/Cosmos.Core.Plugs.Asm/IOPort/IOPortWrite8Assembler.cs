using Cosmos.Assembler;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm
{
    public class IOPortWrite8Assembler : AssemblerMethod
    {
        public override void AssembleNew(Cosmos.Assembler.Assembler aAssembler, object aMethodInfo)
        {
            //TODO: This is a lot of work to write to a single port.
            // We need to have some kind of inline ASM option that can
            // emit a single out instruction
            XS.Set(XSRegisters.EDX, XSRegisters.EBP, sourceDisplacement: 0x0C);
            XS.Set(XSRegisters.EAX, XSRegisters.EBP, sourceDisplacement: 0x08);
            XS.WriteToPortDX(XSRegisters.AL);
        }
    }
}
