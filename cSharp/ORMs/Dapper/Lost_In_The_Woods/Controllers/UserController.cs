using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostInTheWoods.Factory;
using LostInTheWoods.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LostInTheWoods.Controllers
{
    public class UserController : Controller
    {
        private readonly UserFactory _dbConnector;
 
        public UserController()
        {
            _dbConnector = new UserFactory();
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
            
            // string query = $"SELECT * FROM Users WHERE email = '{NewUser.email}'";
            //_dbConnector.FindByEmail(NewUser.email);
            ViewBag.MyUser = _dbConnector.FindByEmail(NewUser.email);

            if(ViewBag.MyUser != null) {
                ViewBag.RegErrors = "This email is exist";
                return View("Index");
            } 

            if(ModelState.IsValid) {
                  
                _dbConnector.Add(NewUser);
                ViewBag.CurUser = _dbConnector.FindByEmail(NewUser.email); 
                // set user in session
                HttpContext.Session.SetInt32("CurUserId", (int)ViewBag.CurUser["idusert"]);

                return RedirectToAction("Trails", "Trail");

            } else {
                return View("Index");
            }
        }
        // Post: /Login/
        [HttpPost]
        [Route("login")]
        public IActionResult Login(string email, string password) {
            // string query = $"SELECT * FROM Users WHERE email = '{email}'";
            // Dictionary<string, object> MyUser = _dbConnector.Query(query).SingleOrDefault();
            ViewBag.MyUser = _dbConnector.FindByEmail(email);

            if(ViewBag.MyUser != null ) {
                if(password == null) {
                    ViewBag.LogErrors = "You forgot to enter you Password";
                    return View("Index");
                }
                else if((string)ViewBag.MyUser["password"] == password ) {
                    
                    // set user in session
                    HttpContext.Session.SetInt32("CurUserId", (int)ViewBag.MyUser["idusert"]);
                    return RedirectToAction("Trails", "Trail");
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
