﻿
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    //[TestClass]
    [TestFixture]
    public class ReservationTests
    {
        //[TestMethod]
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //  Arrange
            var reservation = new Reservation();

            //   Act 
           var result = reservation.CanBeCancelledBy(new User { IsAdmin = true});


            //   Assert
            //Assert.IsTrue(result);
            Assert.That(result, Is.True);

        }

        [Test]

        public void CanCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            var user = new User();

            //Arrange
            var reservation = new Reservation { MadeBy = user};

            //Act
            var result = reservation.CanBeCancelledBy(user);


            //Assert
            Assert.IsTrue(result);

        }


        [Test] 

        public void CanCancelledBy_AnotherUserCanceling_ReturnsFalse()
        {

            var reservation = new Reservation { MadeBy = new User() };

            var result = reservation.CanBeCancelledBy(new User());

            Assert.IsFalse(result);




        }


    }
}
