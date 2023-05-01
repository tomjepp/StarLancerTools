using System.Runtime.InteropServices;

namespace ThomasJepp.StarLancer.Mission
{
    [StructLayout(LayoutKind.Explicit, Size = 216)]
    public struct MissionHeader
    {
        [FieldOffset(0x00)]
        public MissionTable StringTable; // sub_452A20((int *)&v6, &word_5294F6, (int)v1, &dword_525FA8);
        
        [FieldOffset(0x08)]
        public MissionTable Unknown01; // sub_452A20((int *)&v6, (_WORD *)&dword_5256D0 + 1, v2, &dword_525F3C);
        
        [FieldOffset(0x10)]
        public MissionTable GlobalVariables; // // sub_452A20((int *)&v6, &word_5267BC, v2, &dword_5294F8);
        
        [FieldOffset(0x18)]
        public MissionTable MissionObjects; // sub_452A20((int *)&v6, &dword_529504, v2, &dword_52951C);
        
        [FieldOffset(0x20)]
        public MissionTable FlightGroups; // sub_452A20((int *)&v6, &dword_5267C8, v2, &dword_5267CC);
        
        [FieldOffset(0x28)]
        public MissionTable Unknown05; // sub_452A20((int *)&v6, (_WORD *)&dword_529504 + 1, v2, &dword_5294E0);
        
        [FieldOffset(0x30)]
        public MissionTable Unknown06; // sub_452A20((int *)&v6, &word_5294F4, v2, &dword_525F88);
        
        [FieldOffset(0x38)]
        public MissionTable Unknown07; // sub_452A20((int *)&v6, &word_525FAC, v2, &dword_5267C0);
        
        [FieldOffset(0x40)]
        public MissionTable Unknown08; // sub_452A20((int *)&v6, &dword_529518, v2, &dword_5267D0);
        
        [FieldOffset(0x48)]
        public MissionTable Unknown09; // sub_452A20((int *)&v6, word_525284, v2, &dword_5256C8);
        
        [FieldOffset(0x50)]
        public MissionTable Unknown10; // sub_452A20((int *)&v6, &v5, v2, &dword_5294D8);
        
        [FieldOffset(0x58)]
        public MissionTable Unknown11; // sub_452A20((int *)&v6, &v4, v2, &off_4EF2FC);
        
        [FieldOffset(0x60)]
        public MissionTable Unknown12; // sub_452A20((int *)&v6, &dword_5294F0, v2, &dword_5294FC);
        
        [FieldOffset(0x68)]
        public MissionTable Unknown13; // sub_452A20((int *)&v6, &dword_529520, v2, &dword_529500);
        
        [FieldOffset(0x70)]
        public MissionTable Unknown14; // sub_452A20((int *)&v6, &word_525F20, v2, &dword_525F18);
        
        [FieldOffset(0x78)]
        public MissionTable Unknown15; // sub_452A20((int *)&v6, &word_52527C, v2, &dword_5256B8);
        
        [FieldOffset(0x80)]
        public MissionTable Unknown16; // sub_452A20((int *)&v6, &word_5267C4, v2, &dword_525FB0);
        
        [FieldOffset(0x88)]
        public MissionTable Unknown17; // sub_452A20((int *)&v6, &word_529508, v2, &dword_5294EC);
        
        [FieldOffset(0x90)]
        public MissionTable Unknown18; // sub_452A20((int *)&v6, word_529510, v2, &dword_525FB4);
        
        [FieldOffset(0x98)]
        public MissionTable Unknown19; // sub_452A20((int *)&v6, word_5294DC, v2, &dword_52950C);
        
        [FieldOffset(0xA0)]
        public MissionTable Unknown20; // sub_452A20((int *)&v6, (_WORD *)&dword_5294F0 + 1, v2, &dword_525FA0);
        
        [FieldOffset(0xA8)]
        public MissionTable Unknown21; // sub_452A20((int *)&v6, &v4, v2, &v4);
        
        [FieldOffset(0xB0)]
        public MissionTable Unknown22; // sub_452A20((int *)&v6, word_5256D4, v2, &dword_525278);
        
        [FieldOffset(0xB8)]
        public MissionTable Unknown23; // sub_452A20((int *)&v6, &v4, v2, &off_4EE7D8);
        
        [FieldOffset(0xC0)]
        public MissionTable Unknown24; // sub_452A20((int *)&v6, &v4, v2, &dword_525F9C);
        
        [FieldOffset(0xC8)]
        public MissionTable Unknown25; // sub_452A20((int *)&v6, &v4, v2, &dword_525F90);
        
        [FieldOffset(0xD0)]
        public MissionTable Unknown26; // sub_452A20((int *)&v6, &word_5256EC, v2, &dword_52570C);

        [FieldOffset(0xD8)] [MarshalAs(UnmanagedType.ByValArray, SizeConst = 101)]
        public MissionTable[] UnusedTables;
    }
}