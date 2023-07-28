using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetAll();
            return Ok(values);
        }

        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            int value = _bookingService.TBookingCount();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult BookingDelete(int id)
        {
            var value = _bookingService.TGetById(id);
            _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult BookingAdd(Booking Booking)
        {
            _bookingService.TInsert(Booking);
            return Ok();
        }

        [HttpPut]
        public IActionResult BookingUpdate(Booking Booking)
        {
            _bookingService.TUpdate(Booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult BookingGet(int id)
        {
            var value = _bookingService.TGetById(id);
            return Ok(value);
        }
    }
}
