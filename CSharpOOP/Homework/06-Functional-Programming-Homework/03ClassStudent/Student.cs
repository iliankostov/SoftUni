namespace ClassStudent
{
    using System.Collections.Generic;

    internal class Student
    {
        public Student(string firstName, string lastName, int age, string facultyNumber, string phone, string email, IList<int> marks, int groupNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = marks;
            this.GroupNumber = groupNumber;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string FacultyNumber { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IList<int> Marks { get; set; }

        public int GroupNumber { get; set; }

        public override string ToString()
        {
            string marks = string.Join(", ", this.Marks as IEnumerable<int>);
            return string.Format(
                "{0} {1}, faculty number: {2}, group: {3}, age: {4}, phone: {5}, email: {6}, marks: {7}", this.FirstName, this.LastName, this.FacultyNumber, this.GroupNumber, this.Age, this.Phone, this.Email, marks);
        }
    }
}