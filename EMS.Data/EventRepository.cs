using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
   public class EventRepository
    {
        private readonly EMSContext _context;
        public EventRepository(EMSContext context)
        {
            _context = context;
        }
        public Boolean AddEvent(Event eve)
        {
            try
            {
                _context.Events.Add(eve);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //create a new event

        public Event GetEventDetails(string id)
        {

            var eve = _context.Events
                .Where(c => c.PKey == id).FirstOrDefault();

            return eve;

        }
        //get details of a selected event


        public Boolean RegisterForOneDaytrip(OneDayTripRegistrant reg)
        {
            try
            {
                _context.OneDayTripRegistrants.Add(reg);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
        //add registrant for one day trip


        public Boolean RegisterForTwoDaytrip(TwoDayTripRegistrants reg)
        {
            try
            {
                _context.TwoDayTripRegistrant.Add(reg);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Event> ViewUpComingEvents()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine(today);

            var even = _context.Events
                .Where(c => c.StartDate >= today)
               .ToList();
            return even;
        }
        public Boolean AddFrontPage(FrontPage page)
        {
            try
            {
                _context.FrontPages.Add(page);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public FrontPage GetFrontPage(string id)
        {
            var test = _context.FrontPages.Where(c => c.CriEventId == id).FirstOrDefault();
            return test;
        }

        public Boolean AddCricketTeam(CricketTeam team)
        {
            try
            {
                _context.CricketTeams.Add(team);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public List<CricketTeam> GetCricketTeams()
        {
            var test = _context.CricketTeams.ToList();
            return test;
        }

        public CricketTeam GetCricketTeams(string id)
        {
            var team = _context.CricketTeams.Where(c => c.CriTeamID == id).FirstOrDefault();
            return team;
        }

        public Boolean UpdateCricketTeam(CricketTeam team)
        {
            try
            {
                _context.Entry(team).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
