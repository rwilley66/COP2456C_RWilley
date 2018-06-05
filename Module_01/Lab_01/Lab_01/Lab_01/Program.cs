using System;

namespace Module_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 15;
            int num2 = 30;
            int answer1;
            int answer2;

            answer1 = num1 + num2;
            answer2 = num2 / num1;

            Console.WriteLine("The sum of " + num1 + " and " + num2 + " = " + answer1);
            Console.WriteLine(num2 + " divided by " + num1 + " = " + answer2);
        }
    }
}
