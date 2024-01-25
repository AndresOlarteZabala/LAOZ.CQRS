namespace LAOZ.CQRS.Adapters
{
    /// <summary>
    /// Interface for crypto adapters
    /// </summary>
    public interface ICryptoAdapter
    {
        /// <summary>
        /// Encrypts the specified plaintext.
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        string Encrypt(string plaintext);

        /// <summary>
        /// Decrypts the specified ciphertext.
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        string Decrypt(string ciphertext);

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] Encrypt(byte[] data);

        /// <summary>
        /// Decrypts the specified data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] Decrypt(byte[] data);

        /// <summary>
        /// Encrypts the file.
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        void EncryptFile(string inputFilePath, string outputFilePath);

        /// <summary>
        /// Decrypts the file.
        /// </summary>
        /// <param name="inputFilePath"></param>
        /// <param name="outputFilePath"></param>
        void DecryptFile(string inputFilePath, string outputFilePath);
    }

}
