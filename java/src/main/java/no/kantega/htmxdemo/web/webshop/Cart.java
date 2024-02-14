package no.kantega.htmxdemo.web.webshop;

import no.kantega.htmxdemo.domain.Product;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

public class Cart {
    private List<CartItem> items = new ArrayList<>();

    public void addProduct(Product product) {
        CartItem item = getOrAddItem(product);
        item.quantity += 1;
    }

    public CartItem getOrAddItem(Product product) {
        for (CartItem item : items) {
            if (item.product.equals(product)) {
                return item;
            }
        }
        CartItem item = new CartItem(product, 0);
        items.add(item);
        return item;
    }

    public List<CartItem> getItems() {
        return items.stream()
                .sorted(Comparator.comparing(i -> i.getProduct().getId()))
                .toList();
    }

    public BigDecimal getTotal() {
        return items.stream().map(CartItem::getSum).reduce(BigDecimal.ZERO, BigDecimal::add);
    }

    public class CartItem {
        private Product product;
        private int quantity;

        public CartItem(Product product, int quantity) {
            this.product = product;
            this.quantity = quantity;
        }

        public BigDecimal getSum() {
            return product.getPrice().multiply(new BigDecimal(quantity));
        }

        public Product getProduct() {
            return product;
        }

        public void setProduct(Product product) {
            this.product = product;
        }

        public int getQuantity() {
            return quantity;
        }

        public void setQuantity(int quantity) {
            this.quantity = quantity;
        }
    }
}
