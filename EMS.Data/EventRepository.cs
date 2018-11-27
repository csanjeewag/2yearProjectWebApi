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
    }
}
