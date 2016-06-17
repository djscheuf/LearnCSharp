using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DJS.Common.Examples.Tests.Homeworks.Session3
{
    [TestClass]
    public class LinkedListTest
    {
        [TestMethod]
        public void Constructor()
        {
            //Arrange
            //Act
            var result = new DJSLinkedList<int>();
            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AppendValidInputToEmptyList()
        {
            // Arrange
            var expectedInput = 5;
            var list = new DJSLinkedList<int>();

            // Act
            list.Add(expectedInput);

            // Assert
            Assert.AreEqual(expectedInput,list[0]);
        }

        [TestMethod]
        public void AppendValidInput()
        {
            // Arrange
            var expectedInput1 = 5;
            var expectedInput2 = 6;
            var list = new DJSLinkedList<int>();

            // Act
            list.Add(expectedInput1);
            list.Add(expectedInput2);

            // Assert
            Assert.AreEqual(expectedInput1, list[0]);
            Assert.AreEqual(expectedInput2, list[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ThrowsOutOfBoundExceptionForReadIndexNotInEmptyList()
        {
            // Arrange
            var list = new DJSLinkedList<int>();
            // Act
            var result = list[0];
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ThrowsOutOfBoundExceptionForReadIndexNotInList()
        {
            // Arrange
            var expectedValue = 5;
            var list = new DJSLinkedList<int>();
            list.Add(expectedValue);

            // Act
            var result = list[1];
            // Assert
        }
    }

    public class DJSLinkedList<T>
    {
        private DJSNode<T> _front;
        private DJSNode<T> _back;

        public DJSLinkedList()
        {
            _front = null;
            _back = null;
        }

        public void Add(T input)
        {
            var temp = new DJSNode<T>(input);
            if (_front == null)
            {
                _front = temp;
                _back = _front;
            }
            else
            {
                _back.Next = temp;
                _back = temp;
            }
        }

        public T this[int idx]
        {
            get
            {
                if(_front == null)
                    throw new IndexOutOfRangeException("List is Empty");

                var cur = _front;
                int i;
                for ( i = 0; i < idx; i++)
                {
                    if(cur.Next!=null)
                        cur = cur.Next;
                    else
                    {
                        break;
                    }
                }

                if(i!=idx)
                    throw new IndexOutOfRangeException("The list is shorter than "+idx);

                return cur.Value;
            }
        }
    }

    
}
