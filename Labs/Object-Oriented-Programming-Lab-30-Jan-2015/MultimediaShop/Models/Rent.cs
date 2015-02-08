namespace Models
{
    using System;
    using System.Text;

    using Enumerables;
    using Interfaces;

    internal class Rent : IRent
    {
        private IItem rentItem;

        internal Rent(IItem rentItem)
        {
            this.RentItem = rentItem;
            this.RentDate = DateTime.Now;
            this.Deadline = DateTime.Now.AddDays(30);
        }

        internal Rent(IItem rentItem, DateTime rentDate)
            : this(rentItem)
        {
            this.RentDate = rentDate;
            this.Deadline = this.RentDate.AddDays(30);
        }

        internal Rent(IItem rentItem, DateTime rentDate, DateTime deadline)
            : this(rentItem, rentDate)
        {
            this.Deadline = deadline;
        }

        public IItem RentItem
        {
            get
            {
                return this.rentItem;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(
                        "Invalid rent item!\r\n" +
                        "The rent item cannot be empty or null.\r\n" +
                        "The rent item should have some value.");
                }

                this.rentItem = value;
            }
        }

        public RentState RentState
        {
            get
            {
                if (this.ReturnDate.Year > 1)
                {
                    return RentState.Returned;
                }
                else if (DateTime.Now > this.Deadline)
                {
                    return RentState.Overdue;
                }
                else
                {
                    return RentState.Pending;
                }
            }
        }

        public DateTime RentDate { get; private set; }

        public DateTime Deadline { get; private set; }

        public DateTime ReturnDate { get; private set; }

        public decimal RentFine
        {
            get
            {
                if (this.RentState == RentState.Overdue)
                {
                    decimal dateDifferenceInDays = (decimal)(DateTime.Now - this.Deadline).TotalDays;
                    decimal penaltyFeePerDay = this.RentItem.Price * 0.01m;
                    decimal rentFine = dateDifferenceInDays * penaltyFeePerDay;

                    return rentFine;
                }
                else
                {
                    return 0;
                }
            }
        }

        public void ReturnItem()
        {
            this.ReturnDate = DateTime.Now;
        }

        public override string ToString()
        {
            StringBuilder rentInfo = new StringBuilder();
            rentInfo.AppendLine(string.Format(" - Rent {0}", this.RentState));
            rentInfo.Append(this.RentItem);
            rentInfo.Append(string.Format("\r\n" + "Rent fine: {0:F2}", this.RentFine));

            return rentInfo.ToString();
        }
    }
}