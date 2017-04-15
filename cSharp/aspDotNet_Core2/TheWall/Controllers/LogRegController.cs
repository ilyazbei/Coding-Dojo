using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogReg.Controllers
{
    public class LogRegController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public LogRegController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.sesErrors = TempData["sesErrors"]; 
            return View();
        }
        // Post: /Register/
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User NewUser) {
            
            string query = $"SELECT * FROM LogReg WHERE Email = '{NewUser.Email}'";
            Dictionary<string, object> MyUser = _dbConnector.Query(query).SingleOrDefault();

            if(MyUser != null) {
                ViewBag.RegErrors = "This email is exist";
                return View("Index");
            } 

            if(ModelState.IsValid) {
                string query2 = $"INSERT INTO LogReg (First_Name, Last_Name, Email, Password, created_at, updated_at) VALUES ('{NewUser.First_Name}', '{NewUser.Last_Name}', '{NewUser.Email}', '{NewUser.Password}', NOW(), NOW() )";
                _dbConnector.Execute(query2);

                string query1 = $"SELECT * FROM LogReg WHERE Email = '{NewUser.Email}'";
                Dictionary<string, object> CurUser = _dbConnector.Query(query1).SingleOrDefault();
                // set user in session
                HttpContext.Session.SetInt32("CurUserId", (int)CurUser["idLogReg"]);

                return RedirectToAction("Dashboard", "TheWall");

            } else {
                return View("Index");
            }
        }
        // Post: /Login/
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password) {
            string query = $"SELECT * FROM LogReg WHERE Email = '{Email}'";
            Dictionary<string, object> MyUser = _dbConnector.Query(query).SingleOrDefault();

            if(MyUser != null ) {
                if(Password == null) {
                    ViewBag.LogErrors = "You forgot to enter you Password";
                    return View("Index");
                }
                else if((string)MyUser["Password"] == Password ) {
                    
                    // set user in session
                    HttpContext.Session.SetInt32("CurUserId", (int)MyUser["idLogReg"]);
                    return RedirectToAction("Dashboard", "TheWall");
                } else {
                    ViewBag.LogErrors = "Invalid Password";
                    return View("Index");
                }
            }
            ViewBag.LogErrors = "This email dose not exist , please register";
            return View("Index");                        
        }
        
        // Get: /Log Out/
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
