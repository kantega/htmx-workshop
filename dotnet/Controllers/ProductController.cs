using htmx_test.Models;
using htmx_test.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace htmx_test.Controllers
{
    public class ProductController : Controller
    {   
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
       
            ViewBag.productList = _productRepository.GetAllProducts();
            ViewBag.cartList = _productRepository.GetAllProductsInCart(); 

            return View();
        }

        public IActionResult Search(String searchText)
        {
            var _productList = _productRepository.GetAllProducts();
            _productList.Where(p => p.Title.Contains(searchText)).ToList();

            return PartialView(_productList);
        }

        public IActionResult Cart()
        {
            return PartialView(_productRepository.GetAllProductsInCart());
        }


        public IActionResult AddToCart(int productID)
        {
            _productRepository.AddProductToCart(productID);
            Response.Headers.Add("HX-trigger", "add-to-shopping-cart");

            return PartialView();
         
        }

        public IActionResult Remove(int productID)
        {
            var cartProduct = _productRepository.FindProductById(productID);

            cartProduct.inCart--;

            if (cartProduct.inCart > 0) {
                return PartialView(cartProduct);
            } 

            _productRepository.RemoveProductFromCart(cartProduct);
            
            return PartialView();

        }


        public IActionResult ClearCart()
        {
            _productRepository.RemoveAllProductsFromCart();
            return RedirectToAction("Cart");
        }
       
    }
}

