using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public class NameChunk : IChunk
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
                return "NAME";
            }
        }

        public string Value { get; private set; }

        public NameChunk(Stream s)
        {
            var size = s.ReadInt32().Swap();
            Value = s.ReadAsciiString(size);
        }

        public void Save(Stream s)
        {
            s.WriteAsciiString(Type);
            var bytes = Encoding.ASCII.GetBytes(Value);
            s.WriteInt32(bytes.Length.Swap());
            s.Write(bytes, 0, bytes.Length);
        }
    }
}
