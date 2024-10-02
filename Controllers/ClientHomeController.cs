using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

namespace ControllersExample.Controllers
{
    [Controller]
    public class ClientHomeController : Controller
    {
        [HttpGet("/client-home")]
        public ContentResult ClientHome()
        {
            return Content("<h1>ClientHome Page</h1>", "text/html");
        }
        [HttpGet("/client-home/profile")]
        public JsonResult Profile()
        {
            Profile profile = new Profile()
            {
                Id = Guid.NewGuid(),
                FirstName = "James",
                LastName = "Smith",
                Age = 25
            };
            //return new JsonResult(profile);   //or can use "Json(profile);"
            return Json(profile);   //a shortcut for new JsonResult(profile)
        }

        [HttpGet("/client-home/download-file1")]
        public VirtualFileResult DownloadFile1()
        {
            //return new VirtualFileResult("/Web_Developer_Sample.pdf", "application/pdf");   //access the files located in wwwroot folder
            return File("/Web_Developer_Sample.pdf", "application/pdf");
        }

        /*  ! NOT WORKING
        [HttpGet("/client-home/download-file2")]
        public PhysicalFileResult DownloadFile2()
        {
            //return new PhysicalFileResult(@"c:\Users\User\source\repos\ControllersExample\sample.txt", "application/txt");   //access the files located in another directory
            return PhysicalFile(bytes, "application/txt");     //a shortcut for new PhysicalFileResult(...)
        }*/

        /*  ! NOT WORKING
        [HttpGet("/client-home/download-file3")]
        public FileContentResult DownloadFile3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"c:\Users\User\source\repos\ControllersExample\sample.txt");
            //return new FileContentResult(bytes, "application/txt");
            return File(bytes, "application/txt");     //a shortcut for new FileContentResult(...)
        }*/
    }
}
