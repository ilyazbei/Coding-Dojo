using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Controllers
{
    public class NavBarController : Controller
    {
        // Create three different routes for this Project: Home, Projects, and Contact
        // There should be a navbar with tabs to each section displayed at the top
        // The Home page should have a picture, name, and about me section
        // The Project page should have at least 3 Projects listed each with a Title, Image , and small description
        // The Contact page should consist just of a contact form with a input for name, email, and their message
        // Remember all pages should have some styling!!
        [HttpGet]
        [RouteAttribute("")]
        public IActionResult Home()
        {
            return View("Home");
        }
        [HttpGet]
        [RouteAttribute("projects")]
        public IActionResult Projects()
        {
            return View("Projects");
        }
        [HttpGet]
        [RouteAttribute("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
        }
        [HttpGet]
        [RouteAttribute("test")]
        public IActionResult Test()
        {
            return View("test");
        }
    }
}