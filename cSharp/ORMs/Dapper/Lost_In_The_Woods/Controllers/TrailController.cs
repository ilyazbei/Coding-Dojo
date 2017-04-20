using System;
using System.Collections.Generic;
using System.Linq;
using LostInTheWoods.Factory;
using LostInTheWoods.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LostInTheWoods.Controllers
{


    public class TrailController : Controller
    {
        private readonly TrailFactory _dbConnector;
 
        public TrailController(TrailFactory connect)
        {
            _dbConnector = connect;
        }
        // Get: /trails/
        [HttpGet]
        [Route("Trails")]
        public IActionResult Trails() {

            System.Console.WriteLine("This is Trails route");
            // System.Console.WriteLine("********************************");
            // System.Console.WriteLine(HttpContext.Session.GetInt32("CurUserId"));
            // System.Console.WriteLine("********************************");
            if(HttpContext.Session.GetInt32("CurUserId") == null ) {
                string Error = "Dont try to steal my cookies";
                TempData["sesErrors"] = Error;
                return RedirectToAction("Index", "User");
            } else { 
                int? UserId = HttpContext.Session.GetInt32("CurUserId");
                // string query = $"SELECT * FROM Users WHERE idusert = '{UserId}'";
                // Dictionary<string, object> CurUser = _dbConnector.Query(query).SingleOrDefault();
                // ViewBag.CurUser = CurUser;

                // string ShowTrails = $"SELECT Trails.idTrails, trails.created_at, Trails.Users_idUsert, Trails.trail_name, Trails.description, Trails.trail_length, Trails.elevation_change FROM Trails JOIN Users on Users.idUsert = Trails.Users_idUsert ORDER BY Trails.idTrails DESC";
                // List<Dictionary<String, object>> allTrails = _dbConnector.Query(ShowTrails).ToList();
                // ViewBag.allTrails = allTrails;

                

                return View();
            }
        }
        // Get: /routes to a new trail/
        [HttpGet]
        [Route("NewTrail")]
        public IActionResult NewTrail() {

            return View();

        }

        // Post: /add a new trail/
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Trail newTrail) {
            // System.Console.WriteLine("********************************");
            // System.Console.WriteLine("IN creating ");
            // System.Console.WriteLine("********************************");

            if(ModelState.IsValid) {
                // string query1 = $"INSERT INTO Trails (trail_name, description, trail_length, elevation_change, longitude, latitude, created_at, updated_at, Users_idUsert) VALUES ('{newTrail.trail_name}', '{newTrail.description}', {newTrail.trail_length}, {newTrail.elevation_change}, {newTrail.longitude}, {newTrail.latitude}, NOW(), NOW(), 2)";
                _dbConnector.Add(newTrail);


                return RedirectToAction("Trails");

            } else {
                
                return View("NewTrail");
                
            }


        }
    }
}