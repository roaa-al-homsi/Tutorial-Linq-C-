using System;

namespace PracticeLinqLesson1
{
    //delegate void MDelegate();

    internal class Program
    {
        static void Main(string[] args)
        {
            M2(M1);
            Console.ReadKey();
        }

        public static void M1()
        {
            Console.WriteLine("M1");
        }
        public static void M2(Action action)
        {
            action();
            Console.WriteLine("M2");
        }

    }

}
