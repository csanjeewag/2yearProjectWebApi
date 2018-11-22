using System;
using System.Collections.Generic;
using System.Text;
using EMS.Data.Models;

namespace EMS.Service
{
   public class PastEventService
    {
        private readonly EMS.Data.PastEventRepository _service;

        private readonly EMSContext _context;
        public PastEventService(EMSContext context)
        {
            _context = context;
            _service = new EMS.Data.PastEventRepository(_context);
        }

        public Boolean AddImage(EventImages image)
        {
            return _service.AddImage(image);
        }

        public List<EventImages> GetImages(string eventId)
        {
            return _service.GetImages(eventId);
        }

    }


}
