package no.kantega.htmxdemo.repositories;

import no.kantega.htmxdemo.domain.Price;
import no.kantega.htmxdemo.domain.Product;
import org.springframework.stereotype.Component;

import java.math.BigDecimal;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

@Component
public class ProductRepository {

    List<Product> products = new ArrayList<>();

    static int nextId = 1;

    public ProductRepository() {
        // Adding sample product data to the list
        products.add(createProduct("Laptop", "High-performance laptop", "1000.00", "placeholder.png"));
        products.add(createProduct("Smartphone", "Latest model smartphone", "700.00", "placeholder.png"));
        products.add(createProduct("Headphones", "Noise-cancelling headphones", "150.00", "placeholder.png"));
        products.add(createProduct("Smartwatch", "Fitness tracking smartwatch", "250.00", "placeholder.png"));
        products.add(createProduct("Tablet", "Powerful and lightweight tablet", "500.00", "placeholder.png"));
    }

    private static Product createProduct(String name, String description, String price, String image) {
        Product product = new Product(nextId++, name, description, price, image);
        for (int i = 1; i < 6; i++) {
            product.addPrice(new Price(LocalDate.now().minusMonths(i), new BigDecimal(price).subtract(new BigDecimal(10 * i))));
        }
        return product;
    }

    public List<Product> findAll() {
        return products;
    }

    public Product findById(int id) {
        return products.stream().filter(p -> p.getId() == id).findFirst().orElse(null);
    }
}
