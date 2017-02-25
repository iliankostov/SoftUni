namespace CompanyHierarchy
{
    using System;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private Department department;

        public Employee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.Department = department;
        }

        public Department Department
        {
            get
            {
                return this.department;
            }

            set
            {
                this.department = value;
            }
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value < 0M)
                {
                    throw new ArgumentException("The salary cannot be negative.");
                }

                this.salary = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Full name: {0} {1}\nID: {2}\n Department: {3}\nSalary: {4:0.00}", this.FirstName, this.LastName, this.Id, this.Department, this.Salary);
        }
    }
}