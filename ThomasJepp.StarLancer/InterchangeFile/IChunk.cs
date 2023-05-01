using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public interface IChunk
    {
        string Type { get; }
        List<IChunk> Children { get; }

        void Save(Stream s);
    }
}
