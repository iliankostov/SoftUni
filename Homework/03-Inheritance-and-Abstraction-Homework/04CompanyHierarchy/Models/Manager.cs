namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Manager : Employee, IManager
    {
        private List<RegularEmployee> setOfEmployees;

        public Manager(int id, string firstName, string lastName, decimal salary, Department department, List<RegularEmployee> setOfEmployees)
            : base(id, firstName, lastName, salary, department)
        {
            this.SetOfEmployees = setOfEmployees;
        }

        public List<RegularEmployee> SetOfEmployees
        {
            get
            {
                return this.setOfEmployees;
            }

            set
            {
                this.setOfEmployees = value;
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Full name: " + this.FirstName + " " + this.LastName);
            text.AppendLine("ID: " + this.Id);
            text.AppendLine("Department: " + this.Department);
            text.AppendLine("Salary: " + this.Salary);
            text.AppendLine("Set of employees:");
            foreach (var employee in this.setOfEmployees)
            {
                text.Append(employee);               
            }

            return text.ToString();
        }
    }
}