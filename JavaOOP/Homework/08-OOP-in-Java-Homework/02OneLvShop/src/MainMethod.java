import core.PurchaseManager;
import enumeration.AgeRestriction;
import models.products.FoodProduct;
import models.Customer;

public class MainMethod {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct("420 Blaze it fgt", 6.90, 1400, AgeRestriction.Adult, "01.03.2015");
        try {
            Customer pecata = new Customer("Pecata", 17, 30.00);
            PurchaseManager.processPurchase(pecata, cigars);
        }
        catch (RuntimeException re) {
            System.out.println(re.getMessage());
        }
        try {
            Customer gopeto = new Customer("Gopeto", 18, 0.44);
            PurchaseManager.processPurchase(gopeto, cigars);
        }
        catch (RuntimeException re) {
            System.out.println(re.getMessage());
        }
    }
}