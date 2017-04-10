using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace RandomPasscode.Controllers
{
    public class RandController : Controller
    {
        // Index with Session
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? RunCount = HttpContext.Session.GetInt32("RunCount");
            if(RunCount == null)
            {
                RunCount = 0;
            }
            RunCount += 1;
            string PossibleCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string RandPassword = "";
            Random Rand = new Random();
            for(int i = 0; i < 14; i++)
            {
                RandPassword = RandPassword + PossibleCharacters[Rand.Next(0, PossibleCharacters.Length)];
            }
            ViewBag.RandPassword = RandPassword;
            ViewBag.RunCount = RunCount;
            HttpContext.Session.SetInt32("RunCount", (int)RunCount);
            return View();
        }
        
        [HttpPost]
        [RouteAttribute("clear")]
        public IActionResult ClearSes()
        {
            HttpContext.Session.Clear();
            // return View("Index");
            return RedirectToAction("Index");
        }
    
       
       
    }
}