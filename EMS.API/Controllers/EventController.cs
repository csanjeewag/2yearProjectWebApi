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
    [Route("api/Event")]
    public class EventController : Controller
    {

        private readonly EMSContext _context;
        private readonly EventService _service;
        public EventController(EMSContext context)
        {
            _context = context;
            _service = new EventService(_context);
        }

        [HttpPost("addfrontpage")]
        public IActionResult AddFrontPage([FromForm]FrontPage page)
        {
            try
            {
                var test = _service.AddFrontPage(page);
                if (test) { return Ok(); }
                else { return BadRequest(); }
            }
            catch { return BadRequest(); }
        }

        [HttpGet("getfrontpage/{id}")]
        public IActionResult GetFrontPage(string id)
        {
            try {
                var test = _service.GetFrontPage(id);
                return Ok(test);
            }
            catch
            {
                return BadRequest("error");
            }
            
        }
    }
}