namespace CompanyHierarchy
{
    public interface IEmployee
    {
        Department Department
        {
            get;
            set;
        }

        decimal Salary
        {
            get;
            set;
        }
    }
}
