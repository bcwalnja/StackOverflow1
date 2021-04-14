using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;
using System.Numerics;

namespace StackOverflow1
{
    class Program
    {

        static void Main(string[] args)
        {
            int first = 0;
            int second = 0;

            while (first < 1)
            {
                Console.WriteLine("Please enter first number");

                string input = Console.ReadLine();
                int.TryParse(input, out first);
            }
            while (second < first)
            {
                Console.WriteLine("Please enter second number");

                string input = Console.ReadLine();
                int.TryParse(input, out second);
            }

            if (second % first == 0)
            {
                Console.WriteLine("It's an even division! There's no remainder.");
            }
            else
            {
                Console.WriteLine($"There was a remainder left over. {second % first}");
            }

            var division = (double)second / (double)first;
            var multiplication = (double)second * (double)first;
            var addition = (double)second + (double)first;
            var subtraction = (double)second - (double)first;


            Console.WriteLine($"The {nameof(division)} of the numbers is: {division:N2}");
            Console.WriteLine($"The {nameof(multiplication)} of the numbers is: {multiplication:N2}");
            Console.WriteLine($"The {nameof(addition)} of the numbers is: {addition:N2}");
            Console.WriteLine($"The {nameof(subtraction)} of the numbers is: {subtraction:N2}");
        }
    }
}
