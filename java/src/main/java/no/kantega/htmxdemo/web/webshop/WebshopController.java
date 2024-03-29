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

    /**
     * Adds a product to the shopping cart, and returns html for the button with a confirmation text.
     */
    @PostMapping("add-to-cart")
    public ModelAndView addToCart(@RequestParam("productId") int productId, @SessionAttribute Cart cart, HttpServletResponse response) {
        Product product = productRepository.findById(productId);

        cart.addProduct(product);
        inventoryRepository.reduceStock(product, 1);

        return new ModelAndView("/webshop/add-to-cart-success")
                .addObject("product", product);
    }

    /**
     * Adds a product to the shopping cart, and returns a full page. This is the endpoint we are getting rid of.
     */
    @PostMapping("add-to-cart-full-reload")
    public ModelAndView addToCartFullReload(@RequestParam("productId") int productId, @SessionAttribute Cart cart, HttpServletResponse response) {
        Product product = productRepository.findById(productId);

        cart.addProduct(product);
        inventoryRepository.reduceStock(product, 1);
        return new ModelAndView("redirect:/webshop");
    }

    @PostMapping("remove-from-cart")
    public void removeFromCart(@RequestParam("productId") int productId, @SessionAttribute Cart cart, HttpServletResponse response) {
        Product product = productRepository.findById(productId);

        cart.removeProduct(product);
        inventoryRepository.increaseStock(product, 1);

        //TODO: Add HX-Trigger http header to trigger cart reload and inventory update
    }

    @PostMapping("remove-from-cart-full-reload")
    public ModelAndView removeFromCartFullReload(@RequestParam("productId") int productId, @SessionAttribute Cart cart, HttpServletResponse response) {
        Product product = productRepository.findById(productId);

        cart.removeProduct(product);
        inventoryRepository.increaseStock(product, 1);

        return new ModelAndView("redirect:/webshop");
    }

    @DeleteMapping("cart")
    public void emptyCart(Cart cart, HttpServletResponse response) {
        for (Cart.CartItem item : cart.getItems()) {
            inventoryRepository.increaseStock(item.getProduct(), item.getQuantity());
        }
        cart.clear();

        //TODO: Add HX-Trigger http header to trigger cart reload and inventory update
    }

    @PostMapping("clear-cart-full-reload")
    public ModelAndView emptyCartFullReload(Cart cart, HttpServletResponse response) {
        cart.clear();
        return new ModelAndView("redirect:/webshop");
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
