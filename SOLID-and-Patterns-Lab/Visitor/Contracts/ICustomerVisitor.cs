namespace Visitor.Contracts
{
    using CustomerService.Models;

    public interface ICustomerVisitor
    {
        void Visit(Customer customer);
    }
}