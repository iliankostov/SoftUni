namespace CompanyHierarchy
{
    public abstract class RegularEmployee : Employee, IRegularEmployee
    {
        public RegularEmployee(int id, string firstName, string lastName, decimal salary, Department department)
            : base(id, firstName, lastName, salary, department)
        {
        }

        public override string ToString()
        {
            return string.Format("Full name: {0} {1}\nID: {2}\n Department: {3}\nSalary: {4:0.00}s", this.FirstName, this.LastName, this.Id, this.Department, this.Salary);
        }
    }
}