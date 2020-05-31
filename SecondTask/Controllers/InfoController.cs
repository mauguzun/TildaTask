using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondTask.Models;
using SecondTask.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SecondTask.Controllers
{
    [Authorize]
    public class InfoController : Controller
    {

        private readonly ApplicationContext _context;
        private readonly UserManager<BankUser> _userManager;
        public InfoController(ApplicationContext applicationContext, UserManager<BankUser> userManager)
        {
            _context = applicationContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {

            var myAccount = _userManager.GetUserAsync(HttpContext.User).Result;

          
            var query  = 
            from transactions in _context.BankUserTransactions.Where(x => x.CreditorId == myAccount.Id || x.DebitorId == myAccount.Id)
            join creditor in _context.BankUsers on transactions.CreditorId equals creditor.Id
            join debitor in _context.BankUsers on transactions.DebitorId equals debitor.Id

            select new DisplayTransaction()
            {
                Debitor = debitor,
                Creditor = creditor,
                BankUserTransaction = transactions,

            };


            InfoViewModel infoViewModel = new InfoViewModel();

            infoViewModel.Creditor = query.Where(x => x.Creditor.Id == myAccount.Id);
            infoViewModel.Debitor = query.Where(x => x.Debitor.Id == myAccount.Id);

            infoViewModel.Credit = _context.BankUserTransactions.Where(x => x.CreditorId == myAccount.Id).Sum(x => x.Amount);
            infoViewModel.Debit = _context.BankUserTransactions.Where(x => x.DebitorId == myAccount.Id).Sum(x => x.Amount);
            infoViewModel.Total = myAccount.Amount;




            return View(infoViewModel);
        }

     
    }
}