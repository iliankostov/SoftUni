namespace CompanyHierarchy
{
    using System;

    public class Customer : Person, ICustomer
    {
        private decimal purchaseAmount;

        public Customer(int id, string firstName, string lastName, decimal purchaseAmount)
            : base(id, firstName, lastName)
        {
            this.PurchaseAmount = purchaseAmount;
        }

        public decimal PurchaseAmount
        {
            get
            {
                return this.purchaseAmount;
            }

            set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("The purchase amount cannot be negative.");
                }

                this.purchaseAmount = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Full name: {0} {1}\nID: {2}\nPurchase amount: {3:0.00}", this.FirstName, this.LastName, this.Id, this.PurchaseAmount);
        }
    }
}