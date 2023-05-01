using System;
using System.Collections.Generic;
using System.IO;
using ThomasJepp.StarLancer;
using ThomasJepp.StarLancer.Mission;

namespace MissionParser
{
    class Program
    {
        static string VisualiseFlags(TableFlags flags)
        {
            var flagsSet = new List<string>();
            
            if (flags.HasFlag(TableFlags.Unknown1))
            {
                flagsSet.Add("Unknown1");
            }
            
            if (flags.HasFlag(TableFlags.Unknown2))
            {
                flagsSet.Add("Unknown2");
            }
            
            if (flags.HasFlag(TableFlags.Unknown4))
            {
                flagsSet.Add("Unknown4");
            }
            
            if (flags.HasFlag(TableFlags.Unknown8))
            {
                flagsSet.Add("Unknown8");
            }

            return string.Join("+", flagsSet);
        }

        static void Main(string[] args)
        {
            var decompressor = new Decompressor();
            var file = args[0];

            using var input = File.OpenRead(file);

            if (!File.Exists(file + ".decompressed.bin"))
            {
                // decompress and dump debug output
                using var decompressedOutput = File.Create(file + ".decompressed.bin");
                decompressor.Decompress(input, decompressedOutput);
                input.Seek(0, SeekOrigin.Begin);
            }

            var mission = new MissionFile(input);

            using var output = File.Create(Path.Combine(@"D:\Games\Starlancer\MISSIONS", Path.GetFileName(file)));
            mission.OriginalData.Seek(0, SeekOrigin.Begin);
            mission.OriginalData.CopyTo(output);

            output.Seek(mission.MissionHeader.MissionObjects.Offset, SeekOrigin.Begin);
            for (int i = 0; i < mission.MissionObjects.Length; i++)
            {
                var missionObject = mission.MissionObjects[i];
                if (missionObject.LaunchedFrom == 0x0D)
                {
                    missionObject.LaunchedFrom = 0x9B;
                }

                if (missionObject.ObjectType == 0x0D)
                {
                    missionObject.ObjectType = 0x9B;
                }
                
                output.WriteStruct(missionObject);
            }
        }
    }
}
