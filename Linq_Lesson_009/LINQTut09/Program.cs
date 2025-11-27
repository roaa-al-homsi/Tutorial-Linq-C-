using LINQTut09.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTut09
{
    internal class Program
    {
        static IEnumerable<Employee> employees = Repository.LoadEmployees();
        static IEnumerable<Department> departments = Repository.LoadDepartment();
        static void Main(string[] args)
        {

            // RunJoin();
            //RunJoinQuerySyntax();
            //RunGroupJoin();
            RunGroupJoinQuerySyntax();
            Console.ReadKey();
        }



        private static void RunJoin()
        {
            var query = employees.Join
                (departments, emp => emp.DepartmentId,
                dept => dept.Id,
                (emp, dept) => new EmployeeDTO
                {
                    FullName = emp.FullName,
                    Department = dept.Name
                });

            foreach (var item in query)
            {
                Console.WriteLine($"{item.FullName} [{item.Department}]");
            }
        }
        private static void RunJoinQuerySyntax()
        {
            var result = from empls in employees
                         join dep in departments
                         on empls.DepartmentId equals dep.Id
                         select new EmployeeDTO
                         {
                             FullName = empls.FullName,
                             Department = dep.Name
                         };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.FullName} [{item.Department}]");
            }
        }

        private static void RunGroupJoin()
        {
            var result = departments.GroupJoin
                  (employees,
                  dep => dep.Id,
                  emps => emps.DepartmentId,
                  (dep, emps) => new GroupDTO
                  {
                      Employees = emps.Select(e => e.FullName).ToList(),
                      Department = dep.Name
                  }
                );

            foreach (var group in result)
            {
                Console.WriteLine($"************Group [{group.Department}]************");


                foreach (var name in group.Employees)
                {
                    Console.WriteLine(name);
                }
            }
        }

        private static void RunGroupJoinQuerySyntax()
        {
            var result = from dt in departments
                         join emps in employees
                         on dt.Id equals emps.DepartmentId
                         into empGroup
                         select empGroup;

            foreach (var group in result)
            {
                Console.WriteLine("****** Goup ********");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.FullName}");
                }
            }

        }



    }
}
