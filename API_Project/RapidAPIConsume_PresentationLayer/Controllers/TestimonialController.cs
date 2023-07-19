using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetAll();
            return Ok(values);
        }

        [HttpDelete("{id}")]
        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonialService.TGetById(id);
            _testimonialService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult TestimonialAdd(Testimonial Testimonial)
        {
            _testimonialService.TInsert(Testimonial);
            return Ok();
        }

        [HttpPut]
        public IActionResult TestimonialUpdate(Testimonial Testimonial)
        {
            _testimonialService.TUpdate(Testimonial);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult TestimonialGet(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }
    }
}
