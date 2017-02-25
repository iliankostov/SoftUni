namespace CustomerService
{
    using Data;
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
                premiumCustomer.Accept(discountRaiseVisitor);
            }

            var allCustomers = repository.GetAll();

            foreach (var customer in allCustomers)
            {
                customer.Accept(freePurchaseVisitor);
            }
        }
    }
}
