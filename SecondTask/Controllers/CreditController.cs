using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondTask.Models;
using SecondTask.Models.Implemntation;
using System;
using System.Linq;

namespace SecondTask.Controllers
{
    [Authorize]
    public class CreditController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly UserManager<BankUser> _userManager;
        public CreditController(ApplicationContext applicationContext, UserManager<BankUser> userManager)
        {
            _context = applicationContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View(_userManager.Users.Where(x=>x.Id != _userManager.GetUserId(User)).ToList());
        }

        public IActionResult Ask(string Id)
        {

            var from = _userManager.FindByIdAsync(Id).Result;
            if (from == null)
                throw new Exception("user nor exist");

           return View(from);
        } 
        
        [HttpPost]
        public IActionResult Ask(string Id ,  int amount)
        {
            var to =  _userManager.GetUserAsync(HttpContext.User).Result;
            var from = _userManager.FindByIdAsync(Id).Result;

            if (from == null)
                throw new Exception("user nor exist");

            var transaction = new BankTransaction(_context);

            var result = transaction.Send(from, to, amount);
            if (result  != TransactionResult.Done )
            {
                ModelState.AddModelError("error", result.ToString()); 
                return View(from);
            }
            return RedirectToAction("Index", "Info");
          

        }
    }
}