using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        private readonly IWorkLocationService _workLocationService;

        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult WorkLocationDelete(int id)
        {
            var value = _workLocationService.TGetById(id);
            _workLocationService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult WorkLocationAdd(WorkLocation WorkLocation)
        {
            _workLocationService.TInsert(WorkLocation);
            return Ok();
        }

        [HttpPut]
        public IActionResult WorkLocationUpdate(WorkLocation WorkLocation)
        {
            _workLocationService.TUpdate(WorkLocation);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult WorkLocationGet(int id)
        {
            var value = _workLocationService.TGetById(id);
            return Ok(value);
        }
    }
}
