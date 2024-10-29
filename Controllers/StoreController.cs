using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class StoreController : Controller
    {
        [HttpGet("store/books/{id?}/{isloggedin?}")]  //store/books/225/true
        public IActionResult Books([FromRoute] int? id, [FromRoute] bool? isloggedin)
        {
            if (id == null)
            {
                return BadRequest("Book id is not supplied or empty. ");
            }
            if (id <= 0 || id > 1000)
            {
                return NotFound("id can not be less than 0 and greater than 1000");
            }
            
            
            if (isloggedin == null || isloggedin == false)
            {
                return StatusCode(401);
            }
            return Content($"<h1>Book Store id={id}</h1>", "text/html");
        }
        [HttpGet("store/books/{isloggedin?}")]  //store/books/true?name=Wonder World&Author=Stephen King
        public IActionResult BookByNameAndAuthor([FromRoute] bool? isloggedin, Book book)   //book fields will come from query string as it is mentioned in Book class
        {
            if (isloggedin == null || isloggedin == false)
            {
                return StatusCode(401);
            }
            return Content($"<h1>Book Store</h1>\n<p>Book name: {book.Name}, Author: {book.Author}</p>", "text/html");
        }
    }
}
//products?islogged=true&id=225
