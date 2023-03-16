using Microsoft.AspNetCore.Mvc;
using Mission09_ld365.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission09_ld365.Controllers
{
    public class TransactionController : Controller
    {

        private ITransactionRepository repo { get; set; }
        private Basket basket { get; set; }

        public TransactionController (ITransactionRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Transaction());
        }

        [HttpPost]
        public IActionResult Checkout(Transaction tran)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your basket is empty");
            }

            if (ModelState.IsValid)
            {
                tran.Lines = basket.Items.ToArray();
                repo.SaveTransaction(tran);
                basket.ClearBasket();

                return RedirectToPage("/TransactionCompletion");
            }

            else
            {
                return View();
            }
        }
    }
}
