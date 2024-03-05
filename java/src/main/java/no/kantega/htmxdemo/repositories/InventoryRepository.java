package no.kantega.htmxdemo.repositories;

import no.kantega.htmxdemo.domain.Product;
import org.springframework.stereotype.Component;

import java.util.HashMap;
import java.util.Map;

@Component
public class InventoryRepository {

    private Map<Integer, Integer> productItemsInStock = new HashMap<>();

    /**
     * Really slow inventory.
     *
     * @param productId the product you want inventory for
     * @return The number of items in stock for a particular product id, after two seconds of work
     */
    public int getItemsInStockSlow(int productId) {
        try {
            Thread.sleep((long) (500 + (Math.random() * 1000)));
        } catch (Exception ignored) {
        }

        return getItemsInStock(productId);
    }

    private Integer getItemsInStock(int productId) {
        return productItemsInStock.computeIfAbsent(productId, k -> (int) (Math.random() * 40));
    }

    public void reduceStock(Product product, int count) {
        int currentStock = getItemsInStock(product.getId());
        productItemsInStock.put(product.getId(), currentStock - count);
    }

    public void increaseStock(Product product, int count) {
        int currentStock = productItemsInStock.get(product.getId());
        productItemsInStock.put(product.getId(), currentStock + count);
    }
}
