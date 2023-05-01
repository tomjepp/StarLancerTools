using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public class InterchangeFile
    {
        protected IChunk RootChunk;

        public InterchangeFile(Stream s)
        {
            var rootChunkType = s.ReadAsciiString(4);
            RootChunk = Chunk.FromType(rootChunkType, s);
        }

        public void Save(Stream s)
        {
            RootChunk.Save(s);
        }
    }
}
