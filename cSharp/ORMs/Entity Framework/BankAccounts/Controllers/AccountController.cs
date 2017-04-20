using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankAccounts.Controllers
{
    public class AccountController : Controller
    {
        private BankAccountsContext _context;
 
        public AccountController(BankAccountsContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("account/{id}")]
        public IActionResult Account(int id )
        {
            // if(TempData["ModelError"] != null) {
            //     DepWithViewModel model = (DepWithViewModel)TempData["ModelError"];
            //     TryValidateModel(model);
            // }

            if(TempData["ModelError"] != null ) {
                ViewBag.ModelError = TempData["ModelError"];
            }

            if(HttpContext.Session.GetInt32("CurUserId") == null ) {
                string Error = "Dont try to steal my cookies";
                TempData["sesErrors"] = Error;
                return RedirectToAction("Index", "User");
            } else {
                ViewBag.amountError = TempData["amountError"];
                // int? UserId = HttpContext.Session.GetInt32("CurUserId");

                Users CurUser = _context.Users.SingleOrDefault( user => user.UserId == id );   
                ViewBag.CurUser = CurUser;

                List<Transactions> allActivities = _context.Transactions.Where( user => user.UsersUserId == id ).OrderByDescending( x => x.createdAt ).ToList();
                // List<Transactions> allActivities = _context.Transactions.ToList();
                ViewBag.allActivities = allActivities;
                
                return View();
            }


        }

        // Post: /DepWith/
        [HttpPost]
        [Route("account/DepWith")]
        public IActionResult DepWith(DepWithViewModel model )
        {
            int? UserId1 = HttpContext.Session.GetInt32("CurUserId");
            System.Console.WriteLine("*******************************");
            System.Console.WriteLine("in DEPWITH");
            System.Console.WriteLine("*******************************");
            
            if(ModelState.IsValid) {
                int? UserId = HttpContext.Session.GetInt32("CurUserId");
                Transactions newTransaction = new Transactions 
                {
                    depWith = (int)model.depWith,
                    UsersUserId = (int)HttpContext.Session.GetInt32("CurUserId")

                };
                _context.Transactions.Add(newTransaction);
                Users CurUser = _context.Users.SingleOrDefault( user => user.UserId == UserId);
                if(model.depWith < 0  ) { 
                    int num = (int)model.depWith;
                    int posNum = ~num+1;
                    System.Console.WriteLine("*******************************");
                    System.Console.WriteLine(posNum);
                    System.Console.WriteLine("*******************************");
                    if( posNum > CurUser.curBal ) {
                        TempData["amountError"] = "You dont have enough funds for this transaction, cant take more then you have";
                        return RedirectToAction("Account", new{id = CurUser.UserId});
                    }  else {
                        CurUser.curBal += (int)model.depWith; 
                        _context.SaveChanges();
                        return RedirectToAction("Account" , new{id = CurUser.UserId});
                    }

                } else {
                    CurUser.curBal += (int)model.depWith;                

                    _context.SaveChanges();
                    return RedirectToAction("Account" , new{id = CurUser.UserId});
                }

            } 
            
            List<string> error_list = new  List<string>();
            foreach(var error in ModelState.Values){
                if(error.Errors.Count>0){
                    error_list.Add(error.Errors[0].ErrorMessage.ToString());
                }
            }
            if(error_list.Count>0){
                TempData["ModelError"] = error_list;
                return RedirectToAction("Account",  new{id = (int)UserId1});
            }
            
            return RedirectToAction("Account",  new{id = (int)UserId1});


        }
    }
}





       