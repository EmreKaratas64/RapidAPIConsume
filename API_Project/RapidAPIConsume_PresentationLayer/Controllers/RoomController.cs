using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_DTOLayer.DTOs.RoomDto;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
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
        public IActionResult RoomAdd(AddRoomDto addRoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var values = _mapper.Map<Room>(addRoomDto);
            _roomService.TInsert(values);
            return Ok("Başarıyla Eklendi");
        }

        [HttpPut]
        public IActionResult RoomUpdate(UpdateRoomDto updateRoomDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var values = _mapper.Map<Room>(updateRoomDto);
            _roomService.TUpdate(values);
            return Ok("Başarıyla Güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult RoomGet(int id)
        {
            var value = _roomService.TGetById(id);
            return Ok(value);
        }
    }
}
