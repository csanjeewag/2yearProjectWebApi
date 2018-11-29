using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
    public class EventService
    {
        private readonly EMS.Data.EventRepository _service;

        private readonly EMSContext _context;
        public EventService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.EventRepository(_context);
        }

        public Boolean AddEvent(Event even)
        {
            return _service.AddEvent(even);
        }
        //add an event

        public Event GetEventDetails(string id)
        {
            return _service.GetEventDetails(id);
        }
        //method for get details of a selected event


        public Boolean RegisterForOneDayTrip(OneDayTripRegistrant reg)
        {
            return _service.RegisterForOneDaytrip(reg);
        }
        //add a registrant for single day trip


        public Boolean RegisterForTwoDayTrip(TwoDayTripRegistrants reg)
        {
            return _service.RegisterForTwoDaytrip(reg);
        }
        //add a registrant for multiple day trip


        public IEnumerable<Event> ViewUpComingEvents()
        {
            return _service.ViewUpComingEvents();
        }
        //get details of up coming events filter by startdate

        public Boolean AddFrontPage(FrontPage page)
        {
            return _service.AddFrontPage(page);
        }

        public FrontPage GetFrontPage(string id)
        {
            return _service.GetFrontPage(id);
        }

        public Boolean AddCricketTeam(CricketTeam team)
        {
            return _service.AddCricketTeam(team);
        }

        public List<CricketTeam> GetCricketTeams()
        {
            return _service.GetCricketTeams();
        }

        public CricketTeam GetCricketTeams(string id)
        {
            return _service.GetCricketTeams(id);
        }

        public Boolean UpdateCricketTeam(CricketTeam team)
        {
            return _service.UpdateCricketTeam(team);
        }
    }
}
