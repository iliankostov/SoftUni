namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class ClassOfStudents : IDetails
    {
        private string uniqueTextIdentifier;
        private List<Teacher> setOfTeachers;

        public ClassOfStudents(string uniqueTextIdentifier, List<Teacher> setOfTeachers, string detail = null)
        {
            this.UniqueTextIdentifier = uniqueTextIdentifier;
            this.setOfTeachers = setOfTeachers;
            this.Detail = detail;
        }

        public string UniqueTextIdentifier
        {
            get
            {
                return this.uniqueTextIdentifier;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The unique text identifier cannot be empty.");
                }

                this.uniqueTextIdentifier = value;
            }
        }

        public string Detail { get; set; }
    }
}