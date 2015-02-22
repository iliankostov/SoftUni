package models.products;

import enumeration.AgeRestriction;
import models.Product;

public abstract class ElectronicProducts extends Product {

    public int guaranteePeriodInMonths;

    public ElectronicProducts(String name, double price, int quantity,
                             AgeRestriction ageRestriction, int guaranteePeriodInMonths ) {
        super(name, price, quantity, ageRestriction);
        this.guaranteePeriodInMonths = guaranteePeriodInMonths;
    }
}
