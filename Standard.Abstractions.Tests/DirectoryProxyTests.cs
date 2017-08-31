using NUnit.Framework;
using Standard.Abstractions.IO;
using System.Collections;
using System.IO;
using System.Linq;
using static NUnit.Framework.Assert;

namespace Standard.Abstractions.Tests
{
    [TestFixture]
    public class DirectoryProxyTests
    {
        private static readonly ISystemIO ConcreteIO = new ConcreteSystemIO();
        private static IEnumerable TestParameters()
        {
            yield return new object[] {$"{Path.GetTempPath()}/___test", ConcreteIO};
        }

        [TestCaseSource(nameof(TestParameters))]
        public void CreateDirectory_CreatesDirectory(string testPath, ISystemIO io)
        {
            io.Directory.CreateDirectory(testPath);
            var exists = Directory.Exists(testPath);
            Directory.Delete(testPath);

            IsTrue(exists);
        }

        [TestCaseSource(nameof(TestParameters))]
        public void DirectoryDelete_DeletesExistingDirectory(string testPath, ISystemIO io)
        {
            Directory.CreateDirectory(testPath);
            io.Directory.Delete(testPath);
            var exists = Directory.Exists(testPath);

            IsFalse(exists);
        }

        [TestCaseSource(nameof(TestParameters))]
        public void NonRecursiveDirectoryDelete_DeletesEmptyDirectory(string testPath, ISystemIO io)
        {
            Directory.CreateDirectory(testPath);
            io.Directory.Delete(testPath, false);

            IsFalse(Directory.Exists(testPath));
        }

        [TestCaseSource(nameof(TestParameters))]
        public void NonRecursiveDirectoryDelete_FailsToDeleteNonEmptyDirectory(string testPath, ISystemIO io)
        {
            var deletionSucceeded = true;

            Directory.CreateDirectory(testPath);
            Directory.CreateDirectory($"{testPath}/a");

            try
            {
                io.Directory.Delete(testPath, false);
            }
            catch (IOException)
            {
                deletionSucceeded = false;
            }

            var exists = Directory.Exists(testPath);
            Directory.Delete(testPath, true);

            Multiple(() =>
            {
                IsTrue(exists);
                IsFalse(deletionSucceeded);
            });
        }

        [TestCaseSource(nameof(TestParameters))]
        public void RecursiveDirectoryDelete_DeletesNonEmptyDirectory(string testPath, ISystemIO io)
        {
            Directory.CreateDirectory(testPath);
            Directory.CreateDirectory($"{testPath}/a");
            io.Directory.Delete(testPath, true);

            IsFalse(Directory.Exists(testPath));
        }

        [TestCaseSource(nameof(TestParameters))]
        public void SimpleEnumerateDirectories_ReturnsCorrectEnumeration(string testPath, ISystemIO io)
        {
            Directory.CreateDirectory(testPath);
            Directory.CreateDirectory($"{testPath}/a");
            Directory.CreateDirectory($"{testPath}/b");
            Directory.CreateDirectory($"{testPath}/c");

            var contents = io.Directory.EnumerateDirectories(testPath).ToList();
            io.Directory.Delete(testPath, true);

            Multiple(() =>
            {
                AreEqual(3, contents.Count);
                IsTrue(contents.Any(item => item.EndsWith("a")));
                IsTrue(contents.Any(item => item.EndsWith("b")));
                IsTrue(contents.Any(item => item.EndsWith("c")));
            });
        }

        [TestCaseSource(nameof(TestParameters))]
        public void FilteredEnumerateDirectories_ReturnsCorrectEnumeration(string testPath, ISystemIO io)
        {
            Directory.CreateDirectory(testPath);
            Directory.CreateDirectory($"{testPath}/a.exe");
            Directory.CreateDirectory($"{testPath}/b.txt");
            Directory.CreateDirectory($"{testPath}/c.exe");

            var contents = io.Directory.EnumerateDirectories(testPath, "*.exe").ToList();
            io.Directory.Delete(testPath, true);

            Multiple(() =>
            {
                AreEqual(2, contents.Count);
                IsTrue(contents.Any(item => item.EndsWith("a.exe")));
                IsTrue(contents.Any(item => item.EndsWith("c.exe")));
            });
        }
    }
}
