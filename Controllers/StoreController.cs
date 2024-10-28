using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class StoreController : Controller
    {
        [HttpGet("store/books/{id?}")]
        public IActionResult Books([FromRoute] int id)
        {
            //return View();
            
            return Content($"<h1>Book Store id={id}</h1>", "text/html");
        }
    }
}
//products?islogged=true&id=225
