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
        
        // GET /cart/add/5
        public async Task<IActionResult> Add(int id)
        {
            Product product = await context.Products.FindAsync(id);

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem == null)
            {
                cart.Add(new CartItem(product));
            } 
            else
            {
                cartItem.Quantity += 1;
            }

            HttpContext.Session.SetJson("Cart", cart);

            // if it is not an ajax request, it will be redirected to index else will return the view component
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return RedirectToAction("Index");

            return ViewComponent("SmallCart");
        }
        
        // GET /cart/decrease/5
        public IActionResult Decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            CartItem cartItem = cart.Where(x => x.ProductId == id).FirstOrDefault();

            if (cartItem.Quantity > 1)
            {
                --cartItem.Quantity;
            } 
            else
            {
                cart.RemoveAll(x => x.ProductId == id);
            }

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");//by removing/clearing the cart it will get redirect to the index
                                                   //in which will be initialized again
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }
        
        // GET /cart/remove/5
        public IActionResult Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");

            cart.RemoveAll(x => x.ProductId == id);

            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart"); 
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            return RedirectToAction("Index");
        }
        
        // GET /cart/clear
        public IActionResult Clear()
        {
            HttpContext.Session.Remove("Cart");

            //return RedirectToAction("Page", "Pages");
            //return Redirect("/"); // with "/"  redirect us to the root page
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                return Redirect(Request.Headers["Referer"].ToString());  // redirect us to the previous request (i.e. to the same page)

            return Ok();
        }
    }
}