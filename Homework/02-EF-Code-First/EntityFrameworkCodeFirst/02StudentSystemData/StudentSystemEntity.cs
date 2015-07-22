namespace EntityFrameworkCodeFirst
{
    using System.Data.Entity;

    public class StudentSystemEntity : DbContext
    {
        public StudentSystemEntity()
            : base("StudentSystemEntity")
        {
        }

        public IDbSet<Student> Students { get; set; }

        public IDbSet<Course> Courses { get; set; }

        public IDbSet<Homework> Homeworks { get; set; }

        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<License> Licenses { get; set; }
    }
}