using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMS.Data.Models;

namespace EMS.Data
{
  public  class PastEventRepository
    {
        private readonly EMSContext _context;
        public PastEventRepository(EMSContext context)
        {
            _context = context;
        }

        public Boolean AddImage( EventImages image)
        {
            try
            {
                DateTime today = DateTime.Today;
                image.Date = today;
                image.IsActive = true;
                var text = _context.Add(image);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<EventImages> GetImages( string eventId)
        {
            try
            {
                var text = _context.EventImages.Where(e => e.EventId == eventId).ToList();
                return text;
            }
            catch
            {
                return null;
            }
        }

    }

    
}
