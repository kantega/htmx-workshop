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

        [HttpGet]
        [Route("webshop/cart")]
        public IActionResult Cart()
        {
            ViewBag.cartList = GetCart().GetItems();
            ViewBag.totalSum = GetCart().GetTotal();

            return PartialView("/Views/Webshop/Cart.cshtml");
        }

        [HttpGet]
        [Route("webshop/search")]
        public IActionResult Search(String q)
        {
            ViewBag.productList = _productRepository.GetAllProducts();
            if (q != null)
            {
                ViewBag.productList = _productRepository.findByName(q);
            }

            return PartialView("/Views/Webshop/Products.cshtml");
        }

        // Adds a product to the shopping cart, and returns html for the button with a confirmation text.
        [HttpGet]
        [Route("webshop/add-to-cart")]
        public IActionResult AddToCart(int productId)
        {

            var product = _productRepository.FindProductById(productId);

            GetCart().AddProduct(product);
            _inventoryRepository.ReduceStock(product, 1);

          
            ViewBag.product = product;

            return PartialView("/Views/Webshop/add-to-cart-success.cshtml");

        }


        // Adds a product to the shopping cart, and returns a full page. This is the endpoint we are getting rid of.
        [HttpPost]
        [Route("webshop/add-to-cart-full-reload")]
        public void AddToCartFullReload(int productId)
        {

            var product = _productRepository.FindProductById(productId);

            GetCart().AddProduct(product);
            _inventoryRepository.ReduceStock(product, 1);

            Response.Redirect("/webshop");

        }

        [HttpPost]
        [Route("webshop/remove-from-cart")]
        public void RemoveFromCart(int productId)
        {
            var product = _productRepository.FindProductById(productId);
            GetCart().RemoveProduct(product);

            _inventoryRepository.IncreaseStock(product, 1);

            // TODO: Add HX-Trigger http header to trigger cart reload and inventory update

        }


        [Route("webshop/remove-from-cart-full-reload")]
        public void RemoveFromCartFullReload(int productId)
        {
            var product = _productRepository.FindProductById(productId);
            GetCart().RemoveProduct(product);

            _inventoryRepository.IncreaseStock(product, 1);


            Response.Redirect("/webshop");

        }

        [HttpDelete]
        [Route("webshop/cart")]
        public void EmptyCart()
        {
            var cart = GetCart().GetItems();
            foreach (var item in cart)
            {
                _inventoryRepository.IncreaseStock(item.Product, item.Quantity);
            }
            GetCart().Clear();

            // TODO: Add HX-Trigger http header to trigger cart reload and inventory update
        }

        [HttpPost]
        [Route("webshop/clear-cart-full-reload")]
        public void EmptyCartFullReload()
        {  
            GetCart().Clear();

            Response.Redirect("/webshop");
        }

        [HttpGet]
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

