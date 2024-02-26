using htmx_test.Models;
using htmx_test.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace htmx_test.Controllers
{
    public class WebshopController : Controller
    {   
        private readonly ProductRepository _productRepository;
        private readonly InventoryRepository _inventoryRepository;

        public WebshopController(ProductRepository productRepository, InventoryRepository inventoryRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
        }


        public IActionResult Index()
        {
            ViewBag.productList = _productRepository.GetAllProducts();
            ViewBag.cartList = _productRepository.GetAllProductsInCart();
            ViewBag.totalSum = _productRepository.getCartTotal();

            return View("/Views/Webshop/Index.cshtml");
        }

        public IActionResult Cart()
        {
            ViewBag.cartList = _productRepository.GetAllProductsInCart();
            ViewBag.totalSum = _productRepository.getCartTotal(); 

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

            _productRepository.AddProductToCart(product);
            _inventoryRepository.ReduceStock(product, 1); 

            Response.Headers.Add("HX-trigger", "cart-updated, stock-updated-" + productId);
            ViewBag.product = product;

            return PartialView("/Views/Webshop/AddToCart.cshtml");
         
        }


        [Route("webshop/remove-from-cart")]
        public void RemoveFromCart(int productId)
        {
            var product = _productRepository.FindProductById(productId);
            _productRepository.RemoveProductFromCart(product);

            _inventoryRepository.IncreaseStock(product, 1);

    
            Response.Headers.Add("HX-Trigger", "cart-updated, stock-updated-" + productId);

        }

        [HttpDelete]
        [Route("webshop/cart")]
        public void ClearCart()
        {
            List<string> events = new List<string>();
            var cart = _productRepository.GetAllProductsInCart();
            foreach(var item in cart)
            {
                _inventoryRepository.IncreaseStock(item.Product, item.Quantity);
                events.Add("stock-updated-" + item.Product.ID);
            }
            _productRepository.ClearCart();
            events.Add("cart-updated");
            Response.Headers.Add("HX-Trigger", String.Join(", ", events));

        }

        [Route("webshop/shipping-info")]
        public IActionResult ShippingInfo()
        {

            var remaining = 1000 - _productRepository.getCartTotal();

            ViewBag.remaining = remaining;
            ViewBag.freeShipping = remaining <= 0;
            return PartialView("/Views/Webshop/ShippingInfo.cshtml");
        }

    }
}

