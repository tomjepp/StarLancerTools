
using System;
using System.Collections.Generic;
using System.IO;

namespace ThomasJepp.StarLancer.Mission
{
    public class MissionFile
    {
        public MissionHeader MissionHeader { get; private set; } 

        public Dictionary<uint, object> Objects = new();
        public byte[] StringData { get; private set; }
        public GlobalVariable[] GlobalVariables { get; private set; }
        public MissionObject[] MissionObjects { get; private set; }
        public FlightGroup[] FlightGroups { get; private set; }
        
        public Unknown05Data[] Unknown05Data { get; private set; }

        public MemoryStream OriginalData { get; private set; }
        
        public MissionFile(Stream input)
        {
            var decompressed = new MemoryStream(850919);
            var decompressor = new Decompressor();
            try
            {
                decompressor.Decompress(input, decompressed);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input is already decompressed.");
                input.Seek(0, SeekOrigin.Begin);
                decompressed.Seek(0, SeekOrigin.Begin);
                input.CopyTo(decompressed);
            }
            decompressed.Seek(0, SeekOrigin.Begin);

            OriginalData = decompressed;

            MissionHeader = decompressed.ReadStruct<MissionHeader>();
            
            // read string table
            decompressed.Seek(MissionHeader.StringTable.Offset, SeekOrigin.Begin);
            StringData = decompressed.ReadBytes(MissionHeader.StringTable.Size);

            // Unknown01 - no idea

            // Unknown02 - Global variables?
            Console.WriteLine("Global Variable data:");
            GlobalVariables = new GlobalVariable[MissionHeader.GlobalVariables.Size];
            decompressed.Seek(MissionHeader.GlobalVariables.Offset, SeekOrigin.Begin);
            for (int i = 0; i < MissionHeader.GlobalVariables.Size; i++)
            {
                var data = decompressed.ReadStruct<GlobalVariable>();
                Console.WriteLine(
                    "{0}: name {1}, {2}, {3}, string: '{4}'",
                    i,
                    data.Name,
                    data.Unknown04,
                    data.Unknown08,
                    StringData.ReadAsciiNullTerminatedString(data.Name)
                );
                GlobalVariables[i] = data;
            }
            Console.WriteLine();
            
            // 03
            Console.WriteLine("Mission objects:");
            MissionObjects = new MissionObject[MissionHeader.MissionObjects.Size];
            decompressed.Seek(MissionHeader.MissionObjects.Offset, SeekOrigin.Begin);
            for (int i = 0; i < MissionHeader.MissionObjects.Size; i++)
            {
                var data = decompressed.ReadStruct<MissionObject>();
                Console.WriteLine(
                    "{0}: object number {1}, name {2}, string: '{3}', type: {4:X2}, group {5}, launched from {6:X2} bay {7}",
                    i,
                    data.ObjectNumber,
                    data.Name,
                    StringData.ReadAsciiNullTerminatedString(data.Name),
                    data.ObjectType,
                    data.FlightGroup,
                    data.LaunchedFrom,
                    data.LaunchBayNumber
                );
                MissionObjects[i] = data;
                //Objects.Add(data.ObjectNumber, data);
            }
            Console.WriteLine();
            
            // 04
            Console.WriteLine("Flight groups:");
            FlightGroups = new FlightGroup[MissionHeader.FlightGroups.Size];
            decompressed.Seek(MissionHeader.FlightGroups.Offset, SeekOrigin.Begin);
            for (int i = 0; i < MissionHeader.FlightGroups.Size; i++)
            {
                var data = decompressed.ReadStruct<FlightGroup>();
                Console.WriteLine(
                    "{0}: object number {1}, name {2}, {3}, {4}, {5} ({5:X8}), string: '{6}'",
                    i,
                    data.ObjectNumber,
                    data.Name,
                    data.Unknown8,
                    data.UnknownC,
                    data.Unknown10,
                    StringData.ReadAsciiNullTerminatedString(data.Name)
                );
                FlightGroups[i] = data;
                //Objects.Add(data.ObjectNumber, data);
            }
            Console.WriteLine();
            
            // 05
            Console.WriteLine("Unknown 05 data:");
            Unknown05Data = new Unknown05Data[MissionHeader.Unknown05.Size];
            decompressed.Seek(MissionHeader.Unknown05.Offset, SeekOrigin.Begin);
            for (int i = 0; i < MissionHeader.Unknown05.Size; i++)
            {
                var data = decompressed.ReadStruct<Unknown05Data>();
                Console.WriteLine(
                    "{0}: {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}",
                    i,
                    data.Unknown00,
                    data.Unknown02,
                    data.Unknown04,
                    data.Unknown08,
                    data.Unknown12,
                    data.Unknown16,
                    data.Unknown20,
                    data.Unknown24,
                    data.Unknown28,
                    data.Unknown32,
                    data.Unknown36,
                    data.Unknown40,
                    data.Unknown44
                );
                Unknown05Data[i] = data;
            }
            Console.WriteLine();
        }
    }
}