
using System;
using System.Collections.Generic;
using System.IO;
using SuccincT.Options;

namespace Standard.Abstractions.IO
{
    public interface IDirectoryInfo : IFileSystemInfo
    {
        IDirectoryInfo Parent { get; }
        IDirectoryInfo Root { get; }
        void Create();
        Success<Exception> TryCreate();
        IDirectoryInfo CreateSubdirectory(string path);

        [Obsolete("Use DeleteIfEmpty() or DeleteRecursively() instead")]
        void Delete(bool recursive);
        void DeleteIfEmpty();
        void DeleteRecursively();
        Success<Exception> TryDeleteIfEmpty();
        Success<Exception> TryDeleteRecursively();

        IEnumerable<IDirectoryInfo> EnumerateDirectories();
        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern);
        IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption);
        IEnumerable<IFileInfo> EnumerateFiles();
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern);
        IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption);
        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos();
        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern);
        IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption);
        IEnumerable<IDirectoryInfo> GetDirectories();
        IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern);
        IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern, SearchOption searchOption);
        IEnumerable<IFileInfo> GetFiles();
        IEnumerable<IFileInfo> GetFiles(string searchPattern);
        IEnumerable<IFileInfo> GetFiles(string searchPattern, SearchOption searchOption);
        IEnumerable<IFileSystemInfo> GetFileSystemInfos();
        IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern);
        IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern, SearchOption searchOption);
        void MoveTo(string destDirName);
    }
}
