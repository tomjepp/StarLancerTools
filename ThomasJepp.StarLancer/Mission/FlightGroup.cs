using System;
using System.Runtime.InteropServices;

namespace ThomasJepp.StarLancer.Mission;

[StructLayout(LayoutKind.Explicit, Size = 20)]
public struct FlightGroup
{
    [FieldOffset(0)] public uint ObjectNumber;
    [FieldOffset(4)] public int Name;
    [FieldOffset(8)] public uint Unknown8;
    [FieldOffset(12)] public uint UnknownC;
    [FieldOffset(16)] public uint Unknown10;
}