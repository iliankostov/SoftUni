namespace CompanyHierarchy
{
    using System;

    public interface ISale
    {
        DateTime Date
        {
            get;
            set;
        }

        decimal Price
        {
            get;
            set;
        }

        string ProductName
        {
            get;
            set;
        }
    }
}