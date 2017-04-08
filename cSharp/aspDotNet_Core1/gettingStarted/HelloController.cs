using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace YourNamespace.Controllers
{
    public class HelloController : Controller
    {
        // A GET method
        [HttpGet]
        [Route("displayint")]
        public JsonResult Displayint()
        {
            // The Json method convert the object passed to it into JSON
            return Json(34);

        }

        // [HttpGet]
        // [Route("displayhuman")]
        // public JsonResult DisplayHuman()
        // {
        //     return Json(new Human());
        // }

        // // A POST method
        // [HttpPost]
        // [Route("")]
        // public IActionResult Other()
        // {
        //     // return View();
        // }
    }
}