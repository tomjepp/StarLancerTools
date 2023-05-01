using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ThomasJepp.StarLancer;
using ThomasJepp.StarLancer.InterchangeFile;
using ThomasJepp.StarLancer.Saves;

namespace SaveUnpacker
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveFile save;

            using (Stream s = File.OpenRead(@"C:\Users\Tom\AppData\Local\VirtualStore\Program Files (x86)\Microsoft Games\StarLancer\SAVES\PLAYERGAME00.original.IFF"))
            {
                save = new SaveFile(s);
            }

            save.

            using (Stream s = File.Create(@"C:\Users\Tom\AppData\Local\VirtualStore\Program Files (x86)\Microsoft Games\StarLancer\SAVES\PLAYERGAME00.IFF"))
            {
                save.Save(s);
            }
        }
    }
}
