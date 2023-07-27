using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _guestService;

        public GuestController(IGuestService guestService)
        {
            _guestService = guestService;
        }

        [HttpGet]
        public IActionResult GuestList()
        {
            var values = _guestService.TGetAll();
            return Ok(values);
        }

        [HttpGet("CountGuests")]
        public IActionResult CountGuests()
        {
            var guests = _guestService.TGuestCount();
            return Ok(guests);
        }

        [HttpDelete("{id}")]
        public IActionResult GuestDelete(int id)
        {
            var value = _guestService.TGetById(id);
            _guestService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult GuestAdd(Guest Guest)
        {
            _guestService.TInsert(Guest);
            return Ok();
        }

        [HttpPut]
        public IActionResult GuestUpdate(Guest Guest)
        {
            _guestService.TUpdate(Guest);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GuestGet(int id)
        {
            var value = _guestService.TGetById(id);
            return Ok(value);
        }
    }
}
