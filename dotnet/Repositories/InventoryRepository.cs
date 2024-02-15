using System;
using htmx_test.Models;

namespace htmx_test.Repositories
{
	public class InventoryRepository
	{
        public int FindProductStockById(int productID)
        {
            Random rand = new Random();
            return rand.Next(0, 99);
        }

    }
}

