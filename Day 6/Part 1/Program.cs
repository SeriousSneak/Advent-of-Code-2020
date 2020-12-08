/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 7,2020
 * 
 * Day 6 Part 1
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //read the number of lines in the file
            int numberOfLines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 6\Part 1\input.txt").Count();

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 6\Part 1\input.txt");


            string groupAnswers = "";
            int totalUnique = 0;

            int counter = 1;

            foreach(var line in lines)
            {
                if (line != "")
                {
                    groupAnswers += line;
                }

                //this allows us to process the last entry which does not have a blank line after it
                if (line == "" || counter == numberOfLines)
                {
                    totalUnique += groupAnswers.Distinct().Count();
                    groupAnswers = "";
                }
                counter++;
            }

            Console.WriteLine("The answer is " + totalUnique + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
