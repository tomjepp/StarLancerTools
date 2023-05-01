using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using ThomasJepp.StarLancer;

namespace ShipDataParser
{
    class ShpObject
    {
        public string Name { get; set; }

        public void Deserialize(Stream input)
        {
            input.Seek(0x02, SeekOrigin.Begin);
            var nameOffset = input.ReadUInt16();

            input.Seek(12 + nameOffset, SeekOrigin.Begin);
            Name = input.ReadAsciiNullTerminatedString();
        }
    }

    class Program
    {
        static ShpObject ParseShp(string file)
        {
            using (Stream input = File.OpenRead(file))
            {
                var shp = new ShpObject();
                shp.Deserialize(input);
                return shp;
            }
        }

        static void Main(string[] args)
        {
            var files = Directory.GetFiles(@"D:\starlancer\resource", "*.dec.shp");

            foreach (var file in files)
            {
                var shp = ParseShp(file);
                Console.WriteLine("{0}: {1}", file, shp.Name);
            }

            Console.ReadLine();
        }
    }
}
