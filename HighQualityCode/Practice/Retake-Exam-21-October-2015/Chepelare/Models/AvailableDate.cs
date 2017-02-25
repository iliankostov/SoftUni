namespace Chepelare.Models
{
    using System;

    public class AvailableDate
    {
        private DateTime endDate;

        public AvailableDate(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public DateTime StartDate { get; internal set; }

        public DateTime EndDate
        {
            get
            {
                return this.endDate;
            }

            internal set
            {
                if (this.StartDate > value)
                {
                    throw new ArgumentException("The date range is invalid.");
                }

                this.endDate = value;
            }
        }
    }
}