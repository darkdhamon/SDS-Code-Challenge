using System;
using System.Linq;

namespace DeveloperSample.Algorithms
{
    public static class Algorithms
    {
        /// <summary>
        /// Used https://byjus.com/maths/factorial/ as a reference for what a factorial is.
        /// </summary>
        /// <param name="n"></param>
        /// <exception cref="ArgumentOutOfRangeException">"Positive int required for Factorials"</exception>
        /// <returns></returns>
        public static int GetFactorial(int n)
        {
            switch (n)
            {
                case < 0:
                    throw new ArgumentOutOfRangeException(nameof(n),"Positive int required for Factorials");
                case 0 or 1:
                    // According to the referenced link above 0! is 1, which my previous logic did not account for.
                    // and 1 is the same as 0 so might as well skip the logical and mathematical calculations and return
                    return 1; 
            }

            var result = 0;
            while (n > 0)
            {
                if (result==0) result = n;
                else
                {
                    result *= n;
                }
                n--;
            }
            return result; 
        }
        /// <summary>
        /// I came up with 3 different ways to complete this task.
        /// Option 1 passed the provided unit test but not the addition testing that I built
        /// Option 2 and 3 pass all unit tests however option 2 uses less code and is more readable.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public static string FormatSeparators(params string[] items)
        {
            //Idea 1) not very efficient and what if multiple items are the same?
            //var result = string.Join(", ", items);
            //result = result.Replace($", {items.Last()}", $" and {items.Last()}");

            //Idea 2)
            var last = items.Last(); // Get the last item.
            var sublist = items.Take(items.Length - 1); // Take all but the last item.
            var result = $"{string.Join(", ", sublist)} and {last}";

            //Idea 3) Simple loop but requires more code.
            //var count = items.Length;
            //var result = string.Empty;
            //for (var i = 0; i < count; i++)
            //{
            //    var separator = ", ";
            //    if (i == count - 1) separator = string.Empty;
            //    else if (i == count - 2) separator = " and ";
            //    result += $"{items[i]}{separator}";
            //}

            return result;
        }
    }
}