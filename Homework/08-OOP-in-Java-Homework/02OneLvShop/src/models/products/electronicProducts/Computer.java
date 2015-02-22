package models.products.electronicProducts;

import enumeration.AgeRestriction;
import models.products.ElectronicProducts;

public class Computer extends ElectronicProducts {
    private static final int MAX_GUARANTEE_PERIOD = 24;

    public Computer(String name, double price, int quantity,
                    AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, MAX_GUARANTEE_PERIOD);
    }

    @Override
    public double getPrice() {

        if(this.getQuantity() <= 1000){
            return super.getPrice() * 0.95;
        }

        return super.getPrice();
    }
}
