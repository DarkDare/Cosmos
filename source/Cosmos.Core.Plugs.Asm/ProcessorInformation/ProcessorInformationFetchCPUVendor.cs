using Cosmos.Assembler;
using Cosmos.IL2CPU.Plugs;

namespace Cosmos.Core.Plugs.Asm
{
    public class ProcessorInformationFetchCPUVendor : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            //TODO: Fix
            //__vendortargetptr = target;

            //string intname = LabelName.GetFullName(typeof(CPUImpl).GetField(nameof(__vendortargetptr)));

            //XS.Lea(XSRegisters.ESI, intname); // new Lea { DestinationReg = RegistersEnum.ESI, SourceRef = ElementReference.New(intname) };
            //XS.Cpuid();
            //XS.Set(XSRegisters.ESI, XSRegisters.EBX, destinationIsIndirect: true);
            //XS.Set(XSRegisters.ESI, XSRegisters.EDX, destinationIsIndirect: true, destinationDisplacement: 4);
            //XS.Set(XSRegisters.ESI, XSRegisters.ECX, destinationIsIndirect: true, destinationDisplacement: 8);
            //XS.Return();
        }
    }
}
