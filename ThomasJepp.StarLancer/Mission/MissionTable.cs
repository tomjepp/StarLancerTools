using System;
using System.Runtime.InteropServices;

namespace ThomasJepp.StarLancer.Mission
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct MissionTable
    {
        [FieldOffset(0x00)]
        public UInt16 Size;

        [FieldOffset(0x02)]
        public TableFlags Flags;

        [FieldOffset(0x04)]
        public UInt32 Offset;
    }
}