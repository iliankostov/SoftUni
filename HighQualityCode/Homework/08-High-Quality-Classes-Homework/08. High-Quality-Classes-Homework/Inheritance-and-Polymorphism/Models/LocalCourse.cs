namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string courseName)
            : base(courseName)
        {
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students, string lab)
            : base(courseName, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(
                        "Invalid local course lab name caught at InheritanceAndPolymorphism.LocalCourse.Lab!" +
                        "Local course lab name cannot be null, empty, or consist only of white-space characters.");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder localCourseInfo = new StringBuilder();
            localCourseInfo.Append("LocalCourse { Name = ");
            localCourseInfo.Append(base.ToString());
            if (this.Lab != null)
            {
                localCourseInfo.Append("; Lab = ");
                localCourseInfo.AppendFormat("{0};", this.Lab);
            }

            localCourseInfo.Append(" }");

            return localCourseInfo.ToString();
        }
    }
}
