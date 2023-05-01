using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ThomasJepp.StarLancer
{
    public static class ByteHelpers
    {
        public static T ReadStruct<T>(this byte[] buffer, int offset)
        {
            return ReadStruct<T>(buffer, offset, Marshal.SizeOf(typeof(T)));
        }

        public static T ReadStruct<T>(this byte[] buffer, int offset, int length)
        {
            var ptr = Marshal.AllocHGlobal(length);
            Marshal.Copy(buffer, offset, ptr, length);
            var structInstance = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);

            return structInstance;
        }

        public static void WriteStruct<T>(this byte[] buffer, T structToWrite, int offset)
        {
            var size = Marshal.SizeOf(typeof(T));
            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structToWrite, ptr, true);
            Marshal.Copy(ptr, buffer, offset, size);
            Marshal.FreeHGlobal(ptr);
        }
        
        public static string ReadAsciiNullTerminatedString(this byte[] buffer, int offset)
        {
            var sb = new StringBuilder();
            while (offset < buffer.Length)
            {
                var c = (char)buffer[offset];
                if (c == 0)
                    break;
                else
                    sb.Append(c);

                offset++;
            }

            return sb.ToString();
        }
    }
}