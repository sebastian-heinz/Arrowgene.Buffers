﻿using System;
using System.Text;

namespace Arrowgene.Buffers
{
    public interface IBuffer
    {
        /// <summary>
        /// Gets the endianness for all operation without explicit endianness.
        /// </summary>
        Endianness Endianness { get; }

        /// <summary>
        /// The current buffer size.
        /// </summary>
        int Size { get; }

        /// <summary>
        /// Gets or Sets the cursor position.
        /// </summary>
        int Position { get; set; }
        
        /// <summary>
        /// Sets the data size.
        /// </summary>
        void SetSize(int size);
        
        /// <summary>
        /// Sets the default endianness to use for all operations
        /// </summary>
        void SetEndianness(Endianness endianness);
        
        /// <summary>
        /// Set the cursor to the beginning of the buffer.
        /// </summary>
        void SetPositionStart();

        /// <summary>
        /// Set the cursor to the end of the buffer.
        /// </summary>
        void SetPositionEnd();

        /// <summary>
        /// Clone this buffer from an offset till the specified length.
        /// </summary>
        IBuffer Clone(int offset, int length);

        /// <summary>
        /// Clone this buffer from start till the specified length.
        /// </summary>
        IBuffer Clone(int length);

        /// <summary>
        /// Clone this buffer from start till the specified length.
        /// </summary>
        IBuffer Clone();

        /// <summary>
        /// Returns all written bytes without affecting the position.
        /// </summary>
        byte[] GetAllBytes();

        /// <summary>
        /// Returns all written bytes from a specific offset, without affecting the position.
        /// </summary>
        byte[] GetAllBytes(int offset);
        
        /// <summary>
        /// Writes a 0x00 byte if false or 0x01 byte if true
        /// </summary>
        void WriteBool(bool value);

        void WriteByte(byte value);

        void WriteBytes(byte[] bytes);

        void WriteBytes(byte[] bytes, int srcOffset, int count);

        void WriteBytes(byte[] bytes, int srcOffset, int dstOffset, int count);

        void WriteInt16(short value);

        void WriteUInt16(ushort value);

        void WriteInt16(short value, Endianness endianness);

        void WriteUInt16(ushort value, Endianness endianness);

        void WriteInt32(int value);

        void WriteUInt32(uint value);

        void WriteInt32(int value, Endianness endianness);

        void WriteUInt32(uint value, Endianness endianness);

        void WriteInt64(long value);

        void WriteUInt64(ulong value);

        void WriteInt64(long value, Endianness endianness);

        void WriteUInt64(ulong value, Endianness endianness);

        void WriteFloat(float value);

        void WriteFloat(float value, Endianness endianness);

        void WriteDouble(double value);

        void WriteDouble(double value, Endianness endianness);

        void WriteDecimal(decimal value);

        void WriteBuffer(IBuffer value);

        void WriteBuffer(IBuffer value, int offset, int length);

        /// <summary>
        /// Reads 0x00 byte as false, everything else as true
        /// </summary>
        bool ReadBool();
        
        /// <summary>
        /// Read byte.
        /// Advances the cursor.
        /// </summary>
        byte ReadByte();

        /// <summary>
        /// Get byte at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        byte GetByte(int offset);

        /// <summary>
        /// Read bytes.
        /// Advances the cursor.
        /// </summary>
        byte[] ReadBytes(int length);

        /// <summary>
        /// Read bytes until end of stream or 0-byte.
        /// Advances the cursor.
        /// </summary>
        byte[] ReadBytesZeroTerminated();

        /// <summary>
        /// Read bytes until 0-byte or length is reached.
        /// Advances the cursor.
        /// </summary>
        byte[] ReadBytesFixedZeroTerminated(int length);

        /// <summary>
        /// Read bytes until provided termination byte or length is reached.
        /// Advances the cursor.
        /// </summary>
        byte[] ReadBytesFixedTerminated(int length, byte termination);

        /// <summary>
        /// Read bytes until provided termination byte.
        /// Advances the cursor.
        /// </summary>
        byte[] ReadBytesTerminated(byte termination);

        /// <summary>
        /// Get bytes at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        byte[] GetBytes(int offset, int length);

        /// <summary>
        /// Get Int16 at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        short GetInt16(int offset);

        short GetInt16(int offset, Endianness endianness);

        /// <summary>
        /// Get UInt16 at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        ushort GetUInt16(int offset);

        ushort GetUInt16(int offset, Endianness endianness);

        /// <summary>
        /// Read Int16.
        /// Advances the cursor.
        /// </summary>
        short ReadInt16();

        short ReadInt16(Endianness endianness);

        /// <summary>
        /// Read UInt16.
        /// Advances the cursor.
        /// </summary>
        ushort ReadUInt16();

        ushort ReadUInt16(Endianness endianness);

        /// <summary>
        /// Get Int32 at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        int GetInt32(int offset);

        int GetInt32(int offset, Endianness endianness);

        /// <summary>
        /// Get UInt32 at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        uint GetUInt32(int offset);

        uint GetUInt32(int offset, Endianness endianness);

        /// <summary>
        /// Read Int32.
        /// Doesn't advance the cursor.
        /// </summary>
        int ReadInt32();

        int ReadInt32(Endianness endianness);

        /// <summary>
        /// Read UInt32.
        /// Doesn't advance the cursor.
        /// </summary>
        uint ReadUInt32();

        uint ReadUInt32(Endianness endianness);

        /// <summary>
        /// Get Int64 at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        long GetInt64(int offset);

        long GetInt64(int offset, Endianness endianness);

        /// <summary>
        /// Get UInt64 at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        ulong GetUInt64(int offset);

        ulong GetUInt64(int offset, Endianness endianness);

        /// <summary>
        /// Read Int64.
        /// Doesn't advance the cursor.
        /// </summary>
        long ReadInt64();

        long ReadInt64(Endianness endianness);

        /// <summary>
        /// Read UInt64.
        /// Doesn't advance the cursor.
        /// </summary>
        ulong ReadUInt64();

        ulong ReadUInt64(Endianness endianness);

        /// <summary>
        /// Get Float at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        float GetFloat(int offset);

        float GetFloat(int offset, Endianness endianness);

        /// <summary>
        /// Read Float
        /// Doesn't advance the cursor.
        /// </summary>
        float ReadFloat();

        float ReadFloat(Endianness endianness);

        /// <summary>
        /// Get Double at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        double GetDouble(int offset);

        double GetDouble(int offset, Endianness endianness);

        /// <summary>
        /// Read Double
        /// Doesn't advance the cursor.
        /// </summary>
        double ReadDouble();

        double ReadDouble(Endianness endianness);

        /// <summary>
        /// Get Decimal at specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        decimal GetDecimal(int offset);

        /// <summary>
        /// Read Decimal
        /// Doesn't advance the cursor.
        /// </summary>
        decimal ReadDecimal();

        /// <summary>
        /// Get a String at specified offset with a specific length.
        /// Doesn't advance the cursor.
        /// </summary>
        string GetString(int offset, int length);

        /// <summary>
        /// Get a String at specified offset with a specific length.
        /// Doesn't advance the cursor.
        /// </summary>
        string GetString(int offset, int length, Encoding encoding);

        /// <summary>
        /// Get a String at specified offset with a specific length.
        /// Doesn't advance the cursor.
        /// </summary>
        string GetString(int offset, int length, Func<byte[], string> converter);

        /// <summary>
        /// Read a String with a specific length.
        /// Advances the cursor.
        /// </summary>
        string ReadString(int length);

        /// <summary>
        /// Read a String with a specific length.
        /// Advances the cursor.
        /// </summary>
        string ReadString(int length, Encoding encoding);

        /// <summary>
        /// Read a String with a specific length.
        /// Advances the cursor.
        /// </summary>
        string ReadString(int length, Func<byte[], string> converter);

        /// <summary>
        /// Writes a string.
        /// </summary>
        void WriteString(string value);

        /// <summary>
        /// Writes a string.
        /// </summary>   
        void WriteString(string value, Encoding encoding);

        /// <summary>
        /// Writes a string.
        /// </summary>    
        void WriteString(string value, Func<string, byte[]> converter);

        /// <summary>
        /// Reads a till a 0byte, but advances the position for the length.
        /// </summary>
        string ReadFixedString(int length);

        /// <summary>
        /// Reads a string till a 0byte, but advances the position for the length.
        /// </summary>
        string ReadFixedString(int length, Encoding encoding);

        /// <summary>
        /// Reads a string till a 0byte, but advances the position for the length.
        /// </summary>
        string ReadFixedString(int length, Func<byte[], string> converter);

        /// <summary>
        /// Writes a string and fills the remaining length with 0-bytes.
        /// </summary>
        void WriteFixedString(string value, int length);

        /// <summary>
        /// Writes a string and fills the remaining length with 0-bytes.
        /// </summary>
        void WriteFixedString(string value, int length, Encoding encoding);

        /// <summary>
        /// Writes a string and fills the remaining length with 0-bytes.
        /// </summary>
        void WriteFixedString(string value, int length, Func<string, byte[]> converter);

        /// <summary>
        /// Read till a 0byte.
        /// Advances the cursor.
        /// </summary>
        string ReadCString();

        /// <summary>
        /// Read till a 0byte.
        /// Advances the cursor.
        /// </summary>
        string ReadCString(Encoding encoding);

        /// <summary>
        /// Read till a 0byte.
        /// Advances the cursor.
        /// </summary>
        string ReadCString(Func<byte[], string> converter);

        /// <summary>
        /// Read till a 0byte starting from a specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        string GetCString(int offset);

        /// <summary>
        /// Read till a 0byte starting from a specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        string GetCString(int offset, Encoding encoding);

        /// <summary>
        /// Read till a 0byte starting from a specified offset.
        /// Doesn't advance the cursor.
        /// </summary>
        string GetCString(int offset, Func<byte[], string> converter);

        /// <summary>
        /// Write a null-terminated-string.
        /// Advances the cursor.
        /// </summary>
        void WriteCString(string value);

        /// <summary>
        /// Write a null-terminated-string.
        /// Advances the cursor.
        /// </summary>
        void WriteCString(string value, Encoding encoding);

        /// <summary>
        /// Write a null-terminated-string.
        /// Advances the cursor.
        /// </summary>
        void WriteCString(string value, Func<string, byte[]> converter);
    }
}