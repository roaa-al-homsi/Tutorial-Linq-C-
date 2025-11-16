using System;
using System.Linq;

namespace LinqLesson3_Intro_for_Linq_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            var employeesWithFirstNameStartWith01 =
                employees.Filter(e => e.Gender == "female" && e.FirstName.ToLowerInvariant().StartsWith("ma"));

            employeesWithFirstNameStartWith01.Print("first name start with {ma}\\filter");

            var employeesWithFirstNameStartWith02 = employees.Where(e => e.Gender == "female" && e.FirstName.ToLowerInvariant().StartsWith("ma"));
            employeesWithFirstNameStartWith02.Print("first name start with {ma}\\where");

            Console.ReadKey();

        }
    }
}
