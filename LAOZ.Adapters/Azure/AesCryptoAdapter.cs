using System.Security.Cryptography;
using System.Text;

namespace LAOZ.CQRS.Adapters.Azure
{
    /// <summary>
    /// Clase AesCryptoAdapter que implementa la interfaz ICryptoAdapter.
    /// Esta clase se utiliza para realizar operaciones de cifrado y descifrado utilizando el algoritmo AES.
    /// </summary>
    public class AesCryptoAdapter : ICryptoAdapter
    {
        private readonly string key;
        private readonly string iv;

         /// <summary>
        /// Constructor de la clase AesCryptoAdapter.
        /// Inicializa una nueva instancia de la clase AesCryptoAdapter.
        /// </summary>
        /// <param name="key">La clave de cifrado.</param>
        /// <param name="iv">El vector de inicialización.</param>
        public AesCryptoAdapter(string key, string iv)
        {
            this.key = key;
            this.iv = iv;
        }

        /// <summary>
        /// Encripta los datos proporcionados utilizando AES.
        /// </summary>
        /// <param name="data">Los datos a encriptar.</param>
        /// <returns>Los datos encriptados.</returns>
        public string Encrypt(string plaintext)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plaintext);
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Desencripta los datos proporcionados utilizando AES.
        /// </summary>
        /// <param name="data">Los datos a desencriptar.</param>
        /// <returns>Los datos desencriptados.</returns>
        public string Decrypt(string ciphertext)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(ciphertext)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Encripta los datos proporcionados utilizando AES.
        /// </summary>
        /// <param name="data">Los datos a encriptar.</param>
        /// <returns>Los datos encriptados.</returns>
        public byte[] Encrypt(byte[] data)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(data, 0, data.Length);
                        csEncrypt.FlushFinalBlock();

                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Desencripta los datos proporcionados utilizando AES.
        /// </summary>
        /// <param name="data">Los datos a desencriptar.</param>
        /// <returns>Los datos desencriptados.</returns>
        public byte[] Decrypt(byte[] data)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(data))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            csDecrypt.CopyTo(ms);
                            return ms.ToArray();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Encripta el archivo especificado y escribe los datos encriptados en un nuevo archivo.
        /// </summary>
        /// <param name="inputFilePath">La ruta del archivo a encriptar.</param>
        /// <param name="outputFilePath">La ruta donde se escribirá el archivo encriptado.</param>
        public void EncryptFile(string inputFilePath, string outputFilePath)
        {
            byte[] inputFileBytes = File.ReadAllBytes(inputFilePath);
            byte[] encryptedBytes = Encrypt(inputFileBytes);
            File.WriteAllBytes(outputFilePath, encryptedBytes);
        }

        /// <summary>
        /// Desencripta el archivo especificado y escribe los datos desencriptados en un nuevo archivo.
        /// </summary>
        /// <param name="inputFilePath">La ruta del archivo a desencriptar.</param>
        /// <param name="outputFilePath">La ruta donde se escribirá el archivo desencriptado.</param>
        public void DecryptFile(string inputFilePath, string outputFilePath)
        {
            byte[] inputFileBytes = File.ReadAllBytes(inputFilePath);
            byte[] decryptedBytes = Decrypt(inputFileBytes);
            File.WriteAllBytes(outputFilePath, decryptedBytes);
        }
    }
}
