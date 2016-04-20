using DJS.Common.Controllers;
using DJS.Common.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DJS.Common.Tests.Controllers
{
    [TestClass]
    public class LoggingControllerTest
    {
        [TestMethod]
        public void DefaultConstructor()
        {
            var subject = new LoggingController();

            Assert.AreEqual(Verbosity.Info, subject.Tolerance);
            Assert.IsTrue((subject.Entries.Count == 0));
        }

        [TestMethod]
        public void UpdateVerbosityUpdatesToleranceLevel()
        {
            // Arrange
            const Verbosity expected = Verbosity.Progress;
            var subject = new LoggingController();
            // Act
            subject.UpdateVerbosity(expected);
            // Assert
            Assert.AreEqual(expected, subject.Tolerance);
        }

        [TestMethod]
        public void UpdateVerbosityUpdatesToleranceLevelEvenIfPreviousWasHigher()
        {
            // Arrange
            const Verbosity expected = Verbosity.Info;
            var subject = new LoggingController();
            subject.UpdateVerbosity(Verbosity.Error);
            // Act
            subject.UpdateVerbosity(expected);
            // Assert
            Assert.AreEqual(expected, subject.Tolerance);
        }

        [TestMethod]
        public void LogAppendsMessageWithAppropriateHeaderForLevelInfo()
        {
            // Arrange
            const string expected = "[INFO]TestMessage";
            var subject = new LoggingController();
            // Act
            subject.Log(Verbosity.Info, "TestMessage");
            // Assert
            Assert.AreEqual(expected, subject.Entries.Last().Message);
        }

        [TestMethod]
        public void LogAppendsMessageWithAppropriateHeaderForLevelProgress()
        {
            // Arrange
            const string expected = "[PRGS]TestMessage";
            var subject = new LoggingController();
            // Act
            subject.Log(Verbosity.Progress, "TestMessage");
            // Assert
            Assert.AreEqual(expected, subject.Entries.Last().Message);
        }

        [TestMethod]
        public void LogAppendsMessageWithAppropriateHeaderForLevelWarn()
        {
            // Arrange
            const string expected = "[WARN]TestMessage";
            var subject = new LoggingController();
            // Act
            subject.Log(Verbosity.Warn, "TestMessage");
            // Assert
            Assert.AreEqual(expected, subject.Entries.Last().Message);
        }

        [TestMethod]
        public void LogAppendsMessageWithAppropriateHeaderForLevelError()
        {
            // Arrange
            const string expected = "[ERR]TestMessage";
            var subject = new LoggingController();
            // Act
            subject.Log(Verbosity.Error, "TestMessage");
            // Assert
            Assert.AreEqual(expected, subject.Entries.Last().Message);
        }

        [TestMethod]
        public void LogDoesNotLogAnythingBelowTolerance()
        {
            // Arrange
            var subject = new LoggingController();
            subject.UpdateVerbosity(Verbosity.Error);
            var expected = subject.Entries.Count;

            // Act
            subject.Log(Verbosity.Progress, "TestMessage");

            // Assert
            Assert.AreEqual(expected, subject.Entries.Count);
        }

    }
}
