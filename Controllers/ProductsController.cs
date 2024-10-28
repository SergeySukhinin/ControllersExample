using ControllersExample.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Controller]
    public class ProductsController : Controller
    {
        [HttpGet("/products-home")]
        public IActionResult Products()
        {
            return Content("In products");
        }

        [HttpGet("/products")]  // ex: "/products?islogged=true&id=18"
        public IActionResult DownloadFile4()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["id"]))) {   //ControllerContext.HttpContext.Request.Query["id"]
                Response.StatusCode = 400;
                //return Content("id is not supplied");
                return BadRequest("id is not supplied");    // status 400
            }
            int itemId = Convert.ToInt16(Request.Query["id"]);
            if ( itemId <= 0 || itemId >1000) {
                //Response.StatusCode = 400;
                //return Content("id can not be less than 0 or greater than 1000");
                //return new BadRequestResult();    //there is a shortcut:
                //return BadRequest();  // to include a message into the bad request:
                return NotFound("id can not be less than 0 or greater than 1000");  //status 404
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["islogged"]))
                || (!Convert.ToBoolean(Request.Query["islogged"])))
            {
                //return StatusCode(401);
                return Unauthorized("User must be authenticated");  // status 401
            }

            //return Json(new Product(Convert.ToUInt16(Request.Query["id"])));

            /***
              response is 302 - Found (temporary redirect
            //return new RedirectToActionResult("Books", "Store", new { }); //without passing any parameters
            // shortcut for redirect:
            //return RedirectToAction("Books", "Store", new { id = itemId });

            // response is 301 - Moved Permanently

            // BE CAREFUL WITH USING RedirectToActionPERMANENT!!! Your browser will go straight to the new controller without going through this code.
            // In case you change your code here, you will get issues, and in this case you will need clear your browser's cache and IIS Express Cache

            //return new RedirectToActionResult("Books", "Store", new { }, permanent: true); 
            //shortcut for permanent redirect:
            //return RedirectToActionPermanent("Books", "Store", new { id = itemId });

            //return new RedirectToActionResult("Books", "Store", new Product(Convert.ToUInt16(Request.Query["id"])));
            */

            /***
             * ANOTHER WAY TO REDIRECT USING A URL:
             */
            // response 302 - Found
            return new LocalRedirectResult($"/store/books/{itemId}");
            // the shortcut is:
            //return new RedirectResult($"/store/books/{itemId}");
            // or:
            //return Redirect($"/store/books/{itemId}");

            //response 301 - Moved Permanently
            //return new RedirectResult($"/store/books/{itemId}", true);
            //return RedirectPermanent($"/store/books/{itemId}");
        }
    }
}
