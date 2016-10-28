using Cosmos.Assembler;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm
{
    public class ProcessorInformationProcessorInformationMaxRate : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            XS.Set(XSRegisters.EAX, 0x00000016);
            XS.Cpuid();
            XS.And(XSRegisters.EAX, 0x0000ffff);
            XS.Return();
        }
    }
}
