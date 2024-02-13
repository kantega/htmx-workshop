package no.kantega.htmxdemo.web.webshop;


import no.kantega.htmxdemo.domain.Product;
import no.kantega.htmxdemo.repositories.ProductRepository;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.servlet.ModelAndView;

@Controller
@RequestMapping("/webshop")
@SessionAttributes("cart")
public class WebshopController {

    private final ProductRepository productRepository;

    public WebshopController(ProductRepository productRepository) {
        this.productRepository = productRepository;
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

    @PostMapping("add-to-cart")
    public ModelAndView addToCart(@RequestParam("productId") int productId, @SessionAttribute Cart cart) {
        Product product = productRepository.findById(productId);

        cart.addProduct(product);

        return new ModelAndView("/webshop/cart")
                .addObject("cart", cart);
    }
}
