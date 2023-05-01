using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThomasJepp.StarLancer;

namespace Decompress
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                Console.WriteLine("{0}", arg);
                var bytes = File.ReadAllBytes(arg);
                var outputPath = Path.ChangeExtension(arg, ".dec" + Path.GetExtension(arg));

                try
                {
                    using (var input = new MemoryStream(bytes))
                    {
                        using (var output = new MemoryStream())
                        {
                            var dec = new Decompressor();
                            dec.Decompress(input, output);
                            File.WriteAllBytes(outputPath, output.ToArray());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("skipped");
                }
            }
            Console.WriteLine("Done");
        }
    }
}
