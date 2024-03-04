using System.Net;
using htmx_test.Models;
using htmx_test.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace htmx_test.Controllers
{
    public class WebshopController : Controller
    {
        private readonly ProductRepository _productRepository;
        private readonly InventoryRepository _inventoryRepository;

        private readonly SessionManager _sessionManager;

        public WebshopController(ProductRepository productRepository, InventoryRepository inventoryRepository, SessionManager sessionManager)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _sessionManager = sessionManager;
        }


        public IActionResult Index()
        {
            ViewBag.productList = _productRepository.GetAllProducts();
            ViewBag.cartList = GetCart().GetItems();
            ViewBag.totalSum = GetCart().GetTotal();

            return View("/Views/Webshop/Index.cshtml");
        }

        public IActionResult Cart()
        {
            ViewBag.cartList = GetCart().GetItems();
            ViewBag.totalSum = GetCart().GetTotal();

            return PartialView("/Views/Webshop/Cart.cshtml");
        }

        public IActionResult Search(String q)
        {
            ViewBag.productList = _productRepository.GetAllProducts();
            if (q != null)
            {
                ViewBag.productList = _productRepository.findByName(q);
            }

            return PartialView("/Views/Webshop/Products.cshtml");
        }

        [Route("webshop/add-to-cart")]
        public IActionResult AddToCart(int productId)
        {

            var product = _productRepository.FindProductById(productId);

            GetCart().AddProduct(product);
            _inventoryRepository.ReduceStock(product, 1);

          
            ViewBag.product = product;

            return PartialView("/Views/Webshop/add-to-cart-success.cshtml");

        }

        [Route("webshop/add-to-cart-full-reload")]
        public void AddToCartFullReload(int productId)
        {

            var product = _productRepository.FindProductById(productId);

            GetCart().AddProduct(product);
            _inventoryRepository.ReduceStock(product, 1);

            Response.Redirect("/webshop");

        }


        [Route("webshop/remove-from-cart")]
        public void RemoveFromCart(int productId)
        {
            var product = _productRepository.FindProductById(productId);
            GetCart().RemoveProduct(product);

            _inventoryRepository.IncreaseStock(product, 1);


            Response.Headers.Add("HX-Trigger", "cart-updated, stock-updated-" + productId);

        }

        [HttpDelete]
        [Route("webshop/cart")]
        public void EmptyCart()
        {
            List<string> events = new List<string>();
            var cart = GetCart().GetItems();
            foreach (var item in cart)
            {
                _inventoryRepository.IncreaseStock(item.Product, item.Quantity);
                events.Add("stock-updated-" + item.Product.ID);
            }
            GetCart().Clear();
            events.Add("cart-updated");
            Response.Headers.Add("HX-Trigger", String.Join(", ", events));
        }

        [Route("webshop/shipping-info")]
        public IActionResult ShippingInfo()
        {

            var remaining = 1000 - GetCart().GetTotal();

            ViewBag.remaining = remaining;
            ViewBag.freeShipping = remaining <= 0;
            return PartialView("/Views/Webshop/ShippingInfo.cshtml");
        }

        public Cart GetCart()
        {
            var sessionid = Request.Cookies["JSESSIONID"];
            return _sessionManager.GetCart(sessionid!);
        }
    }
}

