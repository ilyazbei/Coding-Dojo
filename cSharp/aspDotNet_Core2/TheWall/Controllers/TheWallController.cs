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
                ViewBag.allMessages = allMessages;

                string ShowCom = $"SELECT * FROM LogReg.comments";

                // string ShowCom = $"SELECT messages.idmessages, CONCAT(LogReg.First_Name, ' ', LogReg.Last_Name) AS message_author, messages.created_at, messages.LogReg_idLogReg, messages.message FROM messages JOIN LogReg on LogReg.idLogReg = messages.LogReg_idLogReg ORDER BY messages.idmessages DESC";
                List<Dictionary<string, object>> allComments = _dbConnector.Query(ShowCom).ToList();
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