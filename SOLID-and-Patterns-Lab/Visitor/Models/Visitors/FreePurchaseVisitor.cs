namespace Visitor.Models.Visitors
{
    using Contracts;
    using CustomerService.Models;

    class FreePurchaseVisitor : ICustomerVisitor
    {
        public void Visit(Customer customer)
        {
            if (customer != null )
            {
                customer.AddFreePurchase(new Purchase("SteamOp", 0.0));
            }
        }
    }
}
