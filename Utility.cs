using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackOverflow1
{
    public static class Utility
    {
        public static bool VerifyGuest(DateTime birthDate, int heightCm)
        {
            return false;
        }

        public static string GetDay(int daynum)
        {
            string dayname;
            switch (daynum)
            {
                case 0:
                    dayname = "Sunday";
                    break;
                case 1:
                    dayname = "Monday";
                    break;
                case 2:
                    dayname = "Tuesday";
                    break;
                case 3:
                    dayname = "Wendsday";
                    break;
                case 4:
                    dayname = "Thursday";
                    break;
                case 5:
                    dayname = "Friday";
                    break;
                case 6:
                    dayname = "Saturday";
                    break;
                default:
                    dayname = "Invalid input";
                    break;

            }
            return dayname;
        }

        public static void Shuffle(ref int[] array)
        {
            if (array == null || array.Length == 0)
            {
                return;
            }

            var last = array.Last();

            for (int i = 1; i < array.Length; i++)
            {
                array[i] = array[i - 1];
            }

            array[0] = last;
        }

    }

}
