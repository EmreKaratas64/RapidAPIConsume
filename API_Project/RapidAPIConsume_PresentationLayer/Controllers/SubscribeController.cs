using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult SubscribeDelete(int id)
        {
            var value = _subscribeService.TGetById(id);
            _subscribeService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult SubscribeAdd(Subscribe Subscribe)
        {
            _subscribeService.TInsert(Subscribe);
            return Ok();
        }

        [HttpPut]
        public IActionResult SubscribeUpdate(Subscribe Subscribe)
        {
            _subscribeService.TUpdate(Subscribe);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult SubscribeGet(int id)
        {
            var value = _subscribeService.TGetById(id);
            return Ok(value);
        }
    }
}
