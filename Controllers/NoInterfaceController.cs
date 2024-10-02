//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Route("[controller]")]
    public class NoInterfaceController
    {
        [HttpGet("/sayhello")]
        [HttpGet("/")]
        public String Index()
        {
            return "Hello from Index";
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
    }
}
