using System;
using System.Runtime.InteropServices;

namespace ThomasJepp.StarLancer.Mission;

[StructLayout(LayoutKind.Explicit, Size = 48)]
public struct Unknown05Data
{
    [FieldOffset(0)] public ushort Unknown00;
    [FieldOffset(2)] public ushort Unknown02;
    [FieldOffset(4)] public uint Unknown04;
    [FieldOffset(8)] public uint Unknown08;
    [FieldOffset(12)] public uint Unknown12;
    [FieldOffset(16)] public uint Unknown16;
    [FieldOffset(20)] public uint Unknown20;
    [FieldOffset(24)] public uint Unknown24;
    [FieldOffset(28)] public uint Unknown28;
    [FieldOffset(32)] public uint Unknown32;
    [FieldOffset(36)] public uint Unknown36;
    [FieldOffset(40)] public uint Unknown40;
    [FieldOffset(44)] public uint Unknown44;
}