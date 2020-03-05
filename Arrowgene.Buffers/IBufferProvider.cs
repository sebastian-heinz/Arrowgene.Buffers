namespace Arrowgene.Buffers
{
    public interface IBufferProvider
    {
        IBuffer Provide();
        IBuffer Provide(byte[] buffer);
    }
}