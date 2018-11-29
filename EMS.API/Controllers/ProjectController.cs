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
    [Route("api/Project")]
    public class ProjectController : Controller
    {

        private readonly EMSContext _context;
        private readonly ProjectService _service;
        public ProjectController(EMSContext context)
        {
            _context = context;
            _service = new ProjectService(_context);
        }



       
        [HttpPost("createproject")]
        public IActionResult CreateProject([FromForm]Project project)
        {

            if (_service.AddProject(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }


       
        [HttpPost("updateproject")]
        public IActionResult UpdateProject([FromForm]Project project)
        {

            if (_service.UpdateProject(project))
            {

                return Ok();
            }
            else
            {
                return BadRequest("there error");
            }
        }

        
        [HttpGet("getprojects")]
        public IActionResult GetProject()
        {

            var res = _service.GetProject();

            try { return Ok(res); } catch { return BadRequest("error get project!"); }
        }

        [HttpGet("getproject/{id}")]
        public IActionResult GetProject(string id)
        {

            var res = _service.GetProject(id);

            try { return Ok(res); } catch { return BadRequest("error get project!"); }
        }

        [HttpGet("deactiveproject/{id}")]
        public IActionResult DeActive(string id)
        {
            var result= _service.DeActive(id);
            if (result) { return Ok(); }
            else { return BadRequest(); }
        }

        [HttpGet("activeproject/{id}")]
        public IActionResult Active(string id)
        {
            var result = _service.Active(id);
            if (result) { return Ok(); }
            else { return BadRequest(); }
        }
    }


}