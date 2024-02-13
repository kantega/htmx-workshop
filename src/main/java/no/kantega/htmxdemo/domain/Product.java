package no.kantega.htmxdemo.domain;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.stream.Collectors;

public class Product {
    private int id;
    // Attributes
    private String name;
    private String description;
    private BigDecimal price;
    private int stockQuantity;

    private List<Price> prices = new ArrayList<>();

    // Constructor
    public Product(int id, String name, String description, String price, int stockQuantity) {
        this.id = id;
        this.name = name;
        this.description = description;
        this.price = new BigDecimal(price);
        this.stockQuantity = stockQuantity;
    }

    public int getId() {
        return id;
    }

    // Getters and Setters
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public BigDecimal getPrice() {
        List<Price> prices = getPrices();
        return prices.isEmpty() ? BigDecimal.ZERO : prices.get(0).getAmount();
    }

    public void addPrice(Price p) {
        p.setId(prices.size());
        prices.add(p);
    }

    public void deletePrice(int id) {
        prices.stream()
                .filter(p -> p.getId() == id)
                .findFirst()
                .ifPresent(price -> prices.remove(price));
    }

    public List<Price> getPrices() {
        return prices.stream()
                .sorted(Comparator.comparing(Price::getValidFrom).reversed())
                .collect(Collectors.toList());
    }

    public int getStockQuantity() {
        return stockQuantity;
    }

    public void setStockQuantity(int stockQuantity) {
        this.stockQuantity = stockQuantity;
    }

    // Methods
    public boolean isAvailable() {
        return stockQuantity > 0;
    }

    @Override
    public String toString() {
        return String.format(
                "Product: %s\nDescription: %s\nPrice: %.2f\nStock: %d",
                name, description, price, stockQuantity);
    }
}
