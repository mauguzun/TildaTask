using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SecondTask.Models;
using SecondTask.Models.Implemntation;
using SecondTask.Models.ViewModel;

namespace SecondTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _context;

        public HomeController(ApplicationContext applicationContext)
        {
           _context = applicationContext;
        }

        public IActionResult Index()
        {
            if (_context.BankUserTransactions.Count() == 0)
            {
                this.InitTestsTranscations();
            }

        

            return View(this._context.BankUsers.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        private void InitTestsTranscations()
        {
            var transaction = new BankTransaction(_context);
            //  some tests data
            for (int i = 0; i < 10; i += 1)
            {
                int amount = 50;
                var from = _context.BankUsers.Where(x => x.Id == i.ToString()).FirstOrDefault();
                var to = _context.BankUsers.Where(x => x.Id == (i + 1).ToString()).FirstOrDefault();
                transaction.Send(from, to, amount * 1);

            }

            for (int i = 0; i < 10; i += 1)
            {
                int amount = 50;
                var to = _context.BankUsers.Where(x => x.Id == i.ToString()).FirstOrDefault();
                var from = _context.BankUsers.Where(x => x.Id == (i + 1).ToString()).FirstOrDefault();
                transaction.Send(from, to, amount * 1);

            }
            for (int i = 0; i < 10; i += 4)
            {
                int amount = 250;
                var from = _context.BankUsers.Where(x => x.Id == i.ToString()).FirstOrDefault();
                var to = _context.BankUsers.Where(x => x.Id == (i + 1).ToString()).FirstOrDefault();
                transaction.Send(from, to, amount * 1);

            }

            for (int i = 9; i > -1; i -= 1)
            {
                int amount = 100;
                var from = _context.BankUsers.Where(x => x.Id == i.ToString()).FirstOrDefault();
                var to = _context.BankUsers.Where(x => x.Id == (i + 1).ToString()).FirstOrDefault();
                transaction.Send(from, to, amount * 2);
            }
        }
    }
}
