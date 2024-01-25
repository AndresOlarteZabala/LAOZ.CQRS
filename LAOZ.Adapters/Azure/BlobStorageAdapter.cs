using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace LAOZ.CQRS.Adapters.Azure
{
    /// <summary>
    /// Clase BlobStorageAdapter que implementa la interfaz IFileAdapter.
    /// Esta clase se utiliza para interactuar con el servicio de almacenamiento de blobs de Azure.
    /// </summary>
    public class BlobStorageAdapter : IFileAdapter
    {
        private readonly CloudBlobClient blobClient;

        /// <summary>
        /// Constructor de la clase BlobStorageAdapter.
        /// Inicializa una nueva instancia de la clase BlobStorageAdapter.
        /// </summary>
        /// <param name="connectionString">La cadena de conexión para la cuenta de almacenamiento de Azure.</param>
        /// <exception cref="ArgumentNullException">Se lanza cuando la cadena de conexión es nula o vacía.</exception>
        /// <exception cref="ArgumentException">Se lanza cuando la cadena de conexión es inválida.</exception>
         public BlobStorageAdapter(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }

            CloudStorageAccount storageAccount;
            if (CloudStorageAccount.TryParse(connectionString, out storageAccount))
            {
                blobClient = storageAccount.CreateCloudBlobClient();
            }
            else
            {
                throw new ArgumentException("Invalid storage account connection string");
            }
        }

        /// <summary>
        /// Crea un nuevo archivo en el almacenamiento de blobs de Azure de forma asíncrona.
        /// </summary>
        /// <param name="filePath">La ruta donde se creará el archivo.</param>
        /// <param name="content">El contenido del archivo como una matriz de bytes.</param>
        /// <returns>Una tarea que representa la operación de creación de archivos asíncrona.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando la ruta del archivo es nula o vacía.</exception>
        public bool FileExists(string filePath)
        {
            var blob = GetBlobReference(filePath);

            try
            {
                return blob.ExistsAsync().Result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Lee un archivo del almacenamiento de blobs de Azure de forma asíncrona.
        /// </summary>
        /// <param name="filePath">La ruta del archivo para leer.</param>
        /// <returns>El contenido del archivo como una matriz de bytes.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando el archivo no existe.</exception>
        public bool ReadFile(string filePath)
        {
            var blob = GetBlobReference(filePath);
            var stream = new MemoryStream();

            try
            {
                blob.DownloadToStreamAsync(stream);
                return stream.Length > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Lee un archivo del almacenamiento de blobs de Azure de forma asíncrona.
        /// </summary>
        /// <param name="filePath">La ruta del archivo para leer.</param>
        /// <returns>El contenido del archivo como una matriz de bytes.</returns>
        /// <exception cref="ArgumentException">Se lanza cuando el archivo no existe.</exception>
        public bool CreateFile(string filePath)
        {
            var blob = GetBlobReference(filePath);
            var stream = new MemoryStream();

            try
            {
                blob.UploadFromStreamAsync(stream);
                return stream.Length == 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Elimina un archivo de forma asíncrona en el almacenamiento de blobs de Azure si existe.
        /// </summary>
        /// <param name="filePath">La ruta del archivo para eliminar.</param>
        /// <returns>Verdadero si el archivo fue eliminado, falso en caso contrario.</returns>
        public bool DeleteFile(string filePath)
        {
            var blob = GetBlobReference(filePath);

            try
            {
                blob.DeleteAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Obtiene una referencia a un blob de bloque en el contenedor especificado.
        /// </summary>
        /// <param name="filePath">La ruta del archivo para obtener la referencia.</param>
        /// <returns>Una referencia al blob de bloque.</returns>
        private CloudBlockBlob GetBlobReference(string filePath)
        {
            var container = blobClient.GetContainerReference("your-container-name"); // Replace with your container name
            return container.GetBlockBlobReference(filePath);
        }

        /// <summary>
        /// Elimina un archivo de forma asíncrona en el almacenamiento de blobs de Azure si existe.
        /// </summary>
        /// <param name="filePath">La ruta del archivo para eliminar.</param>
        /// <returns>Verdadero si el archivo fue eliminado, falso en caso contrario.</returns>
        public async Task<bool> DeleteFileAsync(string filePath)
        {
            var blob = GetBlobReference(filePath);
            return await blob.DeleteIfExistsAsync();
        }

        /// <summary>
        /// Verifica si un archivo existe en el almacenamiento de blobs de Azure.
        /// </summary>
        /// <param name="filePath">La ruta del archivo para verificar.</param>
        /// <returns>Verdadero si el archivo existe, falso en caso contrario.</returns>
        public async Task<bool> FileExistsAsync(string filePath)
        {
            var blob = GetBlobReference(filePath);
            return await blob.ExistsAsync();
        }

        #region Not Implemented
        public bool DirectoryExists(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories, 
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }
        public bool CreateDirectory(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories, 
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }
        public string[] ListFiles(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories,
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }
        public bool DeleteDirectory(string directoryPath)
        {
            // Blob Storage doesn't have a concept of directories,
            // so consider implementing some logic based on your naming conventions.
            throw new NotImplementedException();
        }
        #endregion
    }
}
