/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 1,2020
 * 
 * Day 1 Part 1
 * 
 */


using System;
using System.Collections.Generic;
using System.IO;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 1\Part 1\input.txt");
            
            //creating a List with the input
            var linesList = new List<string>(lines);

            int theOutsideCount = 0;
            int theInsideCount = 0;

            int number1 = 0;
            int number2 = 0;

            for (theOutsideCount = 0; theOutsideCount < linesList.Count; theOutsideCount++)
            {
                number1 = Convert.ToInt32(linesList[theOutsideCount]);

                for (theInsideCount = 0; theInsideCount < linesList.Count; theInsideCount++)
                {
                    number2 = Convert.ToInt32(linesList[theInsideCount]);

                    if (number1 + number2 == 2020)
                    {
                        Console.WriteLine("An answer has been found. The numbers are " + number1 + " and " + number2 + ".");
                        theOutsideCount = int.MaxValue - 1; //break the outside loop
                        break; //break the current loop
                    }
                }
            }

            Console.WriteLine("Multipying these two numbers gives us an answer of " + number1 * number2 + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
