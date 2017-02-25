namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Developer : RegularEmployee, IDeveloper
    {
        private List<Project> setOfProjects;

        public Developer(int id, string firstName, string lastName, decimal salary, Department department, List<Project> setOfProjects)
            : base(id, firstName, lastName, salary, department)
        {
            this.SetOfProjects = setOfProjects;
        }

        public List<Project> SetOfProjects
        {
            get
            {
                return this.setOfProjects;
            }

            set
            {
                this.setOfProjects = value;
            }
        }

        public override string ToString()
        {
            StringBuilder text = new StringBuilder();
            text.AppendLine("Full name: " + this.FirstName + " " + this.LastName);
            text.AppendLine("ID: " + this.Id);
            text.AppendLine("Department: " + this.Department);
            text.AppendLine("Salary: " + this.Salary);
            text.AppendLine("Set of projects:");
            foreach (var project in this.SetOfProjects)
            {
                text.Append(project);
            }

            return text.ToString();
        }
    }
}