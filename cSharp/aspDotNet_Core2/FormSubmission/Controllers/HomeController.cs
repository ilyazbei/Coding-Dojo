using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = "";
            return View();
        }

        // Post: /process/
        [HttpPost]
        [Route("process")]
        public IActionResult Process(string First_Name, string Last_Name, int Age, string Email, string Password) {
            User newUser = new User {
                First_Name = First_Name,
                Last_Name = Last_Name,
                Age = Age,
                Email = Email,
                Password = Password
            };

            if (TryValidateModel(newUser)) {
                return View("Success");
            } else {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
        }
        // Get: /success/
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View("Success");
        }
    }
}
