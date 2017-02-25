namespace CompanyHierarchy
{
    using System;
    using System.Collections.Generic;

    public interface IDeveloper
    {
        List<Project> SetOfProjects
        {
            get;
            set;
        }
    }
}