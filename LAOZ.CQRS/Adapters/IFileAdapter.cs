﻿namespace LAOZ.CQRS.Adapters
{
    public interface IFileAdapter
    {
        bool FileExists(string filePath);
        bool ReadFile(string filePath);
        bool CreateFile(string filePath);
        bool DeleteFile(string filePath);
        bool DirectoryExists(string directoryPath);
        bool CreateDirectory(string directoryPath);
        string[] ListFiles(string directoryPath);
        bool DeleteDirectory(string directoryPath);
        Task<bool> DeleteFileAsync(string filePath);
        Task<bool> FileExistsAsync(string filePath);
    }
    public interface IStream
    {
        void Write(byte[] buffer, int offset, int count);
        int Read(byte[] buffer, int offset, int count);
        void Close();
    }
}
