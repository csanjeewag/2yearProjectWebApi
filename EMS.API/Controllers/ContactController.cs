using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EMS.API.Ulities;
using EMS.Data.GetModels;
using EMS.Data.Models;
using EMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Contact = EMS.Data.Models.Contact;
namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/contact")]
    public class ContactController:Controller
    {
        private readonly EMSContext _context;
        private readonly ContactService _service;
        private readonly TaskInformationService _serviceinfo;

        public ContactController(EMSContext context)
        {
            _context = context;
            _service = new ContactService(_context);
            _serviceinfo = new TaskInformationService(_context);
        }

        [Produces("application/json")]
        [HttpGet("getalltypes")]
        public IActionResult GetContactTypes()
        {


            var result = _service.GetContactTypes();
            return Ok(result);


        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("addcontacttype")]
        public IActionResult AddContactType([FromBody]Contact c)
        {

            if (_service.AddContactType(c))
            {

                return Ok(c);
            }
            else
            {
                return BadRequest("error");
            }
        }

       /* [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("addcontactdetail")]
        public IActionResult AddContactDetail([FromForm]Contact c)
        {

            if (_service.AddContactDetail(c))
            {

                return Ok(c);
            }
            else
            {
                return BadRequest("error");
            }
        }*/





        /*
        /// <summary>
        /// get all contacts for given type
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("getallfortype/{id}")]
        public IEnumerable<TaskInformation> GetAllForType(int id)
        {
            return _service.GetAllForType(id);

        }

    */

    }
}
