using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Connectors;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {   
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [RouteAttribute("/addQuote")]
        public IActionResult AddQuote(string name, string quote) {
            System.Console.WriteLine(name);
            System.Console.WriteLine(quote);
            if(name != null ) {

                string query = $"INSERT INTO Quotes (name, quote, created_at, updated_at) VALUES ('{name}', '{quote}', NOW(), NOW() )";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes()
        {
            string query = "SELECT * FROM Quotes";
            var allQuotes = DbConnector.Query(query);
            ViewBag.allQuotes = allQuotes;
            // List<Dictionary<string, object>> AllQuotes = DbConnector.Query("SELECT * FROM Quotes");
            return View("Quotes");
        }
    }
}
