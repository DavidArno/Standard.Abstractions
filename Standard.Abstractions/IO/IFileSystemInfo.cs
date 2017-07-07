using System;
using System.IO;
using SuccincT.Options;
using System.Runtime.Serialization;

namespace Standard.Abstractions.IO
{
    public interface IFileSystemInfo
    {
        FileAttributes Attributes { get; set; }
        DateTime CreationTime { get; set; }
        DateTime CreationTimeUtc { get; set; }
        bool Exists { get; }
        string Extension { get; }
        string FullName { get; }
        DateTime LastAccessTime { get; set; }
        DateTime LastAccessTimeUtc { get; set; }
        DateTime LastWriteTime { get; set; }
        DateTime LastWriteTimeUtc { get; set; }
        string Name { get; }
        void Delete();
        Success<Exception> TryDelete();
        void GetObjectData(SerializationInfo info, StreamingContext context);
        void Refresh();
    }
}
