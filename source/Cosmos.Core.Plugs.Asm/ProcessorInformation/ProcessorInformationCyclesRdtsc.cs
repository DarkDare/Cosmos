using Cosmos.Assembler;

namespace Cosmos.Core.Plugs.Asm
{
    public class ProcessorInformationCyclesRdtsc : AssemblerMethod
    {
        public override void AssembleNew(Assembler.Assembler aAssembler, object aMethodInfo)
        {
            //TODO: Fix
            //__cyclesrdtscptr = target;

            //string intname = LabelName.GetFullName(typeof(CPUImpl).GetField(nameof(__cyclesrdtscptr)));

            //XS.Push(XSRegisters.EAX);
            //XS.Push(XSRegisters.ECX);
            //XS.Push(XSRegisters.EDX);
            //XS.Lea(XSRegisters.ESI, intname);
            //XS.Rdtsc();
            //XS.Set(XSRegisters.ESI, XSRegisters.EAX, destinationIsIndirect: true, destinationDisplacement: 4);
            //XS.Set(XSRegisters.ESI, XSRegisters.EDX, destinationIsIndirect: true);
            //XS.Push(XSRegisters.EDX);
            //XS.Push(XSRegisters.ECX);
            //XS.Push(XSRegisters.EAX);
            //XS.Return();
        }
    }
}
