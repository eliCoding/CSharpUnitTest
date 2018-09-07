using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class FizzBuzzTest
    {

        private FizzBuzz _fizzBuzz;

        [SetUp]

        public void SetUp()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        [TestCase(15, "FizzBuzz")]
        [TestCase(9, "Fizz")]
        [TestCase(20,"Buzz")]

        public void GetOutPut_WhenCalled_ReturnString(int a , string expectedResult)
        {
            var result = _fizzBuzz.GetOutput(a);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
