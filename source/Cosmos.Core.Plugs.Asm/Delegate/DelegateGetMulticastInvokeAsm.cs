using System.Reflection;
using Cosmos.Assembler;
using Cosmos.IL2CPU;
using XSharp.Compiler;
using MethodInfo = System.Reflection.MethodInfo;

namespace Cosmos.Core.Plugs.Asm.Assemblers.Delegate
{
    public class DelegateGetMulticastInvokeAsm : AssemblerMethod
    {
        public override void AssembleNew(Cosmos.Assembler.Assembler aAssembler, object aMethodInfo)
        {
            var xAssembler = aAssembler;
            var xMethodInfo = (MethodInfo) aMethodInfo;
            var xDelegate = typeof(global::System.Delegate);
            var xMethod = xDelegate.GetMethod("GetInvokeMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            XS.Push(ILOp.GetMethodLabel(xMethod));
        }
    }
}
