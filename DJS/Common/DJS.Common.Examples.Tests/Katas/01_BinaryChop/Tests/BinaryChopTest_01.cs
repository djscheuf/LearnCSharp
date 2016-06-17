using System;
using DJS.Common.Examples.Tests.Katas._01_BinaryChop.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DJS.Common.Examples.Tests.Katas._01_BinaryChop.Tests
{
    [TestClass]
    public class BinaryChopTest_01
    {
        private BinaryChop_01 _subject= new BinaryChop_01();
        
        [TestMethod]
        public void ChopReturnsMinus1ForQNotInList()
        {
            Assert.AreEqual(-1, _subject.chop(3, new int[0]));

            Assert.AreEqual(-1, _subject.chop(3, new int[1]));
        }

        [TestMethod]
       public void ChopReturnsIndexForOnlyItemIfRequested()
       {
           // Assert
            Assert.AreEqual(0, _subject.chop(1, new int[]{1}));
       }

        [TestMethod]
       public void ChopReturnsIndexForItemsFoundInLongerList()
       {
           // Arrange
            var input = new int[] {1, 3, 5};
           // Act
         
           // Assert
            Assert.AreEqual(0, _subject.chop(1, input));
            Assert.AreEqual(1, _subject.chop(3, input));
            Assert.AreEqual(2, _subject.chop(5, input));
       }

        [TestMethod]
       public void ChopReturnsMinus1ForItemNotInLongerList()
       {
           // Arrange
         var input = new int[] {1, 3, 5};
           // Act
         
           // Assert
            Assert.AreEqual(-1, _subject.chop(0, input));
            Assert.AreEqual(-1, _subject.chop(6, input));
       }

        [TestMethod]
        public void ChopReturnsIndex()
        {
            // Arrange
            var input = new int[] { 1, 3, 5,7,9 };
            // Act

            // Assert
            Assert.AreEqual(0, _subject.chop(1, input));
            Assert.AreEqual(1, _subject.chop(3, input));
            Assert.AreEqual(2, _subject.chop(5, input));
            Assert.AreEqual(3, _subject.chop(7, input));
            Assert.AreEqual(4, _subject.chop(9, input));
        }

        [TestMethod]
        public void ChopReturnsIndexForNonLinearArray()
        {
            // Arrange
            var input = new int[] { 1, 2, 4, 8, 16 };
            // Act

            // Assert
            Assert.AreEqual(0, _subject.chop(1, input));
            Assert.AreEqual(1, _subject.chop(2, input));
            Assert.AreEqual(2, _subject.chop(4, input));
            Assert.AreEqual(3, _subject.chop(8, input));
            Assert.AreEqual(4, _subject.chop(16, input));
            Assert.AreEqual(-1, _subject.chop(0, input));
            Assert.AreEqual(-1, _subject.chop(32, input));
        }
    }
}
