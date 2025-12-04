using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTut14.Aggregation
{
    internal class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            // RunMethod03();
            RunMethod00();
            Console.ReadKey();

        }
        class Student
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }
        class Summary
        {
            public int TotalScore { get; set; }
            public double AverageScore { get; set; }
            public int Count { get; set; }
        }

        private static void RunMethod04()
        {
            var students = new List<Student>
            {
              new Student { Name = "Alice", Score = 85 },
             new Student { Name = "Bob", Score = 90 },
             new Student { Name = "Charlie", Score = 75 }
            };

            var result = students.Aggregate(new Summary() { TotalScore = 0, AverageScore = 0, Count = 0 }
            , (accumulator, student) =>
            {

                accumulator.TotalScore += student.Score;
                accumulator.Count += 1;
                accumulator.AverageScore = accumulator.TotalScore / accumulator.Count;

                return accumulator;
            }

            );
            Console.WriteLine($"total score={result.TotalScore}");
            Console.WriteLine($"average={result.AverageScore}");
            Console.WriteLine($"count = {result.Count}");


        }

        private static void RunMethod01()
        {
            var names = new[] { "Ali", "Salem", "Abeer", "Reem", "Jalal" };
            // Ali, Salem, ....

            //var output = "";
            //foreach (var item in names)
            //    output += $"{item},";
            //Console.WriteLine(output.TrimEnd(','));

            //var output = string.Join(',', names);
            //Console.WriteLine(output);

            var commaSeparatedNames = names.Aggregate((a, b) =>
            {
                Console.WriteLine($"a = {a}, b = {b}");
                return $"{a},{b}";
            });

        }

        private static void RunMethod02()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };

            //var total = 0;
            //foreach (var n in numbers)
            //    total += n;

            var total = numbers.Aggregate(2, (a, b) => a + b);

            Console.WriteLine($"Total: {total}");
        }


        private static void RunMethod03()
        {
            var quiz = QuestionBank.All;

            var longestQuestionTitle = quiz[0];

            Console.WriteLine($"{longestQuestionTitle}");
            Console.WriteLine("-----");
            longestQuestionTitle =
                quiz.Aggregate(longestQuestionTitle,
                                (longest, next) => longest.Title.Length < next.Title.Length ? next : longest,
                                x => x);



            Console.WriteLine($"{longestQuestionTitle}");
        }
    }
}
