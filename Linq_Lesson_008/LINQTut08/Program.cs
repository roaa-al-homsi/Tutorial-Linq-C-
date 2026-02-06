using LINQTut08.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTut08
{
    internal class Program
    {
        class Student
        {
            public string Name { get; set; }
            public string Grade { get; set; }
            public int Score { get; set; }
        }
        static void Main(string[] args)
        {
            RunGroupByExample();
            RunLookupExample();
            RunGroupByWithQuerySyntax();



            Console.ReadKey();
        }

        private static void RunGroupByExample()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("GroupBy (Method Syntax");
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine();

            var employees = Repository.LoadEmployees();

            // IEnumerable<IGrouping<string, Employee>> groups = employees.GroupBy(e => e.Department);

            var groups = employees.GroupBy(x => x.Department);
            foreach (var group in groups)
            {
                group.Print($"Employee in '{group.Key}' Department");
            }
        }

        private static void RunLookupExample()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("ToLookup (Method Syntax");
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine();

            var employees = Repository.LoadEmployees();
            var result = employees.ToLookup(x => x.Department);
            foreach (var item in result)
            {
                item.Print($"Employee in '{item.Key}' Department");
            }
        }

        private static void RunGroupByWithQuerySyntax()
        {
            Console.WriteLine();
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine("GroupBy (Query Syntax");
            Console.WriteLine("+++++++++++++++++++++++");
            Console.WriteLine();

            var employees = Repository.LoadEmployees();

            var result = from emp in employees
                         group emp by emp.Department;

            foreach (var item in result)
            {
                item.Print($"Employee in '{item.Key}' Department");
            }
        }

        private static void RunExampleForStudentsWithGroupBy()
        {

            List<Student> students = new List<Student>
            {
                new Student { Name = "Ali", Grade = "A", Score = 85 },
                new Student { Name = "Mona", Grade = "B", Score = 90 },
                new Student { Name = "Sara", Grade = "A", Score = 75 },
                new Student { Name = "Ahmad", Grade = "C", Score = 60 },
                new Student { Name = "Lina", Grade = "B", Score = 80 },
                new Student { Name = "Zara", Grade = "A", Score = 95 }
            };


            var result = students.GroupBy(s => s.Grade).Select(g => new { Count = g.Count(), Grade = g.Key, Min = g.Min(s => s.Score), Max = g.Max(s => s.Score), Students = g, Average = g.Average(s => s.Score) }).OrderBy(g => g.Grade);

            foreach (var group in result)
            {
                Console.WriteLine("----------------------");
                Console.WriteLine($"Grade:{group.Grade} | Count: {group.Count} | Min: {group.Min} | Max : {group.Max} |Average : {group.Average}");
                Console.WriteLine("----------------------");
                Console.WriteLine("Students:");
                foreach (var item in group.Students)
                {

                    Console.WriteLine(item.Name);
                }
            }

        }
    }
}
