using DJS.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media;

namespace DJS.Common.Tests.Models
{
    [TestClass]
    public class LogEntryTest
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            var subject = new LogEntry();

            Assert.AreEqual("", subject.Message);
            Assert.AreEqual(Colors.Gray, subject.Color);
        }

        [TestMethod]
        public void ConstructorParameters()
        {
            const string expected = "TestMessage";
            var expectedColor = Colors.Blue;

            var subject = new LogEntry(expectedColor, expected);

            Assert.AreEqual(expected, subject.Message);
            Assert.AreEqual(expectedColor, subject.Color);
        }
    }
}
