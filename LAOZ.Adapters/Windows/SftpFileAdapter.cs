using LAOZ.CQRS.Adapters;
using Renci.SshNet;

namespace LAOZ.CQRS.Infrastructure.Adapters
{
    /// <summary>
    /// Sftp file adapter.
    /// </summary>
    public class SftpFileAdapter : IFileAdapter
    {
        private readonly string host;
        private readonly string username;
        private readonly string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:LAOZ.CQRS.Infrastructure.Adapters.SftpFileAdapter"/> class.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public SftpFileAdapter(string host, string username, string password)
        {
            this.host = host;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// File exists.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool FileExists(string filePath)
        {
            using (var sftp = CreateSftpClient())
            {
                return sftp.Exists(filePath);
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ReadFile(string filePath)
        {
            var sftp = CreateSftpClient();
            var stream = new MemoryStream();

            try
            {
                sftp.DownloadFile(filePath, stream);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sftp.Disconnect();
            }

        }

        /// <summary>
        /// Creates the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool CreateFile(string filePath)
        {
            var sftp = CreateSftpClient();
            var stream = new MemoryStream();

            try
            {
                sftp.UploadFile(stream, filePath);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                sftp.Disconnect();
            }
        }

        /// <summary>
        /// Delete the file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool DeleteFile(string filePath)
        {
            using (var sftp = CreateSftpClient())
            {
                try
                {
                    sftp.DeleteFile(filePath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Directory exists.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public bool DirectoryExists(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                return sftp.Exists(directoryPath);
            }
        }

        /// <summary>
        /// Creates the directory.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public bool CreateDirectory(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                try
                {
                    sftp.CreateDirectory(directoryPath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// List the files.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public string[] ListFiles(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                var files = sftp.ListDirectory(directoryPath);
                return files.Where(f => !f.IsDirectory).Select(f => f.FullName).ToArray();
            }
        }

        /// <summary>
        /// List the directories.
        /// </summary>
        /// <param name="directoryPath"></param>
        /// <returns></returns>
        public bool DeleteDirectory(string directoryPath)
        {
            using (var sftp = CreateSftpClient())
            {
                try
                {
                    sftp.DeleteDirectory(directoryPath);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Creates the sftp client.
        /// </summary>
        /// <returns></returns>
        private SftpClient CreateSftpClient()
        {
            var connectionInfo = new ConnectionInfo(host, username, new PasswordAuthenticationMethod(username, password));
            var sftp = new SftpClient(connectionInfo);
            sftp.Connect();
            return sftp;
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
