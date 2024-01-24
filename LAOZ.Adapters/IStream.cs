namespace LAOZ.Adapters
{
    public interface IStream
    {
        void Write(byte[] buffer, int offset, int count);
        int Read(byte[] buffer, int offset, int count);
        void Close();
    }
}
