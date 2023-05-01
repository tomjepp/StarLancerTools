using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ThomasJepp.StarLancer
{
    public class Decompressor
    {
        public void Decompress(Stream input, Stream output)
        {
            var magic = input.ReadUInt16();

            if (magic != 0xFB10)
            {
                throw new Exception(String.Format("Unexpected magic value! {0:X4}", magic));
            }

            var uncompressedSize = (input.ReadUInt8() << 16) | (input.ReadUInt8() << 8) | input.ReadUInt8();

            var buffer = new byte[32768];

            while (input.Position < input.Length)
            {
                int bytesPlainText = 0, bytesToCopy = 0, copyOffset = 0;

                var control0 = input.ReadUInt8();

                if (control0 < 0x80)
                {
                    var control1 = input.ReadUInt8();

                    bytesPlainText = (control0 & 0x03);
                    bytesToCopy = ((control0 & 0x1C) >> 2) + 3;
                    copyOffset = ((control0 & 0x60) << 3) + control1 + 1;
                }
                else if (control0 >= 0x80 && control0 < 0xC0)
                {
                    var control1 = input.ReadUInt8();
                    var control2 = input.ReadUInt8();

                    bytesPlainText = ((control1 & 0xC0) >> 6) & 0x03;
                    bytesToCopy = (control0 & 0x3F) + 4;
                    copyOffset = ((control1 & 0x3F) << 8) + control2 + 1;
                }
                else if (control0 >= 0xC0 && control0 < 0xE0)
                {
                    var control1 = input.ReadUInt8();
                    var control2 = input.ReadUInt8();
                    var control3 = input.ReadUInt8();

                    bytesPlainText = control0 & 0x03;
                    bytesToCopy = ((control0 & 0x0C) << 6) + control3 + 5;
                    copyOffset = ((control0 & 0x10) << 12) + (control1 << 8) + control2 + 1;
                }
                else if (control0 >= 0xE0 && control0 < 0xFC)
                {
                    bytesPlainText = (control0 - 0xDF) * 4;
                }
                else if (control0 >= 0xFC)
                {
                    bytesPlainText = (control0 & 0x03);
                    return;
                }
                else
                {
                    throw new Exception("Impossible to reach here?");
                }

                input.Read(buffer, 0, bytesPlainText);
                output.Write(buffer, 0, bytesPlainText);

                if (bytesToCopy != 0)
                {
                    output.Seek(0 - copyOffset, SeekOrigin.End);
                    for (var i = 0; i < bytesToCopy; i++)
                    {
                        var read = output.ReadUInt8();
                        var oldPos = output.Position;
                        output.Seek(0, SeekOrigin.End);
                        output.WriteByte(read);
                        output.Position = oldPos;
                    }
                }

                output.Seek(0, SeekOrigin.End);
            }
        }
    }
}
