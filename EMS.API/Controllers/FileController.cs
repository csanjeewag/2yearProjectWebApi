using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using EMS.Data.GetModels;

namespace EMS.API.Controllers
{
    [Produces("application/json")]
    [Route("api/File")]
    public class FileController : Controller
    {
        [HttpPost("upload")]
        [Produces("application/json")]
        [Consumes("application/json")]
        
        public IActionResult Upload([FromBody]FileUpload f)
        {
            try {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                 "wwwroot/Image",f.Image.FileName);
                var stream = new FileStream(path, FileMode.Create);
                f.Image.CopyToAsync(stream);
                return Ok(new { lenght = f.Image.Length, name = f.Image });
            }
            catch {
                return BadRequest();
            }
         }

        [HttpPost("uploads")]
        public async Task<IActionResult> Uploads(List<IFormFile> files)
        {
            try
            {
                var result = new List<FileUpload>();
                foreach(var file in files) {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                     "wwwroot/Image", "2"+".jpg");
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    result.Add(new FileUpload() {   });
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}