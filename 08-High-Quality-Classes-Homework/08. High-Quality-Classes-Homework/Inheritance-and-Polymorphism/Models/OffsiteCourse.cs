namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string courseName)
            : base(courseName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students, string town)
            : base(courseName, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "Invalid offsite course town name caught at InheritanceAndPolymorphism.OffsiteCourse.Town!" +
                        "Offsite course town name cannot be null, empty, or consist only of white-space characters.");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder offsiteCourseInfo = new StringBuilder();
            offsiteCourseInfo.Append("OffsiteCourse { Name = ");
            offsiteCourseInfo.Append(base.ToString());
            if (this.Town != null)
            {
                offsiteCourseInfo.Append("; Town = ");
                offsiteCourseInfo.AppendFormat("{0};", this.Town);
            }

            offsiteCourseInfo.Append(" }");

            return offsiteCourseInfo.ToString();
        }
    }
}
