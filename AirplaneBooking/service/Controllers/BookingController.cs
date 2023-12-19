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
        private readonly IStorage _storage;

        public BookingController(IMessangeProducer messangeProducer,
            ILogger<BookingController> logger,
            IStorage storage
        )
        {
            _storage = storage;
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

            _storage.AddBooking(newBooking);
            _messageProducer.SendMessage<Booking>(newBooking);

            return Ok();
        }
    }
}
