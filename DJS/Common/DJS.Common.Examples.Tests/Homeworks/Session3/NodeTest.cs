using System;
using System.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DJS.Common.Examples.Tests.Homeworks.Session3
{
    [TestClass]
    public class NodeTest
    {
       [TestMethod]
        public void ConstructorParamters()
        {
            // Arrange
            var expectedValue = 5;
            // Act
            var result = new DJSNode<int>(expectedValue);

            // Assert
            Assert.AreEqual(expectedValue,result.Value);
        }

       [TestMethod]
       public void SetNext()
       {
           // Arrange
           var expectedNext = new DJSNode<int>(6);
           var expectedValue = 5;
           var current = new DJSNode<int>(expectedValue);

           // Act
           current.Next = expectedNext;
           
           // Assert
           var result = current.Next;
           Assert.AreEqual(6,result.Value);
       }
    }

    public class DJSNode<T>
    {
        private T _value;

        public DJSNode(T input)
        {
            _value = input;
        }

        public T Value { get { return _value; } }

        public DJSNode<T> Next { get; set; }
        
    }
}
