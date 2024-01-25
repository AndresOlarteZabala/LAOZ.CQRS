using LAOZ.CQRS.Adapters;

namespace LAOZ.CQRS.Infrastructure.Adapters
{
    /// <summary>
    /// File system file adapter.
    /// </summary>
    public class FileSystemFileAdapter : IFileAdapter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:LAOZ.CQRS.Infrastructure.Adapters.FileSystemFileAdapter"/> class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ReadFile(string filePath)
        {
            try
            {
                FileStream fileStream = File.OpenRead(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Creates the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool CreateFile(string filePath)
        {
            try
            {
                FileStream fileStream = File.Create(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Delete the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Directory exists.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public bool DirectoryExists(string directoryPath)
        {
            return Directory.Exists(directoryPath);
        }

        /// <summary>
        /// Creates the directory.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public bool CreateDirectory(string directoryPath)
        {
            try
            {
                Directory.CreateDirectory(directoryPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// List the files.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public string[] ListFiles(string directoryPath)
        {
            return Directory.GetFiles(directoryPath);
        }

        /// <summary>
        /// List the directories.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public bool DeleteDirectory(string directoryPath)
        {
            try
            {
                Directory.Delete(directoryPath, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #region Not Implemented
        public Task<bool> DeleteFileAsync(string filePath)
        {
            throw new NotImplementedException();
        }

        public Task<bool> FileExistsAsync(string filePath)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
