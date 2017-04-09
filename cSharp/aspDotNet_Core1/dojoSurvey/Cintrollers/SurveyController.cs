using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace dojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        // Index
        [HttpGet]
        [RouteAttribute("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View("surveyForm");
        }
        // process to result
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string Name, string Location, string Language, string Comment)
        {
            ViewBag.Errors = new List<string>();

            if(Name == null)
            {
                ViewBag.Errors.Add("Hey Nameless HUMAN input your name!!!");
            }

            if(Location == null)
            {
                ViewBag.Errors.Add("Please select a valid location");
            }

            if(Language == null)
            {
                ViewBag.Errors.Add("Please select a valid language");
            }

            if(ViewBag.Errors.Count > 0)
            {
                return View("surveyForm");
            }

            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;

            return View("Result");
        }
    
        // Go Back
        // [HttpGet]
        // [RouteAttribute("contact")]
        // public IActionResult Contact()
        // {
        //     return View("Contact");
        // }
       
    }
}