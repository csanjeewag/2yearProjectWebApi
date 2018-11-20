using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace EMS.Data.GetModels
{
   public class FileUpload
    {
       
        public string Id { get; set; }
        public string Dis { get; set; }
        public string Topic { get; set; }
        public string Type { get; set; }

        public IFormFile Image { get; set; } 

    }
}
