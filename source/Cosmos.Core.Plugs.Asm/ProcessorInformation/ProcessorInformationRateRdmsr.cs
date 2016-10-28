using Cosmos.Assembler;

namespace Cosmos.Core.Plugs.Asm
{
    public class ProcessorInformationRateRdmsr : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            //TODO: Fix
            //__raterdmsrptr = target;

            //string intname = LabelName.GetFullName(typeof(CPUImpl).GetField(nameof(__raterdmsrptr)));

            //XS.Lea(XSRegisters.ESI, intname);
            //XS.Set(XSRegisters.ECX, 0xe7);
            //XS.Rdmsr();
            //XS.Set(XSRegisters.EAX, XSRegisters.ESI, destinationIsIndirect: true, destinationDisplacement: 4);
            //XS.Set(XSRegisters.EDX, XSRegisters.ESI, destinationIsIndirect: true, destinationDisplacement: 0);
            //XS.Set(XSRegisters.ECX, 0xe8);
            //XS.Rdmsr();
            //XS.Set(XSRegisters.EAX, XSRegisters.ESI, destinationIsIndirect: true, destinationDisplacement: 12);
            //XS.Set(XSRegisters.EDX, XSRegisters.ESI, destinationIsIndirect: true, destinationDisplacement: 8);
            //XS.Xor(XSRegisters.EAX, XSRegisters.EAX); // XS.Set(XSRegisters.EAX, 0);
            //XS.Return();
        }
    }
}
