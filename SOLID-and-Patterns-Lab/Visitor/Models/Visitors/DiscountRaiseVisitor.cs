namespace Visitor.Models.Visitors
{
    using Contracts;
    using CustomerService.Models;

    class DiscountRaiseVisitor : ICustomerVisitor
    {

        public void Visit(Customer customer)
        {
            if (customer != null)
            {
                customer.RaiseDiscount(5.0);
            }
        }
    }
}
