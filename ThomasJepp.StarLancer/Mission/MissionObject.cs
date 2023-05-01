using System;
using System.Runtime.InteropServices;

namespace ThomasJepp.StarLancer.Mission;

[StructLayout(LayoutKind.Explicit, Size = 76)]
public struct MissionObject
{
    [FieldOffset(0)] public uint ObjectNumber;
    [FieldOffset(4)] public int Name;
    [FieldOffset(8)] public uint Coordinate08;
    [FieldOffset(12)] public uint Coordinate0C;
    [FieldOffset(16)] public uint Coordinate10;
    [FieldOffset(20)] public byte FlightGroup;
    [FieldOffset(21)] public byte PilotType;
    [FieldOffset(22)] public ushort Unknown16;
    [FieldOffset(24)] public ushort ObjectType;
    [FieldOffset(26)] public byte Unknown1A;
    [FieldOffset(27)] public byte Unknown1B;
    [FieldOffset(28)] public uint UnknownCoordinate1C;
    [FieldOffset(32)] public uint UnknownCoordinate20;
    [FieldOffset(36)] public uint UnknownCoordinate24;
    [FieldOffset(40)] public ushort LaunchedFrom;
    [FieldOffset(42)] public byte Unknown2A;
    [FieldOffset(43)] public byte LaunchBayNumber;
    [FieldOffset(44)] public ushort Unknown2C;
    [FieldOffset(46)] public ushort Unknown2E;
    [FieldOffset(48)] public uint Unknown30;
    [FieldOffset(52)] public uint Unknown34;
    [FieldOffset(56)] public uint Unknown38;
    [FieldOffset(60)] public uint Unknown3C;
    [FieldOffset(64)] public uint Unknown40;
    [FieldOffset(68)] public uint Unknown44;
    [FieldOffset(72)] public uint Unknown48;
}