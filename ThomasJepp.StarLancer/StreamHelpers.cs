using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace ThomasJepp.StarLancer
{
    public static class StreamHelpers
    {
        public static byte[] ReadBytes(this Stream stream, int length)
        {
            var buffer = new byte[length];
            var read = 0;

            while (read < length)
            {
                read += stream.Read(buffer, read, length - read);
            }

            return buffer;
        }
        
        #region Struct helpers

        public static T ReadStruct<T>(this Stream stream)
        {
            return ReadStruct<T>(stream, Marshal.SizeOf(typeof(T)));
        }

        public static T ReadStruct<T>(this Stream stream, int length)
        {
            var data = ReadBytes(stream, length);
            var ptr = Marshal.AllocHGlobal(length);
            Marshal.Copy(data, 0, ptr, length);
            var structInstance = (T)Marshal.PtrToStructure(ptr, typeof(T));
            Marshal.FreeHGlobal(ptr);

            return structInstance;
        }

        public static void WriteStruct<T>(this Stream stream, T structToWrite)
        {
            var size = Marshal.SizeOf(structToWrite);
            var data = new byte[size];

            var ptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structToWrite, ptr, true);
            Marshal.Copy(ptr, data, 0, size);
            Marshal.FreeHGlobal(ptr);

            stream.Write(data, 0, data.Length);
        }
        #endregion

        #region Signed integer helpers
        public static SByte ReadInt8(this Stream stream)
        {
            return (SByte)stream.ReadByte();
        }

        public static Int16 ReadInt16(this Stream stream)
        {
            var data = ReadBytes(stream, 2);
            return BitConverter.ToInt16(data, 0);
        }

        public static Int32 ReadInt32(this Stream stream)
        {
            var data = ReadBytes(stream, 4);
            return BitConverter.ToInt32(data, 0);
        }

        public static void WriteInt8(this Stream stream, SByte value)
        {
            stream.WriteByte((byte)value);
        }

        public static void WriteInt16(this Stream stream, Int16 value)
        {
            var data = BitConverter.GetBytes(value);
            stream.Write(data, 0, 2);
        }

        public static void WriteInt32(this Stream stream, Int32 value)
        {
            var data = BitConverter.GetBytes(value);
            stream.Write(data, 0, 4);
        }
        #endregion

        #region Unsigned integer helpers
        public static Byte ReadUInt8(this Stream stream)
        {
            return (byte)stream.ReadByte();
        }

        public static UInt16 ReadUInt16(this Stream stream)
        {
            var data = ReadBytes(stream, 2);
            return BitConverter.ToUInt16(data, 0);
        }

        public static UInt32 ReadUInt32(this Stream stream)
        {
            var data = ReadBytes(stream, 4);
            return BitConverter.ToUInt32(data, 0);
        }

        public static void WriteUInt8(this Stream stream, byte value)
        {
            stream.WriteByte(value);
        }

        public static void WriteUInt16(this Stream stream, UInt16 value)
        {
            var data = BitConverter.GetBytes(value);
            stream.Write(data, 0, 2);
        }

        public static void WriteUInt32(this Stream stream, UInt32 value)
        {
            var data = BitConverter.GetBytes(value);
            stream.Write(data, 0, 4);
        }

        public static void WriteUInt64(this Stream stream, UInt64 value)
        {
            var data = BitConverter.GetBytes(value);
            stream.Write(data, 0, 8);
        }
        #endregion

        #region Float helpers

        public static float ReadFloat32(this Stream stream)
        {
            var data = ReadBytes(stream, 4);
            return BitConverter.ToSingle(data, 0);
        }
        
        public static double ReadFloat64(this Stream stream)
        {
            var data = ReadBytes(stream, 8);
            return BitConverter.ToDouble(data, 0);
        }
        #endregion

        #region String helpers
        public static char ReadChar8(this Stream stream)
        {
            return (char)stream.ReadByte();
        }

        public static char ReadChar16(this Stream stream)
        {
            return (char)stream.ReadUInt16();
        }

        public static string ReadAsciiNullTerminatedString(this Stream stream)
        {
            var sb = new StringBuilder();
            while (true)
            {
                var c = (char)stream.ReadByte();
                if (c == 0)
                    return sb.ToString();
                else
                    sb.Append(c);
            }
        }

        public static int WriteAsciiNullTerminatedString(this Stream stream, string data)
        {
            var bytes = Encoding.ASCII.GetBytes(data);
            stream.Write(bytes, 0, bytes.Length);
            stream.WriteByte(0);
            return bytes.Length + 1;
        }

        public static string ReadAsciiString(this Stream stream, int length)
        {
            var bytes = ReadBytes(stream, length);
            return Encoding.ASCII.GetString(bytes);
        }

        public static int WriteAsciiString(this Stream stream, string data)
        {
            var bytes = Encoding.ASCII.GetBytes(data);
            stream.Write(bytes, 0, bytes.Length);
            return bytes.Length;
        }
        #endregion

        #region Alignment helpers
        public static void Align(this Stream stream, uint alignment)
        {
            var position = stream.Position;
            var outBy = position % alignment;

            if (outBy == 0)
                return;
            else
            {
                var offset = alignment - outBy;
                stream.Seek(offset, SeekOrigin.Current);
            }
        }
        #endregion

        #region Boolean helpers
        public static bool ReadBoolean(this Stream stream)
        {
            return ReadBoolean(stream, 1);
        }

        public static bool ReadBoolean(this Stream stream, int length)
        {
            var data = new byte[length];
            switch (length)
            {
                case 1: return data[0] != 0;
                case 2: return BitConverter.ToUInt16(data, 0) != 0;
                case 4: return BitConverter.ToUInt32(data, 0) != 0;
            }

            throw new NotImplementedException();
        }
        #endregion

        #region StreamReader helpers
        public static char ReadChar(this StreamReader sr)
        {
            return (char)sr.Read();
        }

        public static char PeekChar(this StreamReader sr)
        {
            return (char)sr.Peek();
        }
        #endregion
    }
}