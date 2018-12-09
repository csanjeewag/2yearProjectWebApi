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
using Task = EMS.Data.Models.Task;

namespace EMS.API.Controllers
{

    [Produces("application/json")]
    [Route("api/task")]
    public class TaskController:Controller
    {
        private readonly EMSContext _context;
        private readonly TaskService _service;
       
        public TaskController(EMSContext context)
        {
            _context = context;
            _service = new TaskService(_context);
        }


        /// <summary>
        /// By the url of 'task/getallforemployee' return all tasks for the particular emp
        /// </summary>
        /// <param name="id"></param>
        /// <returns>All assigned task for empId=id </returns>

        [Produces("application/json")]
        [HttpGet("gettaskforemp/{id}")]
        public IEnumerable<Task> GetTaskForEmployee(int id)
        {
            return _service.GetTaskForEmployee(id);

        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        /// 

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("create")]
        public IActionResult AddTask([FromBody]Task t)
        {

            if (_service.AddTask(t))
            {

                return Ok(t);
            }
            else
            {
                return BadRequest("error");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Produces("application/json")]
        [HttpGet("getall")]
        public IActionResult GetTaskDetails()
        {


            var result = _service.GetTaskDetails();
            return Ok(result);


        }
        
        /*[Produces("application/json")]
        [HttpGet("getall/{id}")]
        public IActionResult GetTaskDetails(string id)
        {


            var result = _service.GetTaskDetails(id);
            return Ok(result);


        }
        */
        /// <summary>
        /// Get Tasks by their TaskID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>A task with the url 'task/{id}'</returns>

        [Produces("application/json")]
        [HttpGet("{id}")]

        public Task GetTaskById(int id)
        {
            return _service.GetTaskById(id);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        
        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("updatetask")]
        public IActionResult UpdateTask([FromBody]Task t)
        {

            if (_service.UpdateTask(t))
            {

                return Ok(t);
            }
            else
            {
                return BadRequest("there error");
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tinfo"></param>
        /// <returns></returns>

         [Produces("application/json")]
         [Consumes("application/json")]
         [HttpPost("addinfo")]
         public IActionResult AddInformation([FromBody]TaskInformation tinfo)
         {

             if (_service.AddInformation(tinfo))
             {

                 return Ok(tinfo);
             }
             else
             {
                 return BadRequest("error");
             }
         }
        [Produces("application/json")]
        [HttpGet("getempfortask/{id}")]
        public IEnumerable<Employee> GetEmployeesForTask(int id)
        {
            return _service.GetEmployeesForTask(id);

        }


    }

}
