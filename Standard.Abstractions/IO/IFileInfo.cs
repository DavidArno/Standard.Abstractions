using System.IO;

namespace Standard.Abstractions.IO
{
    public interface IFileInfo : IFileSystemInfo
    {
        IDirectoryInfo Directory { get; }
        string DirectoryName { get; }
        bool IsReadOnly { get; set; }
        long Length { get; }
        StreamWriter AppendText();
        IFileInfo CopyTo(string destFileName);
        IFileInfo CopyTo(string destFileName, bool overwrite);
        Stream Create();
        StreamWriter CreateText();
        void Decrypt();
        void Encrypt();
        void MoveTo(string destFileName);
        Stream Open(FileMode mode);
        Stream Open(FileMode mode, FileAccess access);
        Stream Open(FileMode mode, FileAccess access, FileShare share);
        Stream OpenRead();
        StreamReader OpenText();
        Stream OpenWrite();
        IFileInfo Replace(string destinationFileName, string destinationBackupFileName);
        IFileInfo Replace(string destinationFileName, string destinationBackupFileName, bool ignoreMetadataErrors);
    }
}
