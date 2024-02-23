package no.kantega.htmxdemo.web.webshop;

import no.kantega.htmxdemo.repositories.InventoryRepository;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.servlet.ModelAndView;


@RestController
@RequestMapping("/inventory")
public class InventoryController {

    private final InventoryRepository inventoryRepository;

    public InventoryController(InventoryRepository inventoryRepository) {
        this.inventoryRepository = inventoryRepository;
    }

    @GetMapping
    public ModelAndView getItemsInStock(@RequestParam int productId) {
        int itemsInStock = inventoryRepository.getItemsInStock(productId);
        return new ModelAndView("inventory/items-in-stock")
                .addObject("itemsInStock", itemsInStock);
    }
}
