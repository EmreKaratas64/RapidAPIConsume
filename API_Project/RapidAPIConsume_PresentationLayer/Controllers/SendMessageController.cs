using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessageController : ControllerBase
    {
        private readonly ISendMessageService _sendMessageService;

        public SendMessageController(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        [HttpGet]
        public IActionResult SendMessageList()
        {
            var values = _sendMessageService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult SendMessageDelete(int id)
        {
            var value = _sendMessageService.TGetById(id);
            _sendMessageService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult SendMessageAdd(SendMessage SendMessage)
        {
            _sendMessageService.TInsert(SendMessage);
            return Ok();
        }

        [HttpPut]
        public IActionResult SendMessageUpdate(SendMessage SendMessage)
        {
            _sendMessageService.TUpdate(SendMessage);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult SendMessageGet(int id)
        {
            var value = _sendMessageService.TGetById(id);
            return Ok(value);
        }
    }
}
