using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult ContactDelete(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult ContactAdd(Contact Contact)
        {
            _contactService.TInsert(Contact);
            return Ok();
        }

        [HttpPut]
        public IActionResult ContactUpdate(Contact Contact)
        {
            _contactService.TUpdate(Contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ContactGet(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
}
