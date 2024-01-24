using LAOZ.Adapters;

namespace LAOZ.CQRS.Infrastructure.Adapters
{
    public class MyMemoryStream : IStream
    {
        private MemoryStream stream;
        public MemoryStream Stream { get => stream; internal set => stream = value; }

        public MyMemoryStream()
        {
            stream = new MemoryStream();
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }

        public void Close()
        {
            stream.Close();
        }
    }
}
