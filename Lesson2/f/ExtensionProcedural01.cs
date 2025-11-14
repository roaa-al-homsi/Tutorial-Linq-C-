using PracticeLinqLesson1;
using System;
using System.Collections.Generic;

namespace FunctionalProgramming
{
    public static class ExtensionProcedural01
    {
        public static IEnumerable<Employee> Filter
            (IEnumerable<Employee> source, Func<Employee, bool> predicate)
        {
            foreach (Employee emp in source)
            {
                {
                    if (predicate(emp))
                    {
                        yield return emp;
                    }
                }
            }

        }


        public static void Print<T>(IEnumerable<T> source, string title)
        {
            if (source == null)
            {
                return;
            }

            Console.WriteLine();
            Console.WriteLine("┌───────────────────────────────────────────────────────┐");
            Console.WriteLine($"│   {title,-52}│");
            Console.WriteLine("└───────────────────────────────────────────────────────┘");
            Console.WriteLine();
            foreach (var item in source)
            {
                Console.WriteLine(item);
            }
        }
    }
}
