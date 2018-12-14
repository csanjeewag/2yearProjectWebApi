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

        public Boolean AddImage( EventImages image, List<string> imageNames)
        {
            try
            {

                

                foreach (var imageName in imageNames)
                {

                    DateTime today = DateTime.Today;
                    EventImages eventImages = new EventImages();
                    eventImages.IsActive = true;
                    eventImages.EventId = image.EventId;
                    eventImages.ImageId = imageName;
                    eventImages.Date = image.Date;
                    eventImages.Description = image.Description;
                    eventImages.Author = image.Author;
                    eventImages.Caption = image.Caption;
                    var text = _context.Add(eventImages);
                    _context.SaveChanges();
                }
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
        public List<Event> GetAllEvent()
        {
            var events = _context.Events.ToList();
            return events;
        }

        public Event GetEvent(int id)
        {
            var events = _context.Events
                .Where(e => e.Id == id)
                .FirstOrDefault();
            return events;
        }

    }

    
}
