using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThomasJepp.StarLancer.InterchangeFile;

namespace ThomasJepp.StarLancer.Saves
{
    public class SaveFile : ThomasJepp.StarLancer.InterchangeFile.InterchangeFile
    {
        protected AlphChunk AlphChunk;
        protected FormChunk FormChunk;
        protected MissionInfoChunk MissionInfoChunk;
        protected NameChunk NameChunk;
        protected PilotChunk PilotChunk;
        protected VariablesChunk VariablesChunk;
        protected VersionChunk VersionChunk;

        public SaveFile(Stream stream) : base(stream)
        {
            FormChunk = (FormChunk)RootChunk;

            foreach (var chunk in FormChunk.Children)
            {
                switch (chunk.Type)
                {
                    case "ALPH":
                        AlphChunk = (AlphChunk)chunk;
                        break;
                    case "MISS":
                        MissionInfoChunk = (MissionInfoChunk)chunk;
                        break;
                    case "NAME":
                        NameChunk = (NameChunk)chunk;
                        break;
                    case "PILO":
                        PilotChunk = (PilotChunk)chunk;
                        break;
                    case "VARS":
                        VariablesChunk = (VariablesChunk)chunk;
                        break;
                    case "VERS":
                        VersionChunk = (VersionChunk)chunk;
                        break;
                }
            }
        }

        public string SaveName
        {
            get
            {
                return NameChunk.Value;
            }
        }
    }
}
