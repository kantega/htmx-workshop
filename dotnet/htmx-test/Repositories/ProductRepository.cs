using System;
using htmx_test.Models;

namespace htmx_test.Repositories
{
	public class ProductRepository
	{
		private List<Product> _products;
        private HashSet<Product> _cart;

        public ProductRepository()
		{
            _cart = new HashSet<Product>();
            _products = new List<Product>
                {
                    new Product { ID = 1, Title = "Sunglasses", Price = 10.99m, inStock = 3 },
                    new Product { ID = 2, Title = "Table tennis - table", Price = 19.99m, inStock = 1 },
                    new Product { ID = 3, Title = "Nintendo Switch", Price = 29.99m, inStock = 99 },
                    new Product { ID = 4, Title = "Pencil", Price = 4.59m, inStock = 8 },
                    new Product { ID = 5, Title = "Soap", Price = 1.99m, inStock = 2 },
                    new Product { ID = 6, Title = "Air pods pro", Price = 39.99m, inStock = 29 },
                    new Product { ID = 7, Title = "Barebells - Protein bar", Price = 1.99m, inStock = 11 },
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

        public IEnumerable<Product> GetAllProductsInCart()
        {
            return _cart;
        }

        public Product FindProductInCartById(int productID)
        {
            return _cart.FirstOrDefault(p => p.ID == productID);
        }

        public void AddProductToCart(int productID)
        {
            var product = FindProductById(productID);
            product.inCart++;
            _cart.Add(product);
        }

        public void RemoveProductFromCart(Product product)
        {
            _cart.Remove(product);
        }

        public HashSet<Product> RemoveAllProductsFromCart()
        {
            // For each product in cart, set inCart = 0;
            foreach (var product in _cart)
            {
                product.inCart = 0;
            }
            _cart.Clear();
            return _cart;
        }


    }
}

