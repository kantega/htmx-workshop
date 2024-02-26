using System;
namespace htmx_test.Models
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();

        public void AddProduct(Product product)
        {
            CartItem item = GetOrAddItem(product);
            item.Quantity += 1;
        }

        public CartItem GetOrAddItem(Product product)
        {
            CartItem item = items.FirstOrDefault(i => i.Product.Equals(product));
            if (item == null)
            {
                item = new CartItem(product, 0);
                items.Add(item);
            }
            return item;
        }

        public List<CartItem> GetItems()
        {
            return items.OrderBy(i => i.Product.ID).ToList();
        }

        public decimal GetTotal()
        {
            return items.Select(item => item.GetSum()).Sum();
        }

        public void RemoveProduct(Product product)
        {
            var item = GetOrAddItem(product);
            item.Quantity--;
            if (item.Quantity < 1) { DeleteProduct(product); }
        }

        public void DeleteProduct(Product product)
        {
            items.RemoveAll(item => item.Product.ID == product.ID);
        }

        public void Clear()
        {
            items.Clear(); 
        }

        public class CartItem
        {
            public Product Product { get; }
            public int Quantity { get; set; }

            public CartItem(Product product, int quantity)
            {
                Product = product;
                Quantity = quantity;
            }

            public decimal GetSum()
            {
                return Product.Price * Quantity;
            }
        }
    }
}

