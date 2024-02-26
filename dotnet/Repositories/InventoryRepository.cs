using System;
using htmx_test.Models;

namespace htmx_test.Repositories
{
	public class InventoryRepository
	{
        private Dictionary<int, int> productItemsInStock = new Dictionary<int, int>();

        /**
          * Really slow inventory.
          *
          * @param productId the product you want inventory for
          * @return The number of items in stock for a particular product id, after two seconds of work
         */
        public int GetItemsInStock(int productId)
        {
            try
            {
                Thread.Sleep(500 + (int)(new Random().NextDouble() * 1000));
            }
            catch (Exception)
            {
                // Ignored
            }

            return productItemsInStock.ContainsKey(productId) ? productItemsInStock[productId] : productItemsInStock[productId] = (int)(new Random().NextDouble() * 40);
        }

        public void ReduceStock(Product product, int count)
        {
            int currentStock = productItemsInStock.ContainsKey(product.ID) ? productItemsInStock[product.ID] : 0;
            productItemsInStock[product.ID] = currentStock - count;
        }

        public void IncreaseStock(Product product, int count)
        {
            int currentStock = productItemsInStock.ContainsKey(product.ID) ? productItemsInStock[product.ID] : 0;
            productItemsInStock[product.ID] = currentStock + count;
        }

    }
}

