namespace MultimediaShop.Models
{
    using System;
    using Interfaces;

    public class Rent : IRenntable
    {
        private Item rentItem;
        public DateTime RentDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime ReturnDate { get; set; }

        public Rent(Item rentItem, DateTime rentDate, DateTime deadline)
        {
            this.RentItem = rentItem;
            this.RentDate = rentDate;
            this.Deadline = deadline;
        }

        public Rent(Item rentItem, DateTime rentDate)
            : this(rentItem, rentDate, rentDate.AddDays(30))
        {           
        }

        public Rent(Item rentItem)
            : this(rentItem, DateTime.Now, DateTime.Now.AddDays(30))
        {
        }

        public RentStatus RentState
        {
            get
            {
                var now = DateTime.Now;

                if (this.IsSetDate(this.ReturnDate))
                {
                    return RentStatus.Returned;
                }
                else if (now > this.Deadline)
                {
                    return RentStatus.Overdue;
                }
                else
                {
                    return RentStatus.Pending;
                }

            }
        }

        public Item RentItem
        {
            get
            {
                return this.rentItem;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Rent Item cannot be null");
                }
                this.rentItem = value;
            }
        }
        private bool IsSetDate(DateTime dateTime)
        {
            return dateTime.Year > 1;
        }

        public decimal RentFine
        {
            get {
                double diff = (this.ReturnDate - this.Deadline).TotalDays;
                decimal fine = (decimal)(diff * 0.01) * this.rentItem.Price;
                return fine;
            }    
        }

        public void ReturnItem()
        {
            this.ReturnDate = DateTime.Now;
        }
    }
}