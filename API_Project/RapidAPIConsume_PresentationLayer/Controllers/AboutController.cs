using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult AboutDelete(int id)
        {
            var value = _aboutService.TGetById(id);
            _aboutService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult AboutAdd(About About)
        {
            _aboutService.TInsert(About);
            return Ok();
        }

        [HttpPut]
        public IActionResult AboutUpdate(About About)
        {
            _aboutService.TUpdate(About);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult AboutGet(int id)
        {
            var value = _aboutService.TGetById(id);
            return Ok(value);
        }
    }
}
