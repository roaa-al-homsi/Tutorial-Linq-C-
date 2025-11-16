using System;
using System.Collections.Generic;

namespace LinqLesson3_Intro_for_Linq_
{
    public static class ExtensionProcedural
    {
        public static void Print<T>(this IEnumerable<T> source, string title)
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
        //Extension Method 
        public static IEnumerable<Employee> Filter
            (this IEnumerable<Employee> source, Func<Employee, bool> predicate)
        {
            foreach (var emp in source)
            {
                if (predicate(emp))
                {
                    yield return emp;
                }
            }
        }








    }
}
