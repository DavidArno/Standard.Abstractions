using Microsoft.VisualStudio.TestTools.UnitTesting;
using Standard.Abstractions.IO;

namespace Standard.Abstractions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Directory_CanBeCreatedAndCorrectlyShowsItExists()
        {
            var io = new ConcreteSystemIO();
            io.Directory.CreateDirectory("___test");
            Assert.IsTrue(io.Directory.Exists("___test"));
            io.Directory.Delete("___test");
        }

        [TestMethod]
        public void Directory_CanBeCreatedAndDeletedAndCorrectlyShowsItDoesntExist()
        {
            var io = new ConcreteSystemIO();
            io.Directory.CreateDirectory("___test");
            io.Directory.Delete("___test");
            Assert.IsFalse(io.Directory.Exists("___test"));
        }
    }
}
