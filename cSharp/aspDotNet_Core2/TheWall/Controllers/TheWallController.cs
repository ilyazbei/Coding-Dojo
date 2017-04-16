using System;
using System.Collections.Generic;
using System.Linq;
using LogReg.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogReg.Controllers
{


    public class TheWallController : Controller
    {
        private readonly DbConnector _dbConnector;
 
        public TheWallController(DbConnector connect)
        {
            _dbConnector = connect;
        }
        // Get: /Dashboard/
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard() {
            ViewBag.MesErrors = TempData["MesErrors"];
            

            System.Console.WriteLine("This is dash route");
            // System.Console.WriteLine("********************************");
            // System.Console.WriteLine(HttpContext.Session.GetInt32("CurUserId"));
            // System.Console.WriteLine("********************************");
            if(HttpContext.Session.GetInt32("CurUserId") == null ) {
                string Error = "Dont try to steal my cookies";
                TempData["sesErrors"] = Error;
                return RedirectToAction("Index", "LogReg");
            } else { 
                int? UserId = HttpContext.Session.GetInt32("CurUserId");
                string query = $"SELECT * FROM LogReg WHERE idLogReg = '{UserId}'";
                Dictionary<string, object> CurUser = _dbConnector.Query(query).SingleOrDefault();
                ViewBag.CurUser = CurUser;

                string ShowMes = $"SELECT messages.idmessages, CONCAT(LogReg.First_Name, ' ', LogReg.Last_Name) AS message_author, messages.created_at, messages.LogReg_idLogReg, messages.message FROM messages JOIN LogReg on LogReg.idLogReg = messages.LogReg_idLogReg ORDER BY messages.idmessages DESC";
                List<Dictionary<string, object>> allMessages = _dbConnector.Query(ShowMes).ToList();
                foreach (var message in allMessages)
                {
                    // using SystemExtensions.cs
                    message["created_at"] = ((DateTime)message["created_at"]).ToString("dddd, dnn MMMM yyyy hh:mm:ss tt", true);//example time: 6:00:00 PM
                    // System.Console.WriteLine("********************************");
                    // System.Console.WriteLine(((DateTime)message["created_at"]).ToString("dddd, dnn MMMM yyyy", true));
                    // System.Console.WriteLine("********************************");
                }
                ViewBag.allMessages = allMessages;

                string ShowCom = $"SELECT comments.messages_idmessages, CONCAT(LogReg.First_Name, ' ',LogReg.Last_Name) AS comment_author, comments.created_at, comments.comment FROM comments JOIN LogReg ON LogReg.idLogReg = comments.LogReg_idLogReg JOIN messages ON messages.idmessages = comments.messages_idmessages ORDER BY comments.idcomments ASC";
                List<Dictionary<string, object>> allComments = _dbConnector.Query(ShowCom).ToList();
                foreach (var comment in allComments)
                {
                    comment["created_at"] = ((DateTime)comment["created_at"]).ToString("dddd, dnn MMMM yyyy H:mm:ss", true);//example time in military : 18:00:00 
                }
                ViewBag.allComments = allComments;
               

                return View();
            }
        }
        // Post: /post a message/
        [HttpPost]
        [Route("/postMessage")]
        public IActionResult Message(Message NewMessage) {
            if(ModelState.IsValid) {
                int? UserId = HttpContext.Session.GetInt32("CurUserId");
            
                string mesQuery = $"INSERT INTO messages (message, created_at, updated_at, LogReg_idLogReg) VALUES ('{NewMessage.message}', NOW(), NOW(), '{UserId}')";
                _dbConnector.Execute(mesQuery);
                return RedirectToAction("Dashboard");
            }
            string MessageError = "Type a message before trying to post it!";
            TempData["MesErrors"] = MessageError;
            return RedirectToAction("Dashboard");
        }
        // Post: /post a comment/
        [HttpPost]
        [Route("postComment/{messageID}")]
        public IActionResult Comment(Comment NewComment, int messageID) {
            if(ModelState.IsValid) {
                int? UserId = HttpContext.Session.GetInt32("CurUserId");
            
                string mesQuery = $"INSERT INTO comments (comment, created_at, updated_at, LogReg_idLogReg, messages_idmessages) VALUES ('{NewComment.comment}', NOW(), NOW(), '{UserId}', '{messageID}')";
                _dbConnector.Execute(mesQuery);
                return RedirectToAction("Dashboard");
            }
            string MessageError = "Type a Comment before trying to post it!";
            TempData["MesErrors"] = MessageError;
            return RedirectToAction("Dashboard");
        }
    }
}