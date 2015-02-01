namespace CompanyHierarchy
{
    using System;

    public class Project : IProject
    {
        private string projectName;
        private DateTime projectStartDate;
        private string details;
        private ProjectState state;

        public Project(string projectName, DateTime projectStartDate, string details, ProjectState state)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.Details = details;
            this.State = state;
        }

        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Your details cannot be empty.");
                }

                this.details = value;
            }
        }

        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Your project name cannot be empty.");
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStartDate
        {
            get
            {
                return this.projectStartDate;
            }

            set
            {
                this.projectStartDate = value;
            }
        }

        public ProjectState State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
            }
        }

        public ProjectState CloseProject()
        {
            this.State = ProjectState.Closed;
            return this.State;
        }

        public override string ToString()
        {
            return string.Format("Project name: {0}\nProject start date: {1}\nDetails: {2}\nState: {3}", this.ProjectName, this.ProjectStartDate.ToString("dd-MM-yyyy"), this.Details, this.State);
        }
    }
}