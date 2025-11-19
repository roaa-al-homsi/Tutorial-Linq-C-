using LinqLesson3_Intro_for_Linq_;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 4, 6, 6 };
            // var evenNum = numbers.Where(x => x % 2 == 0);
            IEnumerable<int> evenNumUsingExtensionWhere = numbers.Where(x => x % 2 == 0);//Lazy Loading,,

            //evenNum = evenNum.Where(x => x > 6);
            //numbers.Add(10);
            //numbers.Remove(4);
            //foreach (int x in evenNum)//enumeration
            //{
            //    Console.WriteLine(x);
            //}
            // var f = new ArrayList { 1, true, "HI" };
            // var mm=  f.where();


            var EvenNumUsingWhereMehtod = Enumerable.Where(numbers, x => x % 2 == 0);
            var EvenNumUsingQuerySyntax =
                from n in numbers
                where n % 2 == 0
                select n;

            evenNumUsingExtensionWhere.Print("evenNumUsingExtensionWhere");
            EvenNumUsingWhereMehtod.Print("EvenNumUsingWhereMehtod");
            EvenNumUsingQuerySyntax.Print("EvenNumUsingQuerySyntax");






            Console.ReadKey();
        }
    }
}
