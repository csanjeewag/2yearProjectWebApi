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
using TaskInformation = EMS.Data.Models.TaskInformation;


namespace EMS.API.Controllers
{

    [Produces("application/json")]
    [Route("api/taskinfo")]

    public class TaskInformationController:Controller
    {
        private readonly EMSContext _context;
        private readonly TaskInformationService _service;
        private readonly ContactService _contactService;

        public TaskInformationController(EMSContext context)
        {
            _context = context;
            _service = new TaskInformationService(_context);
        }





        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetInformation()
        {


            var result = _service.GetInformation();
            return Ok(result);


        }
        /*[Produces("application/json")]
        [HttpGet("getinfobytype/{id}")]
        public IEnumerable<TaskInformation> GetInfoByType(int id)
        {
            return _service.GetInfoByType(id);

        }*/
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("addinfodetails")]
        public IActionResult AddTaskInformation([FromForm]GetTaskInformation c)
        {
            ContactDetails cdetails = new ContactDetails();
            // cdetails.ContactId = c.ContactId;
            cdetails.Name = c.Name;
            cdetails.Number1 = c.Contact1;
            cdetails.Number2 = c.Contact2;
            cdetails.Address = c.Address;
            cdetails.ContactDescription = c.ContactDescription;
            cdetails.ContactDetailId = c.ContactId;
            cdetails.ContactId.ContactId = c.ContactId;

            int contactId = _contactService.AddContactDetail(cdetails);
            if (contactId != 0)

            {
                TaskInformation taskinfo = new TaskInformation();
                taskinfo.ContactId.ContactId = contactId;
                taskinfo.InfoDescription = c.InfoDescription;
                taskinfo.Id.Id = c.EmpId;
                taskinfo.IsComplete = c.IsComplete;

                _service.AddTaskInformation(taskinfo);
                return Ok(c);
            }
            else
            {
                return BadRequest("error");
            }


            /* if (_service.AddContactDetail(c))
             {

                 return Ok(c);
             }
             else
             {
                 return BadRequest("error");
             }*/
        }


    }
}
