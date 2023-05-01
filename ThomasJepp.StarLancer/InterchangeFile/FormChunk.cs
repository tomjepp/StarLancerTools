using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer.InterchangeFile
{
    public class FormChunk : IChunk
    {
        public string Type
        {
            get
            {
                return "FORM";
            }
        }

        public List<IChunk> Children
        {
            get
            {
                return m_Children;
            }
        }

        public string FormType { get; private set; }

        private List<IChunk> m_Children = new List<IChunk>();

        public FormChunk(Stream s)
        {
            var size = s.ReadUInt32().Swap();
            var startOffset = s.Position;
            FormType = s.ReadAsciiString(4);

            while (s.Position < startOffset + size)
            {
                var chunkType = s.ReadAsciiString(4);
                var child = Chunk.FromType(chunkType, s);
                m_Children.Add(child);
            }
        }

        public void Save(Stream s)
        {
            using (var ms = new MemoryStream())
            {
                ms.WriteAsciiString(FormType);
                foreach (var chunk in Children)
                {
                    chunk.Save(ms);
                }

                ms.Seek(0, SeekOrigin.Begin);

                s.WriteAsciiString(Type);
                s.WriteInt32(((int)ms.Length).Swap());
                ms.CopyTo(s);
            }
        }
    }
}
