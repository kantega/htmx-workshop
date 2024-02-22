package no.kantega.htmxdemo.web.webshop;


import jakarta.servlet.http.HttpServletResponse;
import no.kantega.htmxdemo.domain.Product;
import no.kantega.htmxdemo.repositories.InventoryRepository;
import no.kantega.htmxdemo.repositories.ProductRepository;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

import java.util.List;

@Controller
@RequestMapping("/webshop")
@SessionAttributes("cart")
public class WebshopController {

    private final ProductRepository productRepository;
    private final InventoryRepository inventoryRepository;

    public WebshopController(ProductRepository productRepository, InventoryRepository inventoryRepository) {
        this.productRepository = productRepository;
        this.inventoryRepository = inventoryRepository;
    }

    @ModelAttribute("cart")
    public Cart cart() {
        return new Cart();
    }

    @GetMapping
    public ModelAndView index(Cart cart) {
        return new ModelAndView("/webshop/index")
                .addObject("products", productRepository.findAll())
                .addObject("cart", cart);
    }

    @GetMapping("cart")
    public ModelAndView cart(Cart cart) {
        return new ModelAndView("/webshop/cart")
                .addObject("cart", cart);
    }

    @GetMapping("search")
    public ModelAndView search(@RequestParam("q") String q) {
        List<Product> products = productRepository.findByName(q);
        return new ModelAndView("/webshop/products")
                .addObject("products", products);
    }

    @PostMapping("add-to-cart")
    public ModelAndView addToCart(@RequestParam("productId") int productId, @SessionAttribute Cart cart, HttpServletResponse response) {
        Product product = productRepository.findById(productId);

        cart.addProduct(product);
        inventoryRepository.reduceStock(product, 1);

        response.setHeader("HX-Trigger", "cart-updated");
        return new ModelAndView("/webshop/add-to-target-success")
                .addObject("product", product);
    }

    @GetMapping("shipping-info")
    public ModelAndView getShippingInfo(@SessionAttribute Cart cart) {
        int remaining = 1000 - cart.getTotal().intValue();
        boolean freeShipping = remaining <= 0;

        return new ModelAndView("/webshop/shipping-info")
                .addObject("freeShipping", freeShipping)
                .addObject("remaining", remaining);
    }
}
