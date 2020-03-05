﻿using System.IO;

namespace Arrowgene.Buffers
{
    public class StreamBuffer : Buffer
    {
        private readonly MemoryStream _memoryStream;
        private readonly BinaryWriter _binaryWriter;
        private readonly BinaryReader _binaryReader;

        public StreamBuffer()
        {
            _memoryStream = new MemoryStream();
            _binaryReader = new BinaryReader(_memoryStream);
            _binaryWriter = new BinaryWriter(_memoryStream);
        }

        public StreamBuffer(byte[] buffer) : this()
        {
            _binaryWriter.Write(buffer);
        }

        public StreamBuffer(byte[] buffer, int index, int count) : this()
        {
            _binaryWriter.Write(buffer, index, count);
        }

        public StreamBuffer(string filePath) : this()
        {
            const int bufferSize = 1024;
            byte[] buffer = new byte[bufferSize];
            using FileStream fileStream = File.OpenRead(filePath);
            int read;
            while ((read = fileStream.Read(buffer, 0, bufferSize)) > 0)
            {
                _binaryWriter.Write(buffer, 0, read);
            }
        }

        public override int Size => (int) _memoryStream.Length;

        public override int Position
        {
            get => (int) _memoryStream.Position;
            set => _memoryStream.Position = value;
        }

        public override void SetSize(int size)
        {
            _memoryStream.SetLength(size);
        }

        public sealed override void SetPositionStart()
        {
            Position = 0;
        }

        public override void SetPositionEnd()
        {
            Position = Size;
        }

        public override IBuffer Clone(int offset, int length)
        {
            return new StreamBuffer(GetBytes(offset, length));
        }

        public override IBuffer Provide()
        {
            return new StreamBuffer();
        }

        public override IBuffer Provide(byte[] buffer)
        {
            return new StreamBuffer(buffer);
        }

        public override byte[] GetAllBytes()
        {
            return GetAllBytes(0);
        }

        public override byte[] GetAllBytes(int offset)
        {
            return GetBytes(offset, Size - offset);
        }

        public override void WriteBytes(byte[] bytes)
        {
            _binaryWriter.Write(bytes);
        }

        public override void WriteBytes(byte[] source, int srcOffset, int length)
        {
            _memoryStream.Write(source, srcOffset, length);
        }

        public override void WriteBytes(byte[] source, int srcOffset, int dstOffset, int count)
        {
            _memoryStream.Position = dstOffset;
            _memoryStream.Write(source, srcOffset, count);
        }

        public override void WriteByte(byte value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteInt16_Implementation(short value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteUInt16_Implementation(ushort value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteInt32_Implementation(int value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteUInt32_Implementation(uint value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteInt64_Implementation(long value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteUInt64_Implementation(ulong value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteFloat_Implementation(float value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteDouble_Implementation(double value)
        {
            _binaryWriter.Write(value);
        }

        public override void WriteDecimal(decimal value)
        {
            _binaryWriter.Write(value);
        }

        public override byte ReadByte()
        {
            return _binaryReader.ReadByte();
        }

        public override byte GetByte(int offset)
        {
            int position = Position;
            Position = offset;
            byte b = ReadByte();
            Position = position;
            return b;
        }

        public override byte[] ReadBytes(int length)
        {
            return _binaryReader.ReadBytes(length);
        }

        public override byte[] GetBytes(int offset, int length)
        {
            int position = Position;
            Position = offset;
            byte[] bytes = ReadBytes(length);
            Position = position;
            return bytes;
        }

        public override short GetInt16_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            short value = ReadInt16();
            Position = position;
            return value;
        }

        public override ushort GetUInt16_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            ushort value = ReadUInt16();
            Position = position;
            return value;
        }

        public override short ReadInt16_Implementation()
        {
            return _binaryReader.ReadInt16();
        }

        public override ushort ReadUInt16_Implementation()
        {
            return _binaryReader.ReadUInt16();
        }

        public override int GetInt32_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            int value = ReadInt32();
            Position = position;
            return value;
        }

        public override uint GetUInt32_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            uint value = ReadUInt32();
            Position = position;
            return value;
        }

        public override int ReadInt32_Implementation()
        {
            return _binaryReader.ReadInt32();
        }

        public override uint ReadUInt32_Implementation()
        {
            return _binaryReader.ReadUInt32();
        }

        public override long GetInt64_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            long value = ReadInt64();
            Position = position;
            return value;
        }

        public override ulong GetUInt64_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            ulong value = ReadUInt64();
            Position = position;
            return value;
        }

        public override long ReadInt64_Implementation()
        {
            return _binaryReader.ReadInt64();
        }

        public override ulong ReadUInt64_Implementation()
        {
            return _binaryReader.ReadUInt64();
        }

        public override float GetFloat_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            float value = ReadFloat();
            Position = position;
            return value;
        }

        public override float ReadFloat_Implementation()
        {
            return _binaryReader.ReadSingle();
        }

        public override double GetDouble_Implementation(int offset)
        {
            int position = Position;
            Position = offset;
            double value = ReadDouble();
            Position = position;
            return value;
        }

        public override double ReadDouble_Implementation()
        {
            return _binaryReader.ReadDouble();
        }

        public override decimal GetDecimal(int offset)
        {
            int position = Position;
            Position = offset;
            decimal value = ReadDecimal();
            Position = position;
            return value;
        }

        public override decimal ReadDecimal()
        {
            return _binaryReader.ReadDecimal();
        }
    }
}