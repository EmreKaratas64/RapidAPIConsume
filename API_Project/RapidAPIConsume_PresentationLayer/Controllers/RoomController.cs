using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public IActionResult RoomList()
        {
            var values = _roomService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult RoomDelete(int id)
        {
            var value = _roomService.TGetById(id);
            _roomService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult RoomAdd(Room Room)
        {
            _roomService.TInsert(Room);
            return Ok();
        }

        [HttpPut]
        public IActionResult RoomUpdate(Room Room)
        {
            _roomService.TUpdate(Room);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult RoomGet(int id)
        {
            var value = _roomService.TGetById(id);
            return Ok(value);
        }
    }
}
