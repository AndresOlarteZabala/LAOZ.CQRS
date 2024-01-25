namespace LAOZ.Adapters
{
    /// <summary>
    /// La interfaz IStream es responsable de la interacción con los streams.
    /// </summary>
    public interface IStream
    {
        /// <summary>
        /// Write the buffer to the stream.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        void Write(byte[] buffer, int offset, int count);

        /// <summary>
        /// Read the stream to the buffer.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int Read(byte[] buffer, int offset, int count);

        /// <summary>
        /// Close the stream.
        /// </summary>
        void Close();
    }
}
