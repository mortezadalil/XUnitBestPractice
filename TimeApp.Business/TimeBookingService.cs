using TimeApp.Business.Gateway;

namespace TimeApp.Business
{
    public interface ITimeBookingProcessor
    {
        bool BookTime(Employee employee, DateTime date, decimal duration);
    }

    public class TimeBookingService : ITimeBookingProcessor
    {
        private readonly IBookingProcessor bookingProcessor;

        public TimeBookingService(IBookingProcessor bookingProcessor)
        {
            this.bookingProcessor = bookingProcessor;
        }

        public bool BookTime(Employee employee, DateTime date, decimal duration)
        {
            if (employee.Id <= 0)
            {
                throw new ArgumentOutOfRangeException("Employee ID cannot be less than 0");
            }

            if (date.Date > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException("Booking date cannot be greater than today");
            }

            if (duration > 9)
            {
                throw new ArgumentOutOfRangeException("You are working too hard, lets talk!");
            }

            return bookingProcessor.Create(employee.Id, date, duration);

        }
    }
}