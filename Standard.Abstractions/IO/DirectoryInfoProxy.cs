using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using SuccincT.Options;

namespace Standard.Abstractions.IO
{
    internal class DirectoryInfoProxy : IDirectoryInfo
    {
        private readonly DirectoryInfo _directoryInfo;

        internal DirectoryInfoProxy(DirectoryInfo directoryInfo) => _directoryInfo = directoryInfo;

        public FileAttributes Attributes
        {
            get => _directoryInfo.Attributes;
            set => _directoryInfo.Attributes = value;
        }

        public DateTime CreationTime
        {
            get => _directoryInfo.CreationTime;
            set => _directoryInfo.CreationTime = value;
        }

        public DateTime CreationTimeUtc
        {
            get => _directoryInfo.CreationTimeUtc;
            set => _directoryInfo.CreationTimeUtc = value;
        }

        public bool Exists => _directoryInfo.Exists;

        public string Extension => _directoryInfo.Extension;

        public string FullName => _directoryInfo.FullName;

        public DateTime LastAccessTime
        {
            get => _directoryInfo.LastAccessTime;
            set => _directoryInfo.LastAccessTime = value;
        }

        public DateTime LastAccessTimeUtc
        {
            get => _directoryInfo.LastAccessTimeUtc;
            set => _directoryInfo.LastAccessTimeUtc = value;
        }

        public DateTime LastWriteTime
        {
            get => _directoryInfo.LastWriteTime;
            set => _directoryInfo.LastWriteTime = value;
        }

        public DateTime LastWriteTimeUtc
        {
            get => _directoryInfo.LastWriteTimeUtc;
            set => _directoryInfo.LastWriteTimeUtc = value;
        }

        public string Name => _directoryInfo.Name;

        public void Delete() => _directoryInfo.Delete();
        public Success<Exception> TryDelete()
        {
            try
            {
                Delete();
                return new Success<Exception>();
            }
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is SecurityException)
            {
                return e;
            }
        }

        public IDirectoryInfo Parent => new DirectoryInfoProxy(_directoryInfo.Parent);

        public IDirectoryInfo Root => new DirectoryInfoProxy(_directoryInfo.Root);

        public void Create() => _directoryInfo.Create();
        public Success<Exception> TryCreate()
        {
            try
            {
                Create();
                return new Success<Exception>();
            }
            catch (Exception e) when (e is IOException)
            {
                return e;
            }
        }

        public IDirectoryInfo CreateSubdirectory(string path) =>
            new DirectoryInfoProxy(_directoryInfo.CreateSubdirectory(path));

        public void Delete(bool recursive) => _directoryInfo.Delete(recursive);

        public void DeleteIfEmpty() => Delete(false);

        public void DeleteRecursively() => Delete(true);

        public Success<Exception> TryDeleteIfEmpty()
        {
            try
            {
                Delete(false);
                return new Success<Exception>();
            }
            catch (Exception e) when(e is UnauthorizedAccessException ||
                                     e is DirectoryNotFoundException ||
                                     e is IOException ||
                                     e is SecurityException)
            {
                return e;
            }
        }

        public Success<Exception> TryDeleteRecursively()
        {
            try
            {
                Delete(true);
                return new Success<Exception>();
            }
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is DirectoryNotFoundException ||
                                      e is IOException ||
                                      e is SecurityException)
            {
                return e;
            }
        }

        public IEnumerable<IDirectoryInfo> EnumerateDirectories() =>
            _directoryInfo.EnumerateDirectories().Select(subdirectoryInfo => new DirectoryInfoProxy(subdirectoryInfo));

        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern) =>
            _directoryInfo.EnumerateDirectories(searchPattern)
                          .Select(subdirectoryInfo => new DirectoryInfoProxy(subdirectoryInfo));

        public IEnumerable<IDirectoryInfo> EnumerateDirectories(string searchPattern, SearchOption searchOption) =>
            _directoryInfo.EnumerateDirectories(searchPattern, searchOption)
                          .Select(subdirectoryInfo => new DirectoryInfoProxy(subdirectoryInfo));

        public IEnumerable<IFileInfo> EnumerateFiles() =>
            _directoryInfo.EnumerateFiles().Select(fileInfo => new FileInfoProxy(fileInfo));

        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern) =>
            _directoryInfo.EnumerateFiles(searchPattern).Select(fileInfo => new FileInfoProxy(fileInfo));

        public IEnumerable<IFileInfo> EnumerateFiles(string searchPattern, SearchOption searchOption) =>
            _directoryInfo.EnumerateFiles(searchPattern, searchOption).Select(fileInfo => new FileInfoProxy(fileInfo));

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos() =>
            _directoryInfo.EnumerateFileSystemInfos().Select(fileSystemInfo => new FileSystemInfoProxy(fileSystemInfo));
        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern) =>
            _directoryInfo.EnumerateFileSystemInfos(searchPattern)
                          .Select(fileSystemInfo => new FileSystemInfoProxy(fileSystemInfo));

        public IEnumerable<IFileSystemInfo> EnumerateFileSystemInfos(string searchPattern, SearchOption searchOption) =>
            _directoryInfo.EnumerateFileSystemInfos(searchPattern, searchOption)
                          .Select(fileSystemInfo => new FileSystemInfoProxy(fileSystemInfo));

        public IEnumerable<IDirectoryInfo> GetDirectories() =>
            _directoryInfo.GetDirectories().Select(subdirectoryInfo => new DirectoryInfoProxy(subdirectoryInfo));

        public IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern) =>
            _directoryInfo.GetDirectories(searchPattern)
                          .Select(subdirectoryInfo => new DirectoryInfoProxy(subdirectoryInfo));

        public IEnumerable<IDirectoryInfo> GetDirectories(string searchPattern, SearchOption searchOption) =>
            _directoryInfo.GetDirectories(searchPattern, searchOption)
                          .Select(subdirectoryInfo => new DirectoryInfoProxy(subdirectoryInfo));

        public IEnumerable<IFileInfo> GetFiles() =>
            _directoryInfo.GetFiles().Select(fileInfo => new FileInfoProxy(fileInfo));

        public IEnumerable<IFileInfo> GetFiles(string searchPattern) =>
            _directoryInfo.GetFiles(searchPattern).Select(fileInfo => new FileInfoProxy(fileInfo));

        public IEnumerable<IFileInfo> GetFiles(string searchPattern, SearchOption searchOption) =>
            _directoryInfo.GetFiles(searchPattern, searchOption).Select(fileInfo => new FileInfoProxy(fileInfo));

        public IEnumerable<IFileSystemInfo> GetFileSystemInfos() =>
            _directoryInfo.GetFileSystemInfos().Select(fileSystemInfo => new FileSystemInfoProxy(fileSystemInfo));
        public IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern) =>
            _directoryInfo.GetFileSystemInfos(searchPattern)
                          .Select(fileSystemInfo => new FileSystemInfoProxy(fileSystemInfo));

        public IEnumerable<IFileSystemInfo> GetFileSystemInfos(string searchPattern, SearchOption searchOption) =>
            _directoryInfo.GetFileSystemInfos(searchPattern, searchOption)
                          .Select(fileSystemInfo => new FileSystemInfoProxy(fileSystemInfo));

        public void MoveTo(string destDirName) => _directoryInfo.MoveTo(destDirName);

        public void GetObjectData(SerializationInfo info, StreamingContext context) => 
            _directoryInfo.GetObjectData(info, context);

        public void Refresh() => _directoryInfo.Refresh();
    }
}
