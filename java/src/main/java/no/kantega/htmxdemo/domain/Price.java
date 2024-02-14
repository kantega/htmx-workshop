package no.kantega.htmxdemo.domain;

import java.math.BigDecimal;
import java.time.LocalDate;

public class Price {

    private LocalDate validFrom;
    private BigDecimal amount;

    private int id;

    public Price(LocalDate validFrom, BigDecimal amount) {
        this.validFrom = validFrom;
        this.amount = amount;
    }

    public LocalDate getValidFrom() {
        return validFrom;
    }

    public void setValidFrom(LocalDate validFrom) {
        this.validFrom = validFrom;
    }

    public BigDecimal getAmount() {
        return amount;
    }

    public void setAmount(BigDecimal amount) {
        this.amount = amount;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }
}
