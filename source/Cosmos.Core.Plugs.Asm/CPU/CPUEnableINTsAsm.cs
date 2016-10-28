using Cosmos.Assembler;
using XSharp.Compiler;

namespace Cosmos.Core.Plugs.Asm.Assemblers.CPU
{
    public class CPUEnableINTsAsm : AssemblerMethod
    {
        public override void AssembleNew(Cosmos.Assembler.Assembler aAssembler, object aMethodInfo)
        {
            XS.EnableInterrupts();
        }
    }
}
