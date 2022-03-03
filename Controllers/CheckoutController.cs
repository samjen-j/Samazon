using Microsoft.AspNetCore.Mvc;
using Samazon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Samazon.Controllers
{
    public class CheckoutController : Controller
    {
        private ICheckoutRepository repo { get; set; }
        private Cart cart { get; set; }
        public CheckoutController(ICheckoutRepository temp, Cart c)
        {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {

            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, please add item to cart");
            }

            if (ModelState.IsValid)
            {
                checkout.Lines = cart.Items.ToArray();
                repo.SaveCheckout(checkout);
                cart.ClearBasket();

                return RedirectToPage("/Confirmation");
            }

            else
            {
                return View();
            }

        }
    }
}
