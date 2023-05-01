using System;
using System.Runtime.InteropServices;

namespace ThomasJepp.StarLancer.Mission;

[StructLayout(LayoutKind.Explicit, Size = 12)]
public struct GlobalVariable
{
    [FieldOffset(0x00)] public int Name;
    [FieldOffset(0x04)] public uint Unknown04;
    [FieldOffset(0x08)] public uint Unknown08;
}