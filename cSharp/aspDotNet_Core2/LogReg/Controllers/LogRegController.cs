using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
// using LogReg.Connectors;

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
            ViewBag.LogErrors = new List<string>();
            // ViewBag.Log1Errors = new List<string>();
            // ViewBag.Log1Errors = "";
            
            return View();
        }
        // Post: /Register/
        [HttpPost]
        [Route("register")]
        public IActionResult Register(User NewUser) {
            
            string query = $"SELECT * FROM LogReg WHERE Email = '{NewUser.Email}'";
            Dictionary<string, object> MyUser = _dbConnector.Query(query).SingleOrDefault();

            if(MyUser != null) {
                List<string> ERROR = new List<string>();
                ERROR.Add("This email is exist");
                ViewBag.LogErrors = ERROR;
                return View("Index");
            } 

            if(ModelState.IsValid) {
                string query2 = $"INSERT INTO LogReg (First_Name, Last_Name, Email, Password, created_at, updated_at) VALUES ('{NewUser.First_Name}', '{NewUser.Last_Name}', '{NewUser.Email}', '{NewUser.Password}', NOW(), NOW() )";
                _dbConnector.Execute(query2);
                ViewBag.LogErrors = new List<string>();


                string query1 = $"SELECT * FROM LogReg WHERE Email = '{NewUser.Email}'";
                Dictionary<string, object> CurUser = _dbConnector.Query(query1).SingleOrDefault();
                // set user in session
                HttpContext.Session.SetInt32("CurUserId", (int)CurUser["idLogReg"]);


                return RedirectToAction("Success");

            } else {
                ViewBag.LogErrors = new List<string>();
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
                    List<string> ERROR1 = new List<string>();
                    ERROR1.Add("You forgot to enter you Password");
                    ViewBag.LogErrors = ERROR1;
                    return View("Index");
                }
                else if((string)MyUser["Password"] == Password ) {
                    
                    // set user in session
                    HttpContext.Session.SetInt32("CurUserId", (int)MyUser["idLogReg"]);
                    return RedirectToAction("Success");
                } else {   
                    List<string> ERROR2 = new List<string>();
                    ERROR2.Add("Invalid Password");
                    ViewBag.LogErrors = ERROR2;
                    return View("Index");
                }
            } 
            List<string> ERROR = new List<string>();
            ERROR.Add("This email dose not exist , please register");
            ViewBag.LogErrors = ERROR;
            return View("Index");                        
        }
        // Get: /Success/
        [HttpGet]
        [Route("success")]
        public IActionResult Success() {
            int? UserId = HttpContext.Session.GetInt32("CurUserId");
            string query = $"SELECT * FROM LogReg WHERE idLogReg = '{UserId}'";
            Dictionary<string, object> CurUser = _dbConnector.Query(query).SingleOrDefault();
            ViewBag.CurUser = CurUser;
            return View();
        }
    }
}
