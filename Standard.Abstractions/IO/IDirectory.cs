using System;
using System.Collections.Generic;
using System.IO;

//using System.IO;

namespace Standard.Abstractions.IO
{
    public interface IDirectory
    {
        IDirectoryInfo CreateDirectory(string path);
        void Delete(string path);
        void Delete(string path, bool recursive);
        IEnumerable<string> EnumerateDirectories(string path);
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
        IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);
        IEnumerable<string> EnumerateFiles(string path);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern);
        IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
        IEnumerable<string> EnumerateFileSystemEntries(string path);
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
        IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        bool Exists(string path);
        DateTime GetCreationTime(string path);
        DateTime GetCreationTimeUtc(string path);
        string GetCurrentDirectory();
        IEnumerable<string> GetDirectories(string path);
        IEnumerable<string> GetDirectories(string path, string searchPattern);
        IEnumerable<string> GetDirectories(string path, string searchPattern, SearchOption searchOption);
        string GetDirectoryRoot(string path);
        IEnumerable<string> GetFiles(string path);
        IEnumerable<string> GetFiles(string path, string searchPattern);
        IEnumerable<string> GetFiles(string path, string searchPattern, SearchOption searchOption);
        IEnumerable<string> GetFileSystemEntries(string path);
        IEnumerable<string> GetFileSystemEntries(string path, string searchPattern);
        IEnumerable<string> GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        DateTime GetLastAccessTime(string path);
        DateTime GetLastAccessTimeUtc(string path);
        DateTime GetLastWriteTime(string path);
        DateTime GetLastWriteTimeUtc(string path);
        IEnumerable<string> GetLogicalDrives();
        IDirectoryInfo GetParent(string path);
        void Move(string sourceDirName, string destDirName);
        void SetCreationTime(string path, DateTime creationTime);
        void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
        void SetCurrentDirectory(string path);
        void SetLastAccessTime(string path, DateTime lastAccessTime);
        void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
        void SetLastWriteTime(string path, DateTime lastWriteTime);
        void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    }
}
