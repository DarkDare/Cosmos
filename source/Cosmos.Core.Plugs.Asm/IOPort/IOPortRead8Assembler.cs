using Cosmos.Assembler;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm
{
    public class IOPortRead8Assembler : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            XS.Set(XSRegisters.EDX, XSRegisters.EBP, sourceDisplacement: 0x08);
            //TODO: Do we need to clear rest of EAX first?
            //    MTW: technically not, as in other places, it _should_ be working with AL too..
            XS.Set(XSRegisters.EAX, 0);
            XS.ReadFromPortDX(XSRegisters.AL);
            XS.Push(XSRegisters.EAX);
        }
    }
}
