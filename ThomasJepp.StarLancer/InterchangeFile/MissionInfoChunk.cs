using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public class MissionInfoChunk : IChunk
    {
        public List<IChunk> Children
        {
            get
            {
                return null;
            }
        }

        public string Type
        {
            get
            {
                return "MISS";
            }
        }

        public uint MissionNumber
        {
            get
            {
                return BitConverter.ToUInt32(Value, 0x00);
            }
            set
            {
                var bytes = BitConverter.GetBytes(value);
                Array.Copy(bytes, 0, Value, 0, bytes.Length);
            }
        }

        public Saves.Rank Rank
        {
            get
            {
                return (Saves.Rank)BitConverter.ToUInt32(Value, 0x24);
            }
            set
            {
                var bytes = BitConverter.GetBytes((uint)value);
                Array.Copy(bytes, 0, Value, 0x24, bytes.Length);
            }
        }

        public Saves.Level Level
        {
            get
            {
                return (Saves.Level)BitConverter.ToUInt32(Value, 0x24);
            }
            set
            {
                var bytes = BitConverter.GetBytes((uint)value);
                Array.Copy(bytes, 0, Value, 0x28, bytes.Length);
            }
        }

        public uint Kills
        {
            get
            {
                return BitConverter.ToUInt32(Value, 0x2C);
            }
            set
            {
                var bytes = BitConverter.GetBytes((uint)value);
                Array.Copy(bytes, 0, Value, 0x2C, bytes.Length);
            }
        }

        /*public Saves.MissionStatus GetMissionStatus(int slot)
        {
            switch (slot)
        }*/

        public byte[] Value { get; private set; }

        public MissionInfoChunk(Stream s)
        {
            var size = s.ReadInt32().Swap();
            Value = new byte[size];
            s.Read(Value, 0, size);

            File.WriteAllBytes("miss.bin", Value);
        }

        public void Save(Stream s)
        {
            s.WriteAsciiString(Type);
            s.WriteInt32(Value.Length.Swap());
            s.Write(Value, 0, Value.Length);
        }
    }
}
