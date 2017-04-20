using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        private WeddingPlannerContext _context;

        public WeddingController(WeddingPlannerContext context)
        {
            _context = context;
        }

        // GET: /Dashboard/
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            if(HttpContext.Session.GetInt32("CurUserId") == null ) {
                string Error = "Dont try to steal my cookies";
                TempData["sesErrors"] = Error;
                return RedirectToAction("Index", "User");
            } else {
                int? currUserId = HttpContext.Session.GetInt32("CurUserId");
                Users CurUser = _context.Users.SingleOrDefault( user => user.UserId == currUserId );   
                ViewBag.CurUser = CurUser;
                // HttpContext.Session.SetInt32("CurUserId", CurUser.UserId);
                return View();
            }
        }
        // Post: /Create/
        [HttpPost]
        [Route("Create")]
        public IActionResult Create ( WeddingViewModel model)
        {
            if(ModelState.IsValid) {

                Weddings newWedding = new Weddings 
                {
                    wedderOne = model.wedderOne,
                    wedderTwo = model.wedderTwo,
                    date = model.date,
                    weddingAddress = model.weddingAddress

                };
                _context.Weddings.Add(newWedding);
                _context.SaveChanges();
                int? currUserId = HttpContext.Session.GetInt32("CurUserId");
                Users CurUser = _context.Users.SingleOrDefault( user => user.UserId == currUserId );
                HttpContext.Session.SetInt32("CurUserId", CurUser.UserId);
                ViewBag.CurUser = CurUser;
                return RedirectToAction("Dashboard");

            } else {
                int? currUserId = HttpContext.Session.GetInt32("CurUserId");
                Users CurUser = _context.Users.SingleOrDefault( user => user.UserId == currUserId );
                HttpContext.Session.SetInt32("CurUserId", CurUser.UserId);
                ViewBag.CurUser = CurUser;
                return View("NewWedding");
            }
        }

        // Get: / Add New Wedding to plan /
        [HttpGet]
        [Route("NewWedding")]
        public IActionResult NewWedding()
        {
            if(HttpContext.Session.GetInt32("CurUserId") == null ) {
                string Error = "Dont try to steal my cookies";
                TempData["sesErrors"] = Error;
                return RedirectToAction("Index", "User");
            } else {
                
                int? currUserId = HttpContext.Session.GetInt32("CurUserId");
                Users CurUser = _context.Users.SingleOrDefault( user => user.UserId == currUserId );   
                ViewBag.CurUser = CurUser;
                return View();
            }
        }

        // Get: / Info /
        [HttpGet]
        [Route("Info")]
        public IActionResult Info()
        {
            if(HttpContext.Session.GetInt32("CurUserId") == null ) {
                string Error = "Dont try to steal my cookies";
                TempData["sesErrors"] = Error;
                return RedirectToAction("Index", "User");
            } else {

                int? currUserId = HttpContext.Session.GetInt32("CurUserId");
                Users CurUser = _context.Users.SingleOrDefault( user => user.UserId == currUserId );   
                ViewBag.CurUser = CurUser;
                return View();
            }
        }

    }
}