using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace DojoDachi.Controllers
{
    public class DachiController : Controller
    {
        // Index
        [HttpGet]
        [Route("dojodachi")]
        public IActionResult Index()
        {
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            if(Fullness == null){
                Fullness = 20;
            }
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            if(Happiness == null){
                Happiness = 20;
            }
            int? Meals = HttpContext.Session.GetInt32("Meals");
            if(Meals == null){
                Meals = 3;
            }            
            int? Energy = HttpContext.Session.GetInt32("Energy");
            if(Energy == null){
                Energy = 85;
            }
            string Reaction = HttpContext.Session.GetString("Reaction");
            if(Reaction == null){
                Reaction = "";
            }
            string Message = HttpContext.Session.GetString("Message");
            if(Message == null){
                Message = "";
            }
            
            ViewBag.Fullness = Fullness;
            ViewBag.Happiness = Happiness;
            ViewBag.Meals = Meals;
            ViewBag.Energy = Energy;
            ViewBag.Reaction = Reaction;
            ViewBag.Message = Message;

            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            HttpContext.Session.SetInt32("Meals", (int)Meals);
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            HttpContext.Session.SetString("Reaction", (string)Reaction);
            HttpContext.Session.SetString("Message", (string)Message);

            if(Fullness < 1 || Happiness < 1 ){
                return RedirectToAction("youLost");
            }
            if(Fullness > 99 && Happiness > 99 && Energy > 99 ){
                return RedirectToAction("youWon");
            } else {
                return View();
            }
        }
        // Feed
        [HttpPost]
        [Route("feed")]
        public IActionResult Feed(){
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Meals = HttpContext.Session.GetInt32("Meals");
            string Reaction = HttpContext.Session.GetString("Reaction");
            string Message = HttpContext.Session.GetString("Message");
 
            if(Meals > 0){
                Meals -= 1;
                Random Rand = new Random();
                if(Rand.Next(0,4) > 0){
                    int randFullNum = Rand.Next(5,11);
                    Fullness += randFullNum;
                    
                    Reaction = " ;)";
                    Message = " - Minion enjoyed the meal! which Increased Fullness by " + randFullNum;
                } else {
                    Reaction = " :(";
                    Message = " - Minion didn't like the food very much... Shame you just wasted one Meal";
                }
            } else {
                Reaction = " :(";
                Message = " - You don't have any food for your Minion!!! Go work!";
            }

            
            ViewBag.Fullness = Fullness;
            ViewBag.Meals = Meals;
            ViewBag.Reaction = Reaction;
            ViewBag.Message = Message;

            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            HttpContext.Session.SetInt32("Meals", (int)Meals);
            HttpContext.Session.SetString("Reaction", (string)Reaction);
            HttpContext.Session.SetString("Message", (string)Message);

            return RedirectToAction("Index");
        }
        // Play
        [HttpPost]
        [Route("play")]
        public IActionResult Play(){
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            string Reaction = HttpContext.Session.GetString("Reaction");
            string Message = HttpContext.Session.GetString("Message");
 
            if(Energy > 4){
                Energy -= 5;
                Random Rand = new Random();
                if(Rand.Next(0,4) > 0){
                    int randHappNum = Rand.Next(5,11);
                    Happiness += randHappNum;
                    
                    Reaction = " ;)";
                    Message = " - Minion enjoyed playing with you! which Increased Happiness by " + randHappNum;
                } else {
                    Reaction = " :(";
                    Message = " - Minion didn't enjoy playing with you... Such a waste of Energy";
                }
            } else {
                Reaction = " :( Iam tired";
                Message = " - Yor Minion have no energy to play with you! You must put him to sleep";
            }
            
            ViewBag.Happiness = Happiness;
            ViewBag.Energy = Energy;
            ViewBag.Reaction = Reaction;
            ViewBag.Message = Message;

            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            HttpContext.Session.SetString("Reaction", (string)Reaction);
            HttpContext.Session.SetString("Message", (string)Message);

            return RedirectToAction("Index");
        } 
        // Work
        [HttpPost]
        [RouteAttribute("work")]
        public IActionResult Work(){
            int? Meals = HttpContext.Session.GetInt32("Meals");
            int? Energy = HttpContext.Session.GetInt32("Energy");
            string Reaction = HttpContext.Session.GetString("Reaction");
            string Message = HttpContext.Session.GetString("Message");

            if(Energy > 4) {
                Energy -= 5;
                Random Rand = new Random();
                int randMealAmount = Rand.Next(1,4);
                Meals += randMealAmount;
                Reaction = " :) it feels good to work hard and earn my Meal";
                Message = " - It is good to work but it is tiring so i just lost 5 points from energy but gainde " + randMealAmount + " to our meal section!";
            } else {
                Reaction = " :( Iam tired";
                Message = " - Yor Minion have no energy to Work! You must put him to sleep";
            }

            ViewBag.Meals = Meals;
            ViewBag.Energy = Energy;
            ViewBag.Reaction = Reaction;
            ViewBag.Message = Message;

            HttpContext.Session.SetInt32("Meals", (int)Meals);
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            HttpContext.Session.SetString("Reaction", (string)Reaction);
            HttpContext.Session.SetString("Message", (string)Message);

            return RedirectToAction("Index");
        }
        // Sleep
        [HttpPost]
        [RouteAttribute("sleep")]
        public IActionResult Sleep(){
            int? Energy = HttpContext.Session.GetInt32("Energy");
            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            string Reaction = HttpContext.Session.GetString("Reaction");
            string Message = HttpContext.Session.GetString("Message");

            Energy += 15;
            Fullness -= 5;
            Happiness -= 5;
            Reaction = " :) Minion loves sleeping";
            Message = " - Sleeping helped me regenrate my Enerrgy but it cost me hungry by 5, and makes my happiness go down by 5";

            ViewBag.Energy = Energy;
            ViewBag.Fullness = Fullness;
            ViewBag.Happiness = Happiness;
            ViewBag.Reaction = Reaction;
            ViewBag.Message = Message;

            HttpContext.Session.SetInt32("Energy", (int)Energy);
            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            HttpContext.Session.SetString("Reaction", (string)Reaction);
            HttpContext.Session.SetString("Message", (string)Message);

            return RedirectToAction("Index");
        }
        // Restart
        [HttpPost]
        [RouteAttribute("restart")]
        public IActionResult Restart(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        // You Lost
        [HttpGet]
        [RouteAttribute("youlost")]
        public IActionResult YouLost(){

            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Meals = HttpContext.Session.GetInt32("Meals");           
            int? Energy = HttpContext.Session.GetInt32("Energy");
            string Reaction = HttpContext.Session.GetString("Reaction");
            string Message = HttpContext.Session.GetString("Message");

            ViewBag.Fullness = Fullness;
            ViewBag.Happiness = Happiness;
            ViewBag.Meals = Meals;
            ViewBag.Energy = Energy;
            ViewBag.Reaction = Reaction;
            ViewBag.Message = Message;

            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            HttpContext.Session.SetInt32("Meals", (int)Meals);
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            HttpContext.Session.SetString("Reaction", (string)Reaction);
            HttpContext.Session.SetString("Message", (string)Message);

            return View("youLost");
        }
        // You Won
        [HttpGet]
        [RouteAttribute("youwon")]
        public IActionResult YouWon(){

            int? Fullness = HttpContext.Session.GetInt32("Fullness");
            int? Happiness = HttpContext.Session.GetInt32("Happiness");
            int? Meals = HttpContext.Session.GetInt32("Meals");           
            int? Energy = HttpContext.Session.GetInt32("Energy");
            string Reaction = HttpContext.Session.GetString("Reaction");
            string Message = HttpContext.Session.GetString("Message");

            ViewBag.Fullness = Fullness;
            ViewBag.Happiness = Happiness;
            ViewBag.Meals = Meals;
            ViewBag.Energy = Energy;
            ViewBag.Reaction = Reaction;
            ViewBag.Message = Message;

            HttpContext.Session.SetInt32("Fullness", (int)Fullness);
            HttpContext.Session.SetInt32("Happiness", (int)Happiness);
            HttpContext.Session.SetInt32("Meals", (int)Meals);
            HttpContext.Session.SetInt32("Energy", (int)Energy);
            HttpContext.Session.SetString("Reaction", (string)Reaction);
            HttpContext.Session.SetString("Message", (string)Message);

            return View("youWon");
        }
    }
}