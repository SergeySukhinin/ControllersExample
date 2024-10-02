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
            int id = Convert.ToInt16(Request.Query["id"]);
            if ( id <= 0 || id >1000) {
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

            return Json(new Product(Convert.ToUInt16(Request.Query["id"])));
        }
    }
}
