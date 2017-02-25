namespace ClassStudent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class ClassStudentMain
    {
        internal static void Main()
        {
            // Create a List<Student> with sample students
            Console.WriteLine("Problem 3. Class Student");
            List<Student> students = new List<Student>() 
            {
                new Student("George", "Michael", 21, "abc5642014", "02 000 555 666", "george.michael@yahoo.com", new List<int>() { 5, 6, 4, 5, 5, 6 }, 24),
                new Student("Michael", "George", 22, "abc5652013", "+1 999 555 666", "michael.george@gmail.com", new List<int>() { 4, 6, 4, 4, 4, 6 }, 23),
                new Student("Andrew", "Anderson", 20, "abc5662014", "+1 999 888 666", "andrew.anderson@live.com", new List<int>() { 2, 6, 6, 4, 4, 2 }, 24),
                new Student("Smith", "Johnson", 19, "abc5672015", "+1 666 888 333", "smith.johnson@bing.com", new List<int>() { 6, 6, 6, 6, 4, 6 }, 23),
                new Student("Williams", "Brown", 18, "abc5682014", "+1 666 888 666", "smith.johnson@hotmail.com", new List<int>() { 6, 6, 6, 6, 6, 6 }, 24),
                new Student("Davis", "King", 23, "abc5692015", "+1 666 666 666", "davis.king@facebook.com", new List<int>() { 6, 3, 2, 3, 2, 3 }, 24),
                new Student("Martin", "Thompson", 24, "abc5632013", "+3592 333 888 666", "martin.thompson@abv.bg", new List<int>() { 3, 3, 3, 3, 3, 3 }, 23),
                new Student("Clark", "Martinez", 25, "abc5622013", "+359 2 333 333 666", "clark.martinez@abv.bg", new List<int>() { 3, 3, 3, 3, 3, 3 }, 23)
            };
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            // Problem 4. Students by Group
            var studentsByGroup = from student in students
                                  where student.GroupNumber == 23
                                  orderby student.FirstName
                                  select student;

            Console.WriteLine("\nProblem 4. Students by Group");
            foreach (var student in studentsByGroup)
            {
                Console.WriteLine(student);
            }

            // Problem 5. Students by First and Last Name
            var studentsByFirstAndLastName = from student in students
                                             where student.FirstName.CompareTo(student.LastName) < 0                                 
                                             select student;

            Console.WriteLine("\nProblem 5. Students by First and Last Name");
            foreach (var student in studentsByFirstAndLastName)
            {
                Console.WriteLine(student);
            }

            // Problem 6. Students by Age
            var studentsByAge = from student in students
                                where student.Age >= 18 && student.Age <= 24
                                select new { student.FirstName, student.LastName, student.Age };

            Console.WriteLine("\nProblem 6. Students by Age");
            foreach (var student in studentsByAge)
            {
                Console.WriteLine("{0} {1}, age: {2}", student.FirstName, student.LastName, student.Age);
            }

            // Problem 7. Sort Students
            var sortedStudents = students.OrderByDescending(student => student.FirstName).ThenByDescending(student => student.LastName);

            var sortedStudentsLINQ = from student in students
                                     orderby student.FirstName descending, student.LastName descending
                                     select student;

            Console.WriteLine("\nProblem 7. Sort Students");
            foreach (var student in sortedStudentsLINQ)
            {
                Console.WriteLine(student);
            }

            // Problem 8. Filter Students by Email Domain
            var studentsAbvEmail = from student in students
                                   where student.Email.Contains("@abv.bg")
                                   select student;

            Console.WriteLine("\nProblem 8. Filter Students by Email Domain");
            foreach (var student in studentsAbvEmail)
            {
                Console.WriteLine(student);
            }

            // Problem 9. Filter Students by Phone
            var studentsByPhone = from student in students
                                  where student.Phone.StartsWith("02") || student.Phone.StartsWith("+3592") || 
                                        student.Phone.StartsWith("+359 2")
                                  select student;

            Console.WriteLine("\nProblem 9. Filter Students by Phone");
            foreach (var student in studentsByPhone)
            {
                Console.WriteLine(student);
            }

            // Problem 10. Excellent Students
            var excellentStudent = from student in students
                                   where student.Marks.Contains(6)
                                   select new { Fullname = student.FirstName + " " + student.LastName, Marks = student.Marks };

            Console.WriteLine("\nProblem 10. Excellent Students");
            foreach (var student in excellentStudent)
            {
                Console.WriteLine("{0} has marks: {1}", student.Fullname, string.Join(", ", student.Marks));
            }

            // Problem 11. Weak Students
            var weakStudents = students.Where(st => st.Marks.Where(m => m == 2).Count() == 2);

            Console.WriteLine("\nProblem 11. Weak Students");
            foreach (var student in weakStudents)
            {
                Console.WriteLine(student);
            }

            // Problem 12. Students Enrolled in 2014
            var enrolledStudents = from student in students
                                   where student.FacultyNumber.EndsWith("14")
                                   select student;

            Console.WriteLine("\nProblem 12. Students Enrolled in 2014");
            foreach (var student in enrolledStudents)
            {
                Console.WriteLine(student);
            }
        }
    }
}