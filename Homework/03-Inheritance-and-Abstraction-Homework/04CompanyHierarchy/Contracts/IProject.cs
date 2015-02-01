namespace CompanyHierarchy
{
    using System;

    public interface IProject
    {
        string Details
        {
            get;
            set;
        }

        string ProjectName
        {
            get;
            set;
        }

        DateTime ProjectStartDate
        {
            get;
            set;
        }

        ProjectState State
        {
            get;
            set;
        }

        ProjectState CloseProject();
    }
}
