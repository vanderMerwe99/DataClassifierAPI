using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataClassifierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        //[HttpPost("UploadFiles")]
        //public async Task<IActionResult> Post(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    // full path to file in temp location
        //    var filePath = Path.GetTempFileName();

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            using (var stream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        // process uploaded files
        // Don't rely on or trust the FileName property without validation.

        //    return Ok(new { count = files.Count, size, filePath });
        //}

        public static IWebHostEnvironment _environment;
        public UploadFileController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public class FileUploadAPI
        {
            public IFormFile files
            {
                get;
                set;
            }
        }
        [HttpPost]
        public async Task<string> Post([FromForm] FileUploadAPI objFile)
        {
            try
            {
                if (objFile.files.Length > 0)
                {
                    if (!Directory.Exists(_environment.WebRootPath + "\\Uploads\\"))
                    {
                        Directory.CreateDirectory(_environment.WebRootPath + "\\Uploads\\");
                        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Uploads\\" + objFile.files.FileName))
                        {
                            objFile.files.CopyTo(fileStream);
                            fileStream.Flush();
                            return "\\Uploads\\" + objFile.files.FileName;
                        }
                    }
                    else
                    {
                        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\Uploads\\" + objFile.files.FileName))
                        {
                            objFile.files.CopyTo(fileStream);
                            fileStream.Flush();
                            return "\\Uploads\\" + objFile.files.FileName;
                        }
                    }
                }
                else
                    return "Failure.";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}
