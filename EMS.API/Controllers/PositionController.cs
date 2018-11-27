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
    [Route("api/Position")]
    public class PositionController : Controller
    {
        private readonly EMSContext _context;
        private readonly PositionService _service;
        public PositionController(EMSContext context)
        {
            _context = context;
            _service = new PositionService(_context);
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("createposition")]
        public IActionResult Createposition([FromBody]Position pos)
        {

            if (_service.AddPosition(pos))
            {

                return Ok(pos);
            }
            else
            {
                return BadRequest("there error");
            }
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("updatePosition")]
        public IActionResult UpdatePosition([FromBody]Position role)
        {

            if (_service.UpdatePosition(role))
            {

                return Ok(role);
            }
            else
            {
                return BadRequest("there error");
            }
        }
        [Produces("application/json")]
        [HttpGet("getposition/{id}")]

        public Position GetPositonById(string id)
        {
            return _service.GetPositonById(id);

        }


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("getroles")]
        public IActionResult GetRoles()
        {

            var res = _service.GetRoles();

            try { return Ok(res); } catch { return BadRequest("error get roles!"); }
        }
    }
}