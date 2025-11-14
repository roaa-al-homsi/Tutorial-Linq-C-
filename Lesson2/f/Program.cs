
using PracticeLinqLesson1;
using System;


namespace FunctionalProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  RunExtensionProcedural();
            //RunExtensionProcedural01();
            RunExtensionProcedural02();

            Console.ReadKey();
        }


        public static void RunExtensionProcedural()
        {
            var q1 = ExtensionProcedural.GetEmployeesWithFirstNameStartsWith("ma");
            ExtensionProcedural.Print(q1, "Employees with first name starts with 'ma'");

            var q2 = ExtensionProcedural.GetEmployeesWithLastNameStartsWith("ju");
            ExtensionProcedural.Print(q2, "Employees with last name starts with 'ju'");

            var q3 = ExtensionProcedural.GetEmployeesWithDepartmentEqualsTo("hr");
            ExtensionProcedural.Print(q3, "Employees in 'HR' department");

            var q4 = ExtensionProcedural.GetEmployeesByGender("female");
            ExtensionProcedural.Print(q4, "Female employees");

            var q5 = ExtensionProcedural.GetEmployeesHiredInYear(2018);
            ExtensionProcedural.Print(q5, "Employees hired in '2018'");

            var q6 = ExtensionProcedural.GetEmployeesWithPensionPlanValueEqualsTo(true);
            ExtensionProcedural.Print(q6, "Employees with Pension Plan");

            var q7 = ExtensionProcedural.GetEmployeesWithHealthInsuranceValueEqualsTo(false);
            ExtensionProcedural.Print(q7, "Employees without Health insurance");

            var q8 = ExtensionProcedural.GetEmployeesWithSalaryEqualsTo(103200);
            ExtensionProcedural.Print(q8, "Employees with Salary = $103200");

            var q9 = ExtensionProcedural.GetEmployeesWithSalaryGreaterThan(107000);
            ExtensionProcedural.Print(q9, "Employees with Salary > $107000");

            var q10 = ExtensionProcedural.GetEmployeesWithSalaryLessThan(107000);
            ExtensionProcedural.Print(q10, "Employees with Salary < $107000");


        }
        public static void RunExtensionProcedural01()
        {
            var list = Repository.LoadEmployees();

            var q1 = ExtensionProcedural01.Filter(list, e => e.FirstName.ToLowerInvariant().StartsWith("ma"));
            ExtensionProcedural01.Print(q1, "Employees with first name starts with 'ma'");

            var q2 = ExtensionProcedural01.Filter(list, e => e.LastName.ToLowerInvariant().StartsWith("ju"));
            ExtensionProcedural01.Print(q2, "Employees with last name starts with 'ju'");

            var q3 = ExtensionProcedural01.Filter(list, e => e.Department.ToLowerInvariant() == "hr");
            ExtensionProcedural01.Print(q3, "Employees in 'HR' department");

            var q4 = ExtensionProcedural01.Filter(list, e => e.Gender.ToLowerInvariant() == "female");
            ExtensionProcedural01.Print(q4, "Female employees");

            var q5 = ExtensionProcedural01.Filter(list, e => e.HireDate.Year == 2018);
            ExtensionProcedural01.Print(q5, "Employees hired in '2018'");

            var q6 = ExtensionProcedural01.Filter(list, e => e.HasPensionPlan);
            ExtensionProcedural01.Print(q6, "Employees with Pension Plan");

            var q7 = ExtensionProcedural01.Filter(list, e => !e.HasHealthInsurance);
            ExtensionProcedural01.Print(q7, "Employees without Health insurance");

            var q8 = ExtensionProcedural01.Filter(list, e => e.Salary == 107000);
            ExtensionProcedural01.Print(q8, "Employees with Salary = $107000");

            var q9 = ExtensionProcedural01.Filter(list, e => e.Salary > 107000);
            ExtensionProcedural01.Print(q9, "Employees with Salary > $107000");

            var q10 = ExtensionProcedural01.Filter(list, e => e.Salary < 107000);
            ExtensionProcedural01.Print(q10, "Employees with Salary < $107000");

            var q11 = ExtensionProcedural01.Filter(list, e => e.Salary < 107000 && e.Gender == "female");
            ExtensionProcedural01.Print(q11, "Employees with Salary < $107000 and female");


        }

        public static void RunExtensionProcedural02()
        {
            var list = Repository.LoadEmployees();

            //Extension Methods
            var q1 = list.Filter(e => e.FirstName.ToLowerInvariant().StartsWith("ma"));
            q1.Print("Employees with first name starts with 'ma'");

            var q2 = list.Filter(e => e.LastName.ToLowerInvariant().StartsWith("ju"));
            q2.Print("Employees with last name starts with 'ju'");

            var q3 = list.Filter(e => e.Department.ToLowerInvariant() == "hr");
            q3.Print("Employees in 'HR' department");

            var q4 = list.Filter(e => e.Gender.ToLowerInvariant() == "female");
            q4.Print("Female employees");

            var q5 = list.Filter(e => e.HireDate.Year == 2018);
            q5.Print("Employees hired in '2018'");

            var q6 = list.Filter(e => e.HasPensionPlan);
            q6.Print("Employees with Pension Plan");

            var q7 = list.Filter(e => !e.HasHealthInsurance);
            q7.Print("Employees without Health insurance");

            var q8 = list.Filter(e => e.Salary == 107000);
            q8.Print("Employees with Salary = $107000");

            var q9 = list.Filter(e => e.Salary > 107000);
            q9.Print("Employees with Salary > $107000");

            var q10 = list.Filter(e => e.Salary < 107000);
            q10.Print("Employees with Salary < $107000");

            var q11 = list.Filter(e => e.Salary < 107000 && e.Gender == "female");
            q11.Print("Employees with Salary < $107000 and female");





        }

    }
}
