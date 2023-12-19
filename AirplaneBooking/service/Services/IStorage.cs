using service.Models;

namespace service.Services
{
    public interface IStorage
    {
        public List<Booking> GetBookings();
        public void AddBooking(Booking booking);
    }
}