using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.IL2CPU.Plugs;

namespace Cosmos.IL2CPU
{
    partial class RuntimeEngine
    {
        public static uint HeapHandle = 0;
        public const uint InitialHeapSize = 4096;
        public const uint MaximumHeapSize = 10 * 1024 * InitialHeapSize; // 10 megabytes

        public static void Heap_Initialize()
        {
            throw new NotImplementedException();
        }

        [PlugMethod(Required = true)]
        public static uint Heap_AllocNewObject(uint aSize)
        {
            throw new NotImplementedException();
        }

        [PlugMethod(Required = true)]
        public static void Heap_Free(uint aObject)
        {
            throw new NotImplementedException();
        }

        [PlugMethod(Required = true)]
        public static void Heap_Shutdown()
        {
            throw new NotImplementedException();
        }
    }
}
