namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public interface ISalesEmployee
    {
        List<Sale> SetOfSales
        {
            get;
            set;
        }
    }
}