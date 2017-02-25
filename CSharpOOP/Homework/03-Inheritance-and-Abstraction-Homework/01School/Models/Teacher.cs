namespace School.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class Teacher : Person, IDetails
    {
        private List<Discipline> setOfDisciplines;

        public Teacher(string name, List<Discipline> setOfDisciplines, string detail = null)
            : base(name)
        {
            this.Name = name;
            this.setOfDisciplines = setOfDisciplines;
            this.Detail = detail;
        }

        public string Detail { get; set; }
    }
}