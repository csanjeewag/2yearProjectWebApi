using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class EventTypeRepository
    {
        private readonly EMSContext _context;
        public EventTypeRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean AddEventType(Eventtype eventtype)
        {
            
                _context.Eventtypes.Add(eventtype);
                _context.SaveChanges();

            return true;
            
        }

        public List<Eventtype> GetAllEvents()
        {
            var types = _context.Eventtypes.ToList();
            return types;
        }
     
    }
}
