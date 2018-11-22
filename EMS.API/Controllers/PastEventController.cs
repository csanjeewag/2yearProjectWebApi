using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/PastEvent")]
    public class PastEventController : Controller
    {
        private readonly EMSContext _context;
        private readonly PastEventService _service;
        public PastEventController(EMSContext context)
        {
            _context = context;
            _service = new PastEventService(_context);
        }

        [HttpPost("addimage")]
        public IActionResult AddImage([FromForm]GetEventImage image)
        {
            try
            {
                string result = "";
                if (image.Image != null)
                {
                    result = AddFiles.AddImage(image.Image, image.EventId);

                }
                EventImages eventimage = new EventImages();
                eventimage.ImageId = result;
                eventimage.EventId = image.EventId;
                eventimage.Caption = image.Caption;
                eventimage.Description = image.Description;
                eventimage.Author = image.Author;

                var test = _service.AddImage(eventimage);
                if (test) { return Ok(); }
                else { return BadRequest(); }
                
            }
            catch
            {
                return BadRequest();
            }

        }

        [HttpGet("getimages/{id}")]
        public IActionResult GetImages(string id)
        {
            try {
                var text = _service.GetImages(id);
                return Ok(text);
            }
            catch { return BadRequest(); }
            
        }
    }
}