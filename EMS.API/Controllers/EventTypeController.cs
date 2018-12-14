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
    [Route("api/EventType")]
    public class EventTypeController : Controller
    {

        private readonly EMSContext _context;
        private readonly EventTypeService _service;
        public EventTypeController(EMSContext context)
        {
            _context = context;
            _service = new EventTypeService(_context);
        }


       
        [HttpPost("createEventType")]
        public IActionResult CreateEvent([FromForm]Eventtype eventtype)
        {

            if (_service.AddEventType(eventtype))
            {

                return Ok(eventtype);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }

        [HttpGet("getalleventtypes")]
        public IActionResult GetEventtypes()
        {
            try
            {

                var types = _service.GetEventtypes();
                return Ok(types);
            }
            catch
            {
                return BadRequest();
            }
            
        }
    }
}