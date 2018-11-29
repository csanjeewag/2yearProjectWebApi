using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Department")]
    public class DepartmentController : Controller
    {

        private readonly EMSContext _context;
        private readonly DepartmentService _service;
        public DepartmentController(EMSContext context)
        {
            _context = context;
            _service = new DepartmentService(_context);
        }



        [Produces("application/json")]
        [HttpGet("getdepartment/{id}")]

        public Department GetDepartmentId(string id)
        {
            return _service.GetDepartmentById(id);

        }



        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("createdepartment")]
        public IActionResult CreateDepartment([FromBody]Department dprt)
        {

            if (_service.AddDepartment(dprt))
            {

                return Ok(dprt);
            }
            else
            {
                return BadRequest("there error");
            }
        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("updatedepartment")]
        public IActionResult UpdateDepartment([FromBody]Department dprt)
        {

            if (_service.UpdateDepartment(dprt))
            {

                return Ok(dprt);
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("getdepartments")]
        public IActionResult GetDepartments()
        {

            var res = _service.GetDepartments();

            try { return Ok(res); } catch { return BadRequest("error get departments!"); }
        }
    }
}