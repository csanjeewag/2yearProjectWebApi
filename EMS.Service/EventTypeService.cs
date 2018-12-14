using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
  public  class EventTypeService
    {
        private readonly EMS.Data.EventTypeRepository _service;

        private readonly EMSContext _context;
        public EventTypeService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.EventTypeRepository (_context);
        }

        public Boolean AddEventType(Eventtype eventtype)
        {
            return _service.AddEventType(eventtype);
        }

        public List<Eventtype> GetEventtypes()
        {
            return _service.GetAllEvents();
        }
    }
}
