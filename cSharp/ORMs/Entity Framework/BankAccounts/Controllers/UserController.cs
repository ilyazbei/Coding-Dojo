using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankAccounts.Controllers
{

    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upone retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }


    public class UserController : Controller
    {

        private BankAccountsContext _context;
 
        public UserController(BankAccountsContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(TempData != null ) {
                ViewBag.sesErrors = TempData["sesErrors"];
            }
            return View();
        }
        // Post: /Register/
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            Users MyUser = _context.Users.SingleOrDefault(user => user.email == model.email);
            if(MyUser != null) {
                ViewBag.LogRegErrors = "This email already exists";
                return View("Index");
            } 
            if(ModelState.IsValid) {

                PasswordHasher<Users> Hasher = new PasswordHasher<Users>();
                //model.password = Hasher.HashPassword(newUser, model.password);

                Users newUser = new Users 
                {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    email = model.email,
                    password = model.password,
                    curBal = 0
                };

                newUser.password = Hasher.HashPassword(newUser, newUser.password);
                _context.Users.Add(newUser);
                _context.SaveChanges();

                Users CurUser = _context.Users.SingleOrDefault(user => user.email == model.email);

                HttpContext.Session.SetInt32("CurUserId", CurUser.UserId);

                return RedirectToAction("Account", "Account", new{id = CurUser.UserId});
            } else {
                return View("Index");
            }

        }

        // Post: /Login/
        [HttpPost]
        [RouteAttribute("login")]
        public IActionResult Login(string email, string password) {
            Users MyUser = _context.Users.SingleOrDefault(user => user.email == email);
            var Hasher = new PasswordHasher<Users>();
            if(MyUser != null ) {
                if(password == null) {
                    ViewBag.LogRegErrors = "You forgot to enter you Password";
                    return View("Index");
                } 
                
                else if( 0 != Hasher.VerifyHashedPassword(MyUser, MyUser.password, password) ) {
                    // set user in session
                    HttpContext.Session.SetInt32("CurUserId", MyUser.UserId);
                    return RedirectToAction("Account", "Account", new{id = MyUser.UserId});
                } else {
                    ViewBag.LogRegErrors = "Invalid Password";
                    return View("Index");
                }
            }
            
            
            ViewBag.LogRegErrors = "This email dose not exists, please register!";
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
