using ECommerce.Business.Abstraction;
using ECommerce.Entity.Concretes;
using ECommerce.WebUI.Models;
using ECommerce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly ICartSessionService _sessionService;
        private readonly IProductService _productService;

        public CartController(ICartService cartService, ICartSessionService sessionService, IProductService productService)
        {
            _cartService = cartService;
            _sessionService = sessionService;
            _productService = productService;
        }

        public async Task<IActionResult> AddToCart(int productId, int page, int category)
        {
            var item = await _productService.GetByIdAsync(productId);
            var cart = _sessionService.GetCart();
            _cartService.AddList(item, cart);
            _sessionService.SetCart(cart);

            TempData.Add("message", String.Format("Your Product, {0} was added successfully to cart", item.ProductName));


            return RedirectToAction("Index", "Product", new { page = page, category = category });
        }

        public IActionResult List() {
            var list = new CartListViewModel
            {
                Cart = _sessionService.GetCart(),
            };
            return View(list);
        }
        public IActionResult Remove(int productId)
        {
            var cart = _sessionService.GetCart();
            _cartService.DeleteList(productId, cart);
            _sessionService.SetCart(cart);
            TempData.Add("message", "Your Product removed successfully from cart");

            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Complete()
        {
            var list = new ShippingDetailViewModel
            {
                ShippingDetails = new ShippingDetail()
            };
            return View(list);
        }

        [HttpPost]
        public IActionResult Complete(ShippingDetailViewModel shippingDetail)
        {
            if (!ModelState.IsValid)
            {
                return View(shippingDetail);
            }
            TempData.Add("message", String.Format("Thank you {0} , you order is in Progress", shippingDetail.ShippingDetails.FirstName));


            return RedirectToAction("List");
        }

        [HttpPost]

        public IActionResult Decrement(int id)
        {
            var cart = _sessionService.GetCart();
            _cartService.Decrement(id, cart);
            _sessionService.SetCart(cart);
            return RedirectToAction("List");
        }
        [HttpPost]

        public IActionResult Increment(int id)
        {
            var cart = _sessionService.GetCart();
            _cartService.Increment(id, cart);
            _sessionService.SetCart(cart);
            return RedirectToAction("List");
        }

    }
}
