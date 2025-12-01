using Shared;
using System;
using System.Linq;

namespace LINQTut11.ElementAt
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var questions = QuestionBank.All;

            var questionAt10 = questions.ElementAt(10);

            // var questionAt300 = questions.ElementAt(300); ArugumentOutOfRangeException
            var questionAt300 = questions.ElementAtOrDefault(300);

            if (questionAt300 is null)
            {

            }


            //Console.WriteLine(questionAt300);
            var questionsAt400 = questions.ElementAtOrDefault(400);
            // Console.WriteLine(questionsAt400);
            Console.WriteLine(questions.ElementAtOrDefault(400) is null ? "Null" : questions.ElementAtOrDefault(400));
            Console.ReadKey();
        }
    }
}
