using LinqLesson3_Intro_for_Linq_;
using System;
using System.Linq;




namespace Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = Repository.LoadEmployees();

            var empMale = employees.Where(e => e.Gender == "male");

            empMale.Print("Male Employees");

            var empSalaryOver300k = employees.Where(e => e.Salary > 300);
            empSalaryOver300k.Print("Salary over 300k");

            var maleInHRDepartment = empMale.Where(e => e.Department.ToLowerInvariant() == "hr");

            maleInHRDepartment.Print("male in HR");


            Console.ReadKey();
        }
    }
}
