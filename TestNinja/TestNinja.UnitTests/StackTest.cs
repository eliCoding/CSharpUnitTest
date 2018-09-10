using System;
using System.Collections;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{

    [TestFixture]
    class StackTest
    {
        [Test]
        public void Push_ObjectIsNull_ThrowArgumentNullException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Push(null), Throws.ArgumentNullException);

        }

        [Test]
        public void Push_ValidArg_AddTheObjectToTHeStack()
        {
            var stack = new Stack<string>();
            stack.Push(("a"));

            Assert.That(stack.Count, Is.EqualTo((1)));

        }

        [Test]

        public void Count_EmptyStack_ReturnZero()
        {
            var stack = new Stack<string>();

            Assert.That(stack.Count, Is.EqualTo(0));
        }

        [Test]
        public void Pop_EmptyStack_InvalidOperationException()

        {

            var stack = new Stack<string>();
            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);

        }


        [Test]
        public void Pop_StackWithFewObjects_ReturnsObjectOnTheTop()

        {
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");

            var result = stack.Pop();

            Assert.That(result,Is.EqualTo("C"));



        }

        [Test]
        public void Pop_StackWithFewObjects_RemoveTheObjectOnTheTop()

        {

            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");

            stack.Pop();

            Assert.That(stack.Count,Is.EqualTo(2));

        }

        [Test]
        public void Peek_EmptyStack_InvalidOperationException()
        {
            var stack = new Stack<string>();

            Assert.That(() => stack.Peek(),Throws.InvalidOperationException);

        }

        [Test]
        public void Peek_stackWithObjects_RetunObjectOnTopOftTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");

           var  result  = stack.Peek();

            Assert.That(result,Is.EqualTo("C"));

        }

        [Test]
        public void Peek_stackWithObjects_DoesNotRemoveTheObjectOnTopOftTheStack()
        {
            var stack = new Stack<string>();
            stack.Push("A");
            stack.Push("B");
            stack.Push("C");
            stack.Peek();

            Assert.That(stack.Count, Is.EqualTo(3));

        }
      
    }
}
