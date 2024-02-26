using System;
using htmx_test.Models;

namespace htmx_test.Repositories
{
	public class ProductRepository
	{
		private List<Product> _products;
        private Cart _cart;

        public ProductRepository()
		{
            _cart = new Cart();
            _products = new List<Product>
                {
                    new Product { ID = 1, Name = "Fig plant", Description = "Want to grow some figs? Hell yeah!", Price = 299.99m, Image = "pictures/fig-plant.jpg"},
                    new Product { ID = 2, Name = "Cactus", Description = "Be aware of the spikes!", Price = 349.00m, Image = "pictures/cactus.webp" },
                    new Product { ID = 3, Name = "Green plant", Description = "Generic green plant", Price = 199.49m, Image = "pictures/generic-green-plant.png" },
                    new Product { ID = 4, Name = "Monstera", Description = "Cool", Price = 159.00m, Image = "pictures/monstera.webp" },
                    new Product { ID = 5, Name = "Soap", Description = "Fooo", Price = 1.99m },
                    new Product { ID = 6, Name = "Air pods pro", Description = "Fooo", Price = 249.99m },
                    new Product { ID = 7, Name = "Barebells - Protein bar", Description = "Fooo", Price = 1.99m },
                };
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product FindProductById(int productID)
        {
            return _products.FirstOrDefault(p => p.ID == productID);
        }

        public IEnumerable<Cart.CartItem> GetAllProductsInCart()
        {
            return _cart.GetItems();
        }

        public Cart.CartItem FindProductInCartById(int productID)
        {
            return _cart.GetItems().FirstOrDefault(p => p.Product.ID == productID);
        }

        public void AddProductToCart(Product product)
        {
            var item = _cart.GetOrAddItem(product);
            item.Quantity++; 
        }

        public void RemoveProductFromCart(Product product)
        {
            _cart.RemoveProduct(product); 
          
        }

        public void ClearCart()
        {
            _cart.Clear(); 
        }

        public decimal getCartTotal()
        {
            return _cart.GetTotal(); 
        }

        public IEnumerable<Product> findByName(String q)
        {
           return _products.Where(p => p.Name.Contains(q)).ToList();
        }

    }
}

