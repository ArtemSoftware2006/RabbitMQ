using service.Models;

namespace service.Services
{
    public class ListStorage : IStorage
    {
        private readonly List<Booking> bookings;

        public ListStorage() {
            bookings = new List<Booking>();
        }

        public void AddBooking(Booking booking)
        {
            bookings.Add(booking);
        }

        public List<Booking> GetBookings()
        {
            return bookings;
        }
    }
}