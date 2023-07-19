using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult MessageCategoryDelete(int id)
        {
            var value = _messageCategoryService.TGetById(id);
            _messageCategoryService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult MessageCategoryAdd(MessageCategory MessageCategory)
        {
            _messageCategoryService.TInsert(MessageCategory);
            return Ok();
        }

        [HttpPut]
        public IActionResult MessageCategoryUpdate(MessageCategory MessageCategory)
        {
            _messageCategoryService.TUpdate(MessageCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult MessageCategoryGet(int id)
        {
            var value = _messageCategoryService.TGetById(id);
            return Ok(value);
        }
    }
}
