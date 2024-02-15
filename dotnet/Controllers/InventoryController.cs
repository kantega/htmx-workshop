using htmx_test.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace htmx_test.Controllers
{

    public class InventoryController : Controller
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryController(InventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository; 
        }


        public async Task<ActionResult> Stock(int productID)
        {
            var stock = _inventoryRepository.FindProductStockById(productID);

            Random rand = new Random();
            int randomNumber = rand.Next(500, 6000);

            await Task.Delay(randomNumber);

            return PartialView(stock);
        }
    }
}

