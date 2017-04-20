using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class ReviewController : Controller
    {

        private RESTauranterContext _context;
 
        public ReviewController(RESTauranterContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Reviews> AllUsers = _context.Reviews.ToList();
            return View();
        }

        // Post: /Create/
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Reviews newReview)
        {
            if(newReview.Date_Of_Visit > DateTime.Now) {
                ViewBag.dateError = "Date cant be in the future";
                return View("Index");
            }
            if(ModelState.IsValid) {
                _context.Reviews.Add(newReview);
                _context.SaveChanges();
                return RedirectToAction("Reviews");
            } else {
                return View("Index");
            }
        }

        // GET: /Reviews/
        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            // List<Reviews> AllReviews = _context.Reviews.ToList();
            List<Reviews> AllReviews = _context.Reviews.OrderByDescending( x => x.created_at ).ToList();
            ViewBag.AllReviews = AllReviews;
            return View();
        }
    }
}
