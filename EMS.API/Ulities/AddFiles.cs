using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EMS.API.Ulities
{
   public class AddFiles
    {
        public static List<String> AddImages(List<IFormFile> Images, string id)
        {
            var result = new List<String>();
            if (Images != null)
            {
                foreach (var image in Images)
                {
                    string imageName = null;
                    imageName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(" ", "-");
                    imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);
                    //var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
                    // postedFile.SaveAs(filePath);

                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot/Image", imageName);

                    var stream = new FileStream(path, FileMode.Create);
                    image.CopyToAsync(stream);

                    result.Add("Image/" + imageName);
                }
                return result;
            }

            return null;
        }

        public static String AddImage(IFormFile image, string id)
        {
            string result;
            if (image != null)
            {

                string imageName = null;
                imageName = new string(Path.GetFileNameWithoutExtension(image.FileName).Take(10).ToArray()).Replace(" ", "-");
                imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(image.FileName);
                //var filePath = HttpContext.Current.Server.MapPath("~/Image/" + imageName);
                // postedFile.SaveAs(filePath);

                var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot/Image", imageName);

                var stream = new FileStream(path, FileMode.Create);
                image.CopyToAsync(stream);

                result = "Image/" + imageName;

                return result;
            }

            return null;
        }


    }
}

