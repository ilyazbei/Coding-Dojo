using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay.Controllers
{
    public class TimeController : Controller
    {
        [HttpGet]
        [RouteAttribute("")]
        public IActionResult Index()
        {
            return View("Index1");
        }
        [HttpGet]
        [RouteAttribute("helloTime")]
        public IActionResult Hello()
        {
            return View("Index2");
        }
    }
}