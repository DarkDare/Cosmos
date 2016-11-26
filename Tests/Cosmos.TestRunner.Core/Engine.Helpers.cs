using System;
using System.IO;
using System.Linq;
using Cosmos.Build.Common;
using Cosmos.Build.MSBuild;
using Cosmos.IL2CPU;
using IL2CPU;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;
using Microsoft.Win32;

namespace Cosmos.TestRunner.Core
{
    partial class Engine
    {
        private void RunProcess(string fileName, string workingDirectory, string[] arguments)
        {
            if (arguments == null)
            {
                throw new ArgumentNullException("arguments");
            }
            var xArgsString = arguments.Aggregate("", (a, b) => a + " \"" + b + "\"");
            var xResult = BaseToolTask.ExecuteTool(workingDirectory, fileName, xArgsString, "IL2CPU", OutputHandler.LogError, OutputHandler.LogMessage);
            if (!xResult)
            {
                throw new Exception("Error running process!");
            }
        }

        private void RunExtractMapFromElfFile(string workingDir, string kernelFileName)
        {
            ExtractMapFromElfFile.RunObjDump(CosmosPaths.Build, workingDir, kernelFileName, OutputHandler.LogError, OutputHandler.LogMessage);
        }

        private void RunIL2CPU(string kernelFileName, string outputFile)
        {
            string xPath = @"C:\Users\Charles\Dropbox\Development\Cosmos\Tests\Cosmos.Compiler.Tests.NetCore\bin\Debug\";

            var xArguments = new[]
                             {
                                 "DebugEnabled:true",
                                 "StackCorruptionDetectionEnabled:" + EnableStackCorruptionChecks,
                                 "StackCorruptionDetectionLevel:" + StackCorruptionChecksLevel,
                                 "DebugMode:Source",
                                 "TraceAssemblies:" + TraceAssembliesLevel,
                                 "DebugCom:1",
                                 "UseNAsm:True",
                                 "OutputFilename:" + outputFile,
                                 "EnableLogging:True",
                                 "EmitDebugSymbols:True",
                                 "IgnoreDebugStubAttribute:False",
                                 "References:" + kernelFileName,
                                 "References:" + Path.Combine(xPath, "Cosmos.Core.Plugs.dll"),
                                 "References:" + Path.Combine(xPath, "Cosmos.Core.Plugs.Asm.dll"),
                                 "References:" + Path.Combine(xPath, "Cosmos.Debug.Kernel.Plugs.Asm.dll"),
                                 "References:" + Path.Combine(xPath, "Cosmos.IL2CPU.Plugs.dll"),
                                 "References:" + Path.Combine(xPath, "Cosmos.System.Plugs.dll"),
@"References:C:\Users\Charles\.nuget\packages\Microsoft.Win32.Primitives\4.3.0\ref\netstandard1.3\Microsoft.Win32.Primitives.dll",
@"References:C:\Users\Charles\.nuget\packages\System.AppContext\4.3.0\ref\netstandard1.6\System.AppContext.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Collections.Concurrent\4.3.0\ref\netstandard1.3\System.Collections.Concurrent.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Collections\4.3.0\ref\netstandard1.3\System.Collections.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Console\4.3.0\ref\netstandard1.3\System.Console.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Diagnostics.Debug\4.3.0\ref\netstandard1.3\System.Diagnostics.Debug.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Diagnostics.Tools\4.3.0\ref\netstandard1.0\System.Diagnostics.Tools.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Diagnostics.Tracing\4.3.0\ref\netstandard1.5\System.Diagnostics.Tracing.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Globalization.Calendars\4.3.0\ref\netstandard1.3\System.Globalization.Calendars.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Globalization\4.3.0\ref\netstandard1.3\System.Globalization.dll",
@"References:C:\Users\Charles\.nuget\packages\System.IO.Compression\4.3.0\ref\netstandard1.3\System.IO.Compression.dll",
@"References:C:\Users\Charles\.nuget\packages\System.IO.Compression.ZipFile\4.3.0\ref\netstandard1.3\System.IO.Compression.ZipFile.dll",
@"References:C:\Users\Charles\.nuget\packages\System.IO\4.3.0\ref\netstandard1.5\System.IO.dll",
@"References:C:\Users\Charles\.nuget\packages\System.IO.FileSystem\4.3.0\ref\netstandard1.3\System.IO.FileSystem.dll",
@"References:C:\Users\Charles\.nuget\packages\System.IO.FileSystem.Primitives\4.3.0\ref\netstandard1.3\System.IO.FileSystem.Primitives.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Linq\4.3.0\ref\netstandard1.6\System.Linq.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Linq.Expressions\4.3.0\ref\netstandard1.6\System.Linq.Expressions.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Net.Http\4.3.0\ref\netstandard1.3\System.Net.Http.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Net.Primitives\4.3.0\ref\netstandard1.3\System.Net.Primitives.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Net.Sockets\4.3.0\ref\netstandard1.3\System.Net.Sockets.dll",
@"References:C:\Users\Charles\.nuget\packages\System.ObjectModel\4.3.0\ref\netstandard1.3\System.ObjectModel.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Reflection\4.3.0\ref\netstandard1.5\System.Reflection.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Reflection.Extensions\4.3.0\ref\netstandard1.0\System.Reflection.Extensions.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Reflection.Primitives\4.3.0\ref\netstandard1.0\System.Reflection.Primitives.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Resources.ResourceManager\4.3.0\ref\netstandard1.0\System.Resources.ResourceManager.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Runtime\4.3.0\ref\netstandard1.5\System.Runtime.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Runtime.Extensions\4.3.0\ref\netstandard1.5\System.Runtime.Extensions.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Runtime.Handles\4.3.0\ref\netstandard1.3\System.Runtime.Handles.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Runtime.InteropServices\4.3.0\ref\netstandard1.5\System.Runtime.InteropServices.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Runtime.InteropServices.RuntimeInformation\4.3.0\ref\netstandard1.1\System.Runtime.InteropServices.RuntimeInformation.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Runtime.Numerics\4.3.0\ref\netstandard1.1\System.Runtime.Numerics.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Security.Cryptography.Algorithms\4.3.0\ref\netstandard1.6\System.Security.Cryptography.Algorithms.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Security.Cryptography.Encoding\4.3.0\ref\netstandard1.3\System.Security.Cryptography.Encoding.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Security.Cryptography.Primitives\4.3.0\ref\netstandard1.3\System.Security.Cryptography.Primitives.dll" ,
@"References:C:\Users\Charles\.nuget\packages\System.Security.Cryptography.X509Certificates\4.3.0\ref\netstandard1.4\System.Security.Cryptography.X509Certificates.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Text.Encoding\4.3.0\ref\netstandard1.3\System.Text.Encoding.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Text.Encoding.Extensions\4.3.0\ref\netstandard1.3\System.Text.Encoding.Extensions.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Text.RegularExpressions\4.3.0\ref\netstandard1.6\System.Text.RegularExpressions.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Threading\4.3.0\ref\netstandard1.3\System.Threading.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Threading.Tasks\4.3.0\ref\netstandard1.3\System.Threading.Tasks.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Threading.Timer\4.3.0\ref\netstandard1.2\System.Threading.Timer.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Xml.ReaderWriter\4.3.0\ref\netstandard1.3\System.Xml.ReaderWriter.dll",
@"References:C:\Users\Charles\.nuget\packages\System.Xml.XDocument\4.3.0\ref\netstandard1.3\System.Xml.XDocument.dll"

                             };

            if (RunIL2CPUInProcess)
            {
                if (mKernelsToRun.Count > 1)
                {
                    throw new Exception("Cannot run multiple kernels with in-process compilation!");
                }
                // ensure we're using the referenced (= solution) version
                CosmosAssembler.ReadDebugStubFromDisk = false;
                var xResult = Program.Run(xArguments, OutputHandler.LogMessage, OutputHandler.LogError);
                if (xResult != 0)
                {
                    throw new Exception("Error running IL2CPU");
                }
            }
            else
            {
                RunProcess(typeof(Program).Assembly.Location,
                           mBaseWorkingDirectory,
                           xArguments);
            }
        }

        private void RunNasm(string inputFile, string outputFile, bool isElf)
        {
            var xNasmTask = new NAsmTask();
            xNasmTask.InputFile = inputFile;
            xNasmTask.OutputFile = outputFile;
            xNasmTask.IsELF = isElf;
            xNasmTask.ExePath = Path.Combine(GetCosmosUserkitFolder(), "build", "tools", "nasm", "nasm.exe");
            xNasmTask.LogMessage = OutputHandler.LogMessage;
            xNasmTask.LogError = OutputHandler.LogError;
            if (!xNasmTask.Execute())
            {
                throw new Exception("Error running nasm!");
            }
        }

        private void RunLd(string inputFile, string outputFile)
        {
            RunProcess(Path.Combine(GetCosmosUserkitFolder(), "build", "tools", "cygwin", "ld.exe"),
                       mBaseWorkingDirectory,
                       new[]
                       {
                           "-Ttext", "0x2000000",
                           "-Tdata", " 0x1000000",
                           "-e", "Kernel_Start",
                           "-o",outputFile.Replace('\\', '/'),
                           inputFile.Replace('\\', '/')
                       });
        }

        private static string GetCosmosUserkitFolder()
        {
            //$([MSBuild]::GetRegistryValue("HKEY_LOCAL_MACHINE\Software\Cosmos", "UserKit"))
            using (var xReg = Registry.LocalMachine.OpenSubKey("Software\\Cosmos"))
            {
                var xResult = (xReg.GetValue("UserKit") ?? "").ToString();
                if (!Directory.Exists(xResult))
                {
                    throw new Exception("Unable to retrieve Cosmos userkit folder!");
                }
                return xResult;
            }
        }

        private void MakeIso(string objectFile, string isoFile)
        {
            IsoMaker.Generate(objectFile, isoFile);
            if (!File.Exists(isoFile))
            {
                throw new Exception("Error building iso");
            }
        }
    }
}
