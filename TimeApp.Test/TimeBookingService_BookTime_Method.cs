using Moq;
using TimeApp.Business;
using TimeApp.Business.Gateway;

namespace TimeApp.Test
{

    /// <summary>
    /// 2. Test with Moq
    /// This test class is for testing business class with injection.
    /// We mock injection,Then pass it throgh service constructor.
    /// Then we test exceptions inside our service.
    /// 
    /// In last test we suppose that data service(Create) return true.
    /// It means we Moq data service with specefic return then we test BookTime Method.
    /// </summary>
    public class TimeBookingService_BookTime_Method
    {
        [Fact]
        public void Invalid_EmployeeId_ThrowException()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            var timeBookingProcessor =
                new TimeBookingService(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            timeBookingProcessor.BookTime(new Employee(), DateTime.Today, 8));
        }

        [Fact]
        public void Invalid_Date_ThrowException()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            var timeBookingProcessor =
                new TimeBookingService(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => timeBookingProcessor.BookTime(new Employee { Id = 2 }, DateTime.Today.AddDays(1), 8));
        }

        [Fact]
        public void Invalid_Duration_ThrowException()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            var timeBookingProcessor =
                new TimeBookingService(bookingProcessor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => timeBookingProcessor.BookTime(new Employee { Id = 2 }, DateTime.Today, 10));
        }


        [Fact]
        public void Valid_Arguments_Return_True()
        {
            var bookingProcessor = new Mock<IBookingProcessor>();
            bookingProcessor.Setup(p => p.Create(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<decimal>())).Returns(true);

            var timeBookingProcessor = new TimeBookingService(bookingProcessor.Object);

            Assert.True(timeBookingProcessor.BookTime(new Employee { Id = 2 }, DateTime.Today, 9));
        }
    }
    
}