using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public class VersionChunk : IChunk
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
                return "VERS";
            }
        }

        public uint Value { get; private set; }

        public VersionChunk(Stream s)
        {
            var size = s.ReadInt32().Swap();
            Value = s.ReadUInt32();
        }

        public void Save(Stream s)
        {
            s.WriteAsciiString(Type);
            s.WriteInt32(((int)4).Swap());
            s.WriteUInt32(Value);
        }
    }
}
