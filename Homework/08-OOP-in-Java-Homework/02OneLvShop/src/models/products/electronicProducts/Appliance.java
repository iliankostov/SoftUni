package models.products.electronicProducts;

import enumeration.AgeRestriction;
import models.products.ElectronicProducts;

public class Appliance extends ElectronicProducts {
    private static final int MAX_GUARANTEE_PERIOD = 6;

    public Appliance(String name, double price, int quantity,
                     AgeRestriction ageRestriction) {
        super(name, price, quantity, ageRestriction, MAX_GUARANTEE_PERIOD);
    }

    @Override
    public double getPrice() {

        if(this.getQuantity() <= 50){
            return super.getPrice() * 1.05;
        }

        return super.getPrice();
    }
}
