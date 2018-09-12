using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    class BookingHelper_OverlappingBookingExistsTests
    {
        private Booking _existingBooking;
        private Mock<IBookingRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking()
            {
                Id = 2,
                ArrivalDate = ArriveOn(14, 0, 0),
                DepartureDate = DepartOn(10, 0, 0),
                Reference = "a"
            };

            _repository = new Mock<IBookingRepository>();

            _repository.Setup(r => r.GetActiveBookings(1)).Returns(new List<Booking>
                {
                    _existingBooking

                }.AsQueryable()
            );
        }

        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {
           
            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate,days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate),
            }, _repository.Object);
            Assert.That(result, Is.Empty);

        }

        [Test]
        public void BookingStartsBeforeAndFinishesInTHeMiddleOfAnExistingBooking_ReturnExistingBookingRefrence()
        {

            var result = BookingHelper.OverlappingBookingsExist(new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.ArrivalDate),
            }, _repository.Object);
            Assert.That(result, Is.EqualTo(_existingBooking.Reference));

        }

        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }

        private DateTime After(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(days);
        }


        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }

        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
    }
}
