namespace HumanStudentAndWorker
{
    using System;

    public class Worker : Human
    {
        private decimal weekSalary;
        private double workHoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary 
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("The week salary cannot be negative.");
                }

                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay 
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 0d)
                {
                    throw new ArgumentException("The work hours per day cannot be negative.");
                }

                this.workHoursPerDay = value;
            } 
        }

        public decimal MoneyPerHour()
        {
            double workHoursPerWeek = this.workHoursPerDay * 7;
            decimal moneyPerHour = this.weekSalary / (decimal)workHoursPerWeek;
            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} earn {2:0.00} money per hour", this.FirstName, this.LastName, this.MoneyPerHour());
        }
    }
}
