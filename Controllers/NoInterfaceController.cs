//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Controller]
    public class NoInterfaceController
    {
        [HttpGet("/home")]
        [HttpGet("/")]
        public ContentResult Index()
        {

            return new ContentResult()
            {
                Content = "Hello from Index",
                ContentType = "text/html",
            };
        }

        [HttpGet("/about")]
        public String About()
        {
            return "Hello from About";
        }

        [HttpGet("/contact-us")]
        public String ContactUs()
        {
            return "Hello from ContactUs";
        }

        [HttpGet("/employees/{employeeid:regex(^\\d{{10}}$)}")]
        public String Employees(int employeeid)
        {
            return "Employee retrieval by id: "+ employeeid.ToString();
        }
    }
}
