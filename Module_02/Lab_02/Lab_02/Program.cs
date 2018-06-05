using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_02
{
    class Program
    {
        static void Main(string[] args)
        {
			Random rnd = new Random();
			int[] numbers;
			numbers = new int[5];

			numbers[0] = rnd.Next(1, 500);
			numbers[1] = rnd.Next(1, 500);
			numbers[2] = rnd.Next(1, 500);
			numbers[3] = rnd.Next(1, 500);
			numbers[4] = rnd.Next(1, 500);

			Console.WriteLine("The numbers in the array are: \n");
			foreach (int i in numbers) {
				Console.WriteLine(i);
			}
			Console.WriteLine("\nThe total of the values in the array is: " + numbers.Sum());
        }
    }
}
