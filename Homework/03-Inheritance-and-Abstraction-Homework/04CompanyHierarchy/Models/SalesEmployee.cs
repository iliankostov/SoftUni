namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private List<Sale> setOfSales;

        public SalesEmployee(int id, string firstName, string lastName, decimal salary, Department department, List<Sale> setOfSales)
            : base(id, firstName, lastName, salary, department)
        {
            this.SetOfSales = setOfSales;
        }

        public List<Sale> SetOfSales
        {
            get
            {
                return this.setOfSales;
            }

            set
            {
                this.setOfSales = value;
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Full name: " + this.FirstName + " " + this.LastName);
            text.AppendLine("ID: " + this.Id);
            text.AppendLine("Department: " + this.Department);
            text.AppendLine("Salary: " + this.Salary);
            text.AppendLine("Set of sales:");
            foreach (var sale in this.setOfSales)
            {
                text.Append(sale);
            }

            text.AppendLine("\n");

            return text.ToString();
        }
    }
}