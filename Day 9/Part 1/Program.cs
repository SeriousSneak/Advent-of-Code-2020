/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 16,2020 
 * 
 * Day 9 Part 1
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 9\Part 1\input.txt");

            //create a list to hold the input. We need a Long type as the largest number in the list is 10 digit, and 
            //an int can only contain numbers ranging from -2147483648 to 2147483648. Long is the same as Int64. Int is 
            //the same as Int32.

            List <long> input = new List<long>();

            foreach (var line in lines)
            {
                input.Add(Int64.Parse(line));
            }

            long target = 0;
            for (int x=0; x<(input.Count - 25); x++)
            {
                target = input[x + 25];

                for (int firstNumber=x; firstNumber<(x+25); firstNumber++)
                {
                    for (int secondNumber=x; secondNumber<(x+25);secondNumber++)
                    {
                        if (firstNumber != secondNumber)
                        {
                            if (target == input[firstNumber] + input[secondNumber])
                            {
                                //find the next target
                                secondNumber = (int.MaxValue - 1);
                                firstNumber = (int.MaxValue - 1);
                            }
                            else if (secondNumber == (x + 23) && firstNumber == (x + 24))
                            {
                                //no number in the previous 25 numbers add up to this number

                                //break out of all the loops
                                x = input.Count;
                                secondNumber = (int.MaxValue - 1);
                                firstNumber = (int.MaxValue - 1);
                            }
                        }
                    }

                }
            }

            Console.WriteLine("The invalid number is " + target + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
