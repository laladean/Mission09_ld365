using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mission09_ld365.Models;

namespace Mission09_ld365.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;
        public CartSummaryViewComponent (Basket temp)
        {
            basket = temp;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
