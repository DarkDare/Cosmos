using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Debug.Kernel;
using Cosmos.TestRunner;
using Sys = Cosmos.System;

namespace Cosmos.Compiler.Tests.NetCore
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully. Starting BCL tests now please wait...");
        }

        protected override void Run()
        {
            try
            {
                mDebugger.Send("Run");
                TestController.Completed();
            }
            catch (Exception e)
            {
                mDebugger.Send("Exception occurred: " + e.Message);
                mDebugger.Send(e.Message);
                Console.WriteLine("Exception occurred");
                Console.WriteLine(e.Message);
                TestController.Failed();
            }
        }
    }
}
