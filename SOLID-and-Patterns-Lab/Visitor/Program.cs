namespace CustomerService
{
    using Data;
    using Models;
    using Visitor.Models.Visitors;

    public class Program
    {
        static void Main()
        {
            var repository = new CustomerRepository();

            var discountRaiseVisitor = new DiscountRaiseVisitor();
            var freePurchaseVisitor = new FreePurchaseVisitor();

            var premiumCustomers = repository.GetPremiumCustomers();

            foreach (var premiumCustomer in premiumCustomers)
            {
                discountRaiseVisitor.Visit(premiumCustomer);
            }

            var allCustomers = repository.GetAll();

            foreach (var customer in allCustomers)
            {
                freePurchaseVisitor.Visit(customer);
            }
        }
    }
}
