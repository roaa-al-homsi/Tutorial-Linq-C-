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
            var evernNum = numbers.Where(x => x % 2 == 0);
            foreach (int x in evernNum)
            {
                Console.WriteLine(x);
            }
            // var f = new ArrayList { 1, true, "HI" };
            // var mm=  f.where();


            Console.ReadKey();
        }
    }
}
