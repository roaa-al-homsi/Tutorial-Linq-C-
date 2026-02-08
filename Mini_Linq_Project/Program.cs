using System;
using System.Collections.Generic;
using System.Linq;

namespace traininng_linq2
{


    // 🔹 Select & SelectMany

    // Print all students’ names.

    // Print all subjects of all students in one single list.


    // 🔹 Filtering

    // Print students whose age is greater than 20.

    // Print students whose score is greater than 80.


    // 🔹 Sorting

    // Sort students by age, then by score in descending order.


    // 🔹 Partitioning

    // Take the first 3 students using Take.

    // Skip the first 2 students using Skip.


    // 🔹 Quantifiers

    // Is there any student whose score is greater than 90?

    // Are all students older than 18?


    // 🔹 GroupBy & Aggregate

    // Calculate the total score for each grade.

    // Calculate the average score for each grade.

    // Print the names of students for each grade.


    // 🔹 Set Operations

    // Perform Union between two subjects.

    // Perform Intersect between two subjects.

    // Perform Except between two subjects.


    // 🔹 Element Operations

    // Get the first student.

    // Get the last student.

    // Get a specific student based on a condition using Single.


    // 🔹 Join

    // Join students with their departments.


    // 🔹 Distinct

    // Get all subjects without duplicates.


    internal class Program
    {
        class Student
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public int Grade { get; set; }
            public List<string> Subjects { get; set; }
            public int Score { get; set; }
            public int DepartmentId { get; set; }
        }
        class Department
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>
{
    new Department { Id = 1, Name = "IT" },
    new Department { Id = 2, Name = "CS" },
    new Department { Id = 3, Name = "Business" }
};


            List<Student> students = new List<Student>
{
    new Student
    {
        Id = 1, Name = "Ali", Age = 20, Grade = 1, Score = 85,
        Subjects = new List<string> { "Math", "Physics" },DepartmentId=1
    },
    new Student
    {
        Id = 2, Name = "Sara", Age = 22, Grade = 2, Score = 92,
        Subjects = new List<string> { "CS", "Math" },DepartmentId=1
    },
    new Student
    {
        Id = 3, Name = "Mona", Age = 19, Grade = 1, Score = 78,
        Subjects = new List<string> { "Physics", "CS" },DepartmentId=2
    },
    new Student
    {
        Id = 4, Name = "Omar", Age = 23, Grade = 3, Score = 88,
        Subjects = new List<string> { "Math", "CS" },DepartmentId=2
    },
    new Student
    {
        Id = 5, Name = "Hala", Age = 21, Grade = 2, Score = 95,
        Subjects = new List<string> { "Physics", "Math" },DepartmentId=2
    },
    new Student
    {
        Id = 6, Name = "Yousef", Age = 20, Grade = 3, Score = 80,
        Subjects = new List<string> { "CS", "Physics" },DepartmentId=3
    }
};

            #region Select & SelectMany
            // Print all students’ names.
            var studentsNames = students.Select(s => s.Name);
            Console.WriteLine(string.Join(",", studentsNames));

            // Print all subjects of all students in one single list.
            var allSubjects = students.SelectMany(s => s.Subjects);
            Console.WriteLine(string.Join(",", allSubjects));
            #endregion


            #region Distinct
            // Get all subjects without duplicates.
            var allSubjectsWithoutRepeat = students.SelectMany(s => s.Subjects).Distinct();
            Console.WriteLine(string.Join(",", allSubjectsWithoutRepeat));
            #endregion


            #region Filtering
            // Print students whose age is greater than 20.
            var studentsAbove20 = students.Where(s => s.Age > 20);
            foreach (var s in studentsAbove20)
            {
                Console.WriteLine($"Name: {s.Name},Age: {s.Age}, Grade:{s.Grade}");
            }

            // Print students whose score is greater than 80.
            var studentsAbove80 = students.Where(s => s.Age > 20).Select(s => s.Name);
            foreach (var s in studentsAbove80)
            {
                Console.WriteLine(s);
            }
            #endregion


            #region Sorting
            // Sort students by age, then by score in descending order.
            var sortOnAge = students.OrderBy(s => s.Age).ToList();
            foreach (var s in sortOnAge)
            {
                Console.WriteLine($"Name: {s.Name},Age: {s.Age}, Grade:{s.Grade},score:{s.Score}");
            }

            Console.WriteLine("******************");

            var sortOnAgeThenScore = students.OrderBy(s => s.Age).ThenByDescending(s => s.Score);
            foreach (var s in sortOnAgeThenScore)
            {
                Console.WriteLine($"Name: {s.Name},Age: {s.Age}, Grade:{s.Grade},score:{s.Score}");
            }
            #endregion


            #region Partitioning
            // Take the first 3 students using Take.
            Console.WriteLine("********take the 3 students**********");
            var the3FirstStudents = sortOnAgeThenScore.Take(3).ToList();
            foreach (var s in the3FirstStudents)
            {
                Console.WriteLine($"Name: {s.Name},Age: {s.Age}, Grade:{s.Grade},score:{s.Score}");
            }

            // Skip the first 2 students using Skip.
            Console.WriteLine("******skip the first 2************");
            var skipThe3Students = the3FirstStudents.Skip(2).ToList();
            foreach (var s in skipThe3Students)
            {
                Console.WriteLine($"Name: {s.Name},Age: {s.Age}, Grade:{s.Grade},score:{s.Score}");
            }
            #endregion


            #region Quantifiers
            // Is there any student whose score is greater than 90?
            Console.WriteLine($" Is student grade it above 90 {students.Any(s => s.Score > 90)}");

            // Are all students older than 18?
            Console.WriteLine($" Are all students ages greater than 18 {students.All(s => s.Age > 18)}");
            #endregion


            #region GroupBy & Aggregate
            // Calculate the total score for each grade.
            // Calculate the average score for each grade.
            // Print the names of students for each grade.
            Console.WriteLine("Grouping By Grade...............");

            var studentsByGrade = students.GroupBy(s => s.Grade).ToList();
            foreach (var group in studentsByGrade)
            {
                Console.WriteLine($"Grade: {group.Key}");
                Console.WriteLine($"Count: {group.Count()}");
                Console.WriteLine($"Min: {group.Min(s => s.Score)}");
                Console.WriteLine($"Max: {group.Max(s => s.Score)}");
                Console.WriteLine($"average: {group.Average(s => s.Score)}");
                Console.WriteLine($"Sum score for all students in one group: {group.Sum(s => s.Score)}");
                Console.WriteLine("Students:");
                foreach (var student in group)
                {
                    Console.WriteLine(student.Name);
                }
                Console.WriteLine("===============");
            }
            #endregion


            #region Join
            // Join students with their departments.
            Console.WriteLine("Join...............");

            var studentWithDepartment = students.Join(
                departments,
                s => s.DepartmentId,
                d => d.Id,
                (st, de) => new { Name = st.Name, Depatment = de.Name }
            ).ToList();

            foreach (var item in studentWithDepartment)
            {
                Console.WriteLine($"Name: {item.Name}, Department: {item.Depatment}");
            }
            #endregion


            #region Set Operations
            // Perform Union between two subjects.

            Student student1 = new Student
            {
                Id = 1,
                Name = "Ali",
                Age = 20,
                Grade = 1,
                Score = 85,
                Subjects = new List<string> { "Math", "Physics" },
                DepartmentId = 1
            };

            Student student2 = new Student
            {
                Id = 2,
                Name = "Sara",
                Age = 22,
                Grade = 2,
                Score = 92,
                Subjects = new List<string> { "CS", "Math" },
                DepartmentId = 1
            };
            Console.WriteLine("====Union======");
            var studentsSubjects = student1.Subjects.Union(student2.Subjects).ToList();
            Console.WriteLine(string.Join(",", studentsSubjects));

            // Perform Intersect between two subjects.
            Console.WriteLine("====Intersect======");
            var subjectsIntersect = student1.Subjects.Intersect(student2.Subjects);
            Console.WriteLine(string.Join(",", subjectsIntersect));

            // Perform Except between two subjects.
            Console.WriteLine("====Except======");
            var subjectsExcept = student1.Subjects.Except(student2.Subjects);
            Console.WriteLine(string.Join(",", subjectsExcept));
            #endregion


            #region Element Operations
            // Get the first student.
            Console.WriteLine("====first student======");
            Student firstStudent = students.ElementAt(0);
            Console.WriteLine($"Name: {firstStudent.Name},Age: {firstStudent.Age}, Grade:{firstStudent.Grade}");

            // Get the last student.
            Console.WriteLine("====Last student======");
            Student lastStudents = students.ElementAt(students.Count() - 1);
            Console.WriteLine($"Name: {lastStudents.Name},Age: {lastStudents.Age}, Grade:{lastStudents.Grade}");

            // Get a specific student based on a condition using Single.
            Console.WriteLine("====specific student using single======");
            Student specificStudent = students.Single(s => s.Age == 23);
            Console.WriteLine($"Name: {specificStudent.Name},Age: {specificStudent.Age}, Grade:{specificStudent.Grade}");
            #endregion


            Console.ReadKey();
        }



    }
}
