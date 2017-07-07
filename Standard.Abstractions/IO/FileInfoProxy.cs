using System;
using System.IO;
using System.Runtime.Serialization;
using System.Security;
using SuccincT.Options;

namespace Standard.Abstractions.IO
{
    internal class FileInfoProxy : IFileInfo
    {
        private readonly FileInfo _fileInfo;

        internal FileInfoProxy(FileInfo fileInfo) => _fileInfo = fileInfo;

        public FileAttributes Attributes
        {
            get => _fileInfo.Attributes;
            set => _fileInfo.Attributes = value;
        }

        public DateTime CreationTime
        {
            get => _fileInfo.CreationTime;
            set => _fileInfo.CreationTime = value;
        }

        public DateTime CreationTimeUtc
        {
            get => _fileInfo.CreationTimeUtc;
            set => _fileInfo.CreationTimeUtc = value;
        }

        public bool Exists => _fileInfo.Exists;

        public string Extension => _fileInfo.Extension;

        public string FullName => _fileInfo.FullName;

        public DateTime LastAccessTime
        {
            get => _fileInfo.LastAccessTime;
            set => _fileInfo.LastAccessTime = value;
        }

        public DateTime LastAccessTimeUtc
        {
            get => _fileInfo.LastAccessTimeUtc;
            set => _fileInfo.LastAccessTimeUtc = value;
        }

        public DateTime LastWriteTime
        {
            get => _fileInfo.LastWriteTime;
            set => _fileInfo.LastWriteTime = value;
        }

        public DateTime LastWriteTimeUtc
        {
            get => _fileInfo.LastWriteTimeUtc;
            set => _fileInfo.LastWriteTimeUtc = value;
        }

        public string Name => _fileInfo.Name;

        public void Delete() => _fileInfo.Delete();

        public Success<Exception> TryDelete()
        {
            try
            {
                Delete();
                return new Success<Exception>();
            }
            catch (Exception e) when (e is UnauthorizedAccessException ||
                                      e is IOException ||
                                      e is SecurityException)
            {
                return e;
            }
        }

        public IDirectoryInfo Directory => new DirectoryInfoProxy(_fileInfo.Directory);

        public string DirectoryName => _fileInfo.DirectoryName;

        public bool IsReadOnly
        {
            get => _fileInfo.IsReadOnly;
            set => _fileInfo.IsReadOnly = value;
        }

        public long Length => _fileInfo.Length;

        public StreamWriter AppendText() => _fileInfo.AppendText();

        public IFileInfo CopyTo(string destFileName) => new FileInfoProxy(_fileInfo.CopyTo(destFileName));

        public IFileInfo CopyTo(string destFileName, bool overwrite) =>
            new FileInfoProxy(_fileInfo.CopyTo(destFileName, overwrite));

        public Stream Create() => _fileInfo.Create();

        public StreamWriter CreateText() => _fileInfo.CreateText();

        public void Decrypt() => _fileInfo.Decrypt();
        public void Encrypt() => _fileInfo.Encrypt();

        public void MoveTo(string destFileName) => _fileInfo.MoveTo(destFileName);

        public Stream Open(FileMode mode) => _fileInfo.Open(mode);

        public Stream Open(FileMode mode, FileAccess access) => _fileInfo.Open(mode, access);

        public Stream Open(FileMode mode, FileAccess access, FileShare share) => _fileInfo.Open(mode, access, share);

        public Stream OpenRead() => _fileInfo.OpenRead();

        public StreamReader OpenText() => _fileInfo.OpenText();

        public Stream OpenWrite() => _fileInfo.OpenWrite();

        public IFileInfo Replace(string destinationFileName, string destinationBackupFileName) =>
            new FileInfoProxy(_fileInfo.Replace(destinationFileName, destinationBackupFileName));

        public IFileInfo Replace(string destinationFileName, 
                                 string destinationBackupFileName, 
                                 bool ignoreMetadataErrors) =>
            new FileInfoProxy(_fileInfo.Replace(destinationFileName, 
                                                destinationBackupFileName,
                                                ignoreMetadataErrors));

        public void GetObjectData(SerializationInfo info, StreamingContext context) =>
            _fileInfo.GetObjectData(info, context);

        public void Refresh() => _fileInfo.Refresh();
    }
}
