namespace LAOZ.CQRS.Adapters
{
    /// <summary>
    /// La interfaz IFileAdapter es responsable de la interacción con los archivos.
    /// </summary>
    public interface IFileAdapter
    {
        /// <summary>
        /// Check if the file exists.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool FileExists(string filePath);

        /// <summary>
        /// Write the buffer to the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool ReadFile(string filePath);

        /// <summary>
        /// Read the file to the buffer.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool CreateFile(string filePath);

        /// <summary>
        /// Close the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        bool DeleteFile(string filePath);

        /// <summary>
        /// Check if the directory exists.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        bool DirectoryExists(string directoryPath);

        /// <summary>
        /// Create the directory if it doesn't exist.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        bool CreateDirectory(string directoryPath);

        /// <summary>
        /// List the files in the directory.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        string[] ListFiles(string directoryPath);

        /// <summary>
        /// List the directories in the directory.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        bool DeleteDirectory(string directoryPath);

        /// <summary>
        /// Delete the directory.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<bool> DeleteFileAsync(string filePath);

        /// <summary>
        /// Check if the file exists.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<bool> FileExistsAsync(string filePath);
    }
}
