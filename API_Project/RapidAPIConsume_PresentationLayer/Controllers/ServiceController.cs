using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult ServiceDelete(int id)
        {
            var value = _serviceService.TGetById(id);
            _serviceService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult ServiceAdd(Service Service)
        {
            _serviceService.TInsert(Service);
            return Ok();
        }

        [HttpPut]
        public IActionResult ServiceUpdate(Service Service)
        {
            _serviceService.TUpdate(Service);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ServiceGet(int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }
    }
}
