using System;
using System.IO;
using System.Runtime.Serialization;
using SuccincT.Options;

namespace Standard.Abstractions.IO
{
    internal class FileSystemInfoProxy : IFileSystemInfo
    {
        private readonly FileSystemInfo _fileSystemInfo;

        internal FileSystemInfoProxy(FileSystemInfo fileSystemInfo) => _fileSystemInfo = fileSystemInfo;

        public FileAttributes Attributes
        {
            get => _fileSystemInfo.Attributes;
            set => _fileSystemInfo.Attributes = value;
        }

        public DateTime CreationTime
        {
            get => _fileSystemInfo.CreationTime;
            set => _fileSystemInfo.CreationTime = value;
        }

        public DateTime CreationTimeUtc
        {
            get => _fileSystemInfo.CreationTimeUtc;
            set => _fileSystemInfo.CreationTimeUtc = value;
        }

        public bool Exists => _fileSystemInfo.Exists;

        public string Extension => _fileSystemInfo.Extension;

        public string FullName => _fileSystemInfo.FullName;

        public DateTime LastAccessTime
        {
            get => _fileSystemInfo.LastAccessTime;
            set => _fileSystemInfo.LastAccessTime = value;
        }

        public DateTime LastAccessTimeUtc
        {
            get => _fileSystemInfo.LastAccessTimeUtc;
            set => _fileSystemInfo.LastAccessTimeUtc = value;
        }

        public DateTime LastWriteTime
        {
            get => _fileSystemInfo.LastWriteTime;
            set => _fileSystemInfo.LastWriteTime = value;
        }

        public DateTime LastWriteTimeUtc
        {
            get => _fileSystemInfo.LastWriteTimeUtc;
            set => _fileSystemInfo.LastWriteTimeUtc = value;
        }

        public string Name => _fileSystemInfo.Name;

        public void Delete() => _fileSystemInfo.Delete();

        public void GetObjectData(SerializationInfo info, StreamingContext context) =>
            _fileSystemInfo.GetObjectData(info, context);

        public void Refresh() => _fileSystemInfo.Refresh();

        public Success<Exception> TryDelete()
        {
            try
            {
                Delete();
                return new Success<Exception>();
            }
            catch (Exception e) when (e is DirectoryNotFoundException ||
                                      e is IOException)
            {
                return e;
            }
        }
    }
}
