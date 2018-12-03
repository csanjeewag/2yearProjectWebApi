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

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("createEvent")]
        public IActionResult CreateEvent([FromBody]Event even)
        {

            if (_service.AddEvent(even))
            {

                return Ok(even);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //method for create an event

        [Produces("application/json")]
        [HttpGet("getall/{id}")]
        public Event GetEventDetails(string id)
        {
            return _service.GetEventDetails(id);
        }
        //method for get details of a selected event


        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("registerForOneDayTrip")]
        public IActionResult RegisterForOneDayTrip([FromBody]OneDayTripRegistrant reg)
        {

            if (_service.RegisterForOneDayTrip(reg))
            {
                return Ok(reg);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //add a registrant for single day trip

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpPost("registerForTwoDayTrip")]
        public IActionResult RegisterForTwoDayTrip([FromBody]TwoDayTripRegistrants reg)
        {

            if (_service.RegisterForTwoDayTrip(reg))
            {

                return Ok(reg);
            }
            else
            {
                return BadRequest("there is a error");
            }
        }
        //add a registrant for multiple day trip

        [Produces("application/json")]
        [Consumes("application/json")]
        [HttpGet("v")]
        public IActionResult ViewUpComingEvents()
        {

            var res = _service.ViewUpComingEvents();

            try { return Ok(res); } catch { return BadRequest("error get departments!"); }
        }
        //get details of up coming events filter by startdate


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
        [HttpPost("addcricketteam")]
        public IActionResult AddCricketTeam([FromForm]CricketTeam team)
        {
            var test = _service.AddCricketTeam(team);
            if (test)
            {
                return Ok(test);
            }
            else
            {
                return BadRequest("error");
            }
        }

        [HttpGet("getcricketteams")]
        public IActionResult GetCricketTeams()
        { 
            try
            {
                var test = _service.GetCricketTeams();
                return Ok(test);
            }
            catch
            {
                return BadRequest("error");
            }
        }

        [HttpGet("getcricketteam/{id}")]
        public IActionResult GetCricketTeams(string id)
        {
           
            try
            {
                var test = _service.GetCricketTeams(id);
                return Ok(); 
               
            }
            catch { return BadRequest(); }
        }

        [HttpPost("updatecricketteam")]
        public IActionResult UpdateCricketTeam([FromForm]CricketTeam team)
        {
            
            try
            {
                var test = _service.UpdateCricketTeam(team);
                if (test) { return Ok(); }
                else { return BadRequest(); }
            }
            catch { return BadRequest(); }
        }
    }
}