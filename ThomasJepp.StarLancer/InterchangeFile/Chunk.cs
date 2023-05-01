using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public static class Chunk
    {
        public static IChunk FromType(string type, Stream s)
        {
            switch (type)
            {
                case "FORM":
                    return new FormChunk(s);
                case "NAME":
                    return new NameChunk(s);
                case "MISS":
                    return new MissionInfoChunk(s);
                case "VERS":
                    return new VersionChunk(s);
                case "VARS":
                    return new VariablesChunk(s);
                case "PILO":
                    return new PilotChunk(s);
                case "ALPH":
                    return new AlphChunk(s);

                default:
                    throw new NotImplementedException(type);
            }
        }
    }
}
