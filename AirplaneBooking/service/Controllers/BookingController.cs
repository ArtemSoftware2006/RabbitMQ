using Microsoft.AspNetCore.Mvc;
using service.Models;
using service.Services;

namespace service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IMessangeProducer _messageProducer;
        private readonly ILogger<BookingController> _logger;
        
        private static readonly List<Booking> _bookings = new();
        public BookingController(IMessangeProducer messangeProducer,
            ILogger<BookingController> logger)
        {
            _messageProducer = messangeProducer;
            _logger = logger; 
        }

        [HttpPost]
        public IActionResult CreateBooking(Booking newBooking) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _bookings.Add(newBooking);
            _messageProducer.SendMessage<Booking>(newBooking);

            return Ok();

        } 

    }
}