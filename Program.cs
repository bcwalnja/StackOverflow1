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
            //var c = new Other();
            //c.KendynsChallenge();

            var dateString = "mm/dd/yyyy";
            dateString = "04/21/21";

            Console.WriteLine($"The incoming string from NIST is {dateString}");

            if (DateTime.TryParse(dateString, out DateTime date))
            {
                Console.WriteLine($"The parsed date is {date}");
                Console.WriteLine($"The default DateTime is {default(DateTime)}");
            }

            var index = 0;
            var input = string.Empty;

            while (index < 3 && input != "stop")
            {
                var pickOneOfTheseWords = new string[]
                {
                "The first word (I guess it's not a word)",
                "Second"
                };

                var random = new Random().Next(0, 2);

                Console.WriteLine($"From the choices {pickOneOfTheseWords[0]} and {pickOneOfTheseWords[1]}");
                Console.WriteLine($"I randomly pick {pickOneOfTheseWords[random]}");
                index++;
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }


















        void Something()
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

            var remainder = second % first;

            if (remainder == 0)
            {
                Console.WriteLine("It's an even division! There's no remainder.");
            }
            else
            {
                Console.WriteLine($"There was a remainder left over. {remainder}");
            }

            var division = (double)second / (double)first;
            var multiplication = (double)second * (double)first;
            var addition = (double)second + (double)first;
            var subtraction = (double)second - (double)first;


            Console.WriteLine($"The {nameof(division)} of the numbers is: {division:N}");
            Console.WriteLine($"The {nameof(multiplication)} of the numbers is: {multiplication:N}");
            Console.WriteLine($"The {nameof(addition)} of the numbers is: {addition:N}");
            Console.WriteLine($"The {nameof(subtraction)} of the numbers is: {subtraction:N}");


            Console.WriteLine("Testing int wrapping functionality");

            var start = int.MaxValue - 4;

            for (int i = 0; i < 10; i++)
            {
                //i = 0, 1, 2, 3, 4, 5, 6, 7,8, 9, break
                var output = start + i;
                Console.WriteLine($"Current value: {output}");
                if (i == 7)
                {
                    break;
                }
            }

            var index = 0;
            while (index < 10)
            {
                var output = start + index;
                Console.WriteLine($"Current value: {output}");
                if (index == 7)
                {
                    break;
                }
                index++;
            }

            Console.WriteLine();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorTop = Console.CursorTop - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    Console.CursorTop = Console.CursorTop + 1;
                }
                if (key.Key == ConsoleKey.LeftArrow && Console.CursorLeft > 0)
                {
                    Console.CursorLeft = Console.CursorLeft - 1;
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    Console.CursorLeft = Console.CursorLeft + 1;
                }
            }

        }

    }
}
