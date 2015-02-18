namespace InheritanceAndPolymorphism.Contracts
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string CourseName { get; }

        string TeacherName { get; }

        IList<string> Students { get; }
    }
}