namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public interface IManager
    {
        List<RegularEmployee> SetOfEmployees
        {
            get;
            set;
        }
    }
}
