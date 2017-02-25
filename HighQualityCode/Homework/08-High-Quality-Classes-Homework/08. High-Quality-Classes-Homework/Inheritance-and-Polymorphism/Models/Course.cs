namespace InheritanceAndPolymorphism.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;

    public abstract class Course : ICourse
    {
        private string courseName;
        private string teacherName;
        private IList<string> students = new List<string>();

        protected Course(string courseName)
        {
            this.CourseName = courseName;
        }

        protected Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string CourseName
        {
            get
            {
                return this.courseName;
            }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be null, empty, or consist only of white-space characters.");
                }

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            protected internal set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course teacher cannot be null, empty, or consist only of white-space characters.");
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            get
            {
                return this.students;
            }

            protected internal set
            {
                if (value == null || value.All(str => string.IsNullOrWhiteSpace(str)))
                {
                    throw new ArgumentNullException("The students list cannot be null, empty, or consist of string that include only white-space characters.");
                }

                this.students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder courseInfo = new StringBuilder();

            courseInfo.Append(this.CourseName);
            if (this.TeacherName != null)
            {
                courseInfo.Append("; Teacher = ");
                courseInfo.Append(this.TeacherName);
            }

            courseInfo.Append("; Students = ");
            courseInfo.Append(this.GetStudentsAsString());

            return courseInfo.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}
