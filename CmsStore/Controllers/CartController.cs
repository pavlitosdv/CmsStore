using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmsStore.Data;
using CmsStore.Extensions;
using CmsStore.Models;
using CmsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CmsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDBContext context;

        public CartController(ApplicationDBContext context)
        {
            this.context = context;
        }

        // GET /cart
        public IActionResult Index()
        {
            // (1) Session if session is initialized get item else initialize a new list
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartViewModel cartVM = new CartViewModel
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x => x.Price * x.Quantity)
            };

            return View(cartVM);
        }
        
     
    }
}