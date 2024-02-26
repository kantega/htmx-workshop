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

        [Route("/inventory")]
        public IActionResult Stock(int productID)
        {
            var stock = _inventoryRepository.GetItemsInStock(productID);

            return PartialView(stock);
        }
    }
}

