﻿using Microsoft.AspNetCore.Mvc;
using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult StaffList()
        {
            var values = _staffService.TGetAll();
            return Ok(values);
        }

        [HttpGet("Last4StaffList")]
        public IActionResult Last4StaffList()
        {
            var values = _staffService.TLast4Staffs();
            return Ok(values);
        }

        [HttpGet("GetStaffCount")]
        public IActionResult GetStaffCount()
        {
            int value = _staffService.TStaffCount();
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult StaffDelete(int id)
        {
            var value = _staffService.TGetById(id);
            _staffService.TDelete(value);
            return Ok();
        }

        [HttpPost]
        public IActionResult StaffAdd(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }

        [HttpPut]
        public IActionResult StaffUpdate(Staff staff)
        {
            _staffService.TUpdate(staff);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult StaffGet(int id)
        {
            var value = _staffService.TGetById(id);
            return Ok(value);
        }
    }
}
