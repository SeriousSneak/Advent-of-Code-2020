/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 1,2020
 * 
 * Day 1 Part 2
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;

namespace Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 1\Part 2\input.txt");
            
            //creating a List with the input
            var linesList = new List<string>(lines);

            int loop1 = 0;
            int loop2 = 0;
            int loop3 = 0;

            int number1 = 0;
            int number2 = 0;
            int number3 = 0;

            for (loop1 = 0; loop1 < linesList.Count; loop1++)
            {
                number1 = Convert.ToInt32(linesList[loop1]);

                for (loop2 = 0; loop2 < linesList.Count; loop2++)
                {
                    number2 = Convert.ToInt32(linesList[loop2]);

                    for (loop3 = 0; loop3 < linesList.Count; loop3++)
                    {
                        number3 = Convert.ToInt32(linesList[loop3++]);

                        if (number1 + number2 + number3 == 2020)
                        {
                            Console.WriteLine("An answer has been found. The numbers are " + number1 + ", " + number2 + ", and " + number3 + ".");
                            loop1 = int.MaxValue - 1; //break loop 1
                            loop2 = int.MaxValue - 1; //break loop 2
                            break; //break the current loop
                        }
                    }
                }
            }

            Console.WriteLine("Multipying these two numbers gives us an answer of " + number1 * number2 * number3 + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
