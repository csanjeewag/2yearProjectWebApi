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
    }
}
