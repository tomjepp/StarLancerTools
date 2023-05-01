using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public class AlphChunk : IChunk
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
                return "ALPH";
            }
        }

        public byte[] Value { get; private set; }

        public AlphChunk(Stream s)
        {
            var size = s.ReadInt32().Swap();
            Value = new byte[size];
            s.Read(Value, 0, size);

            File.WriteAllBytes("alph.bin", Value);
        }

        public void Save(Stream s)
        {
            s.WriteAsciiString(Type);
            s.WriteInt32(Value.Length.Swap());
            s.Write(Value, 0, Value.Length);
        }
    }
}
