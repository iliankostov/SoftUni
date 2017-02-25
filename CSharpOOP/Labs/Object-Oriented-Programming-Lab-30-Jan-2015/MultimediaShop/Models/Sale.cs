namespace Models
{
    using System;
    using System.Text;

    using Interfaces;

    internal class Sale : ISale
    {
        private IItem saleItem;

        internal Sale(IItem saleItem)
        {
            this.SaleItem = saleItem;
            this.SaleDate = DateTime.Now;
        }

        internal Sale(IItem saleItem, DateTime saleDate)
            : this(saleItem)
        {
            this.SaleDate = saleDate;
        }

        public IItem SaleItem
        {
            get
            {
                return this.saleItem;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(
                        "Invalid sale item!\r\n" +
                        "The sale item cannot be empty or null.\r\n" +
                        "The sale item should have some value.");
                }

                this.saleItem = value;
            }
        }

        public DateTime SaleDate { get; private set; }

        public override string ToString()
        {
            StringBuilder saleInfo = new StringBuilder();
            saleInfo.AppendLine(string.Format(" - Sale {0:dd-MM-yyyy}", this.SaleDate));
            saleInfo.Append(this.SaleItem);

            return saleInfo.ToString();
        }
    }
}