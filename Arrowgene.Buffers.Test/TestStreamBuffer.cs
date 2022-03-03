using System;
using Xunit;

namespace Arrowgene.Buffers.Test;

public class TestStreamBuffer
{
    [Fact]
    public void TestDoubleBigEndian()
    {
        byte[] dBytesIn = new byte[] {0xC0, 0xEA, 0x6B, 0xAC, 0xEC, 0x00, 0x00, 0x00};
        byte[] dBytesExp = new byte[] {0xC0, 0xEA, 0x6B, 0xAC, 0xEC, 0x00, 0x00, 0x00};
        Array.Reverse(dBytesExp);
        double dExp = BitConverter.ToDouble(dBytesExp);

        StreamBuffer b = new StreamBuffer(dBytesIn);
        b.SetPositionStart();
        double dOut = b.ReadDouble(Endianness.Big);

        Assert.Equal(dExp, dOut);
    }
}