using System.Collections.Generic;

namespace PracticeLinqLesson1
{
    public static class ExtensionProcedural
    {
        public static IEnumerable<Employee> GetEmployeesWithFirstNameStartsWith(string value)
        {
            var employees = Repository.LoadEmployees();
            foreach (var emp in employees)
            {
                if (emp.FirstName.StartsWith(value))
                {
                    yield return emp;
                };

            }
        }


    }
}
