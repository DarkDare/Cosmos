using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cosmos.IL2CPU.Plugs
{
  public static class ObjectInfo
  {
    public const int FieldDataOffset = 12;

    public enum InstanceTypeEnum : uint
    {
      NormalObject = 1,

      Array = 2,

      BoxedValueType = 3,

      StaticEmbeddedObject = 0x80000001,

      StaticEmbeddedArray = 0x80000002
    }
  }
}
