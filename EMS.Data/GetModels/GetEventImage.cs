using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.GetModels
{
   public class GetEventImage
    {
        public IFormFile Image { get; set; }
        public string EventId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}
