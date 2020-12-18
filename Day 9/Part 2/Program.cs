/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date started: December 17,2020 
 * Date finished: December 18, 2020
 * 
 * Day 9 Part 2
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 9\Part 2\input.txt");

            //create a list to hold the input. We need a Long type as the largest number in the list is 10 digit, and 
            //an int can only contain numbers ranging from -2147483648 to 2147483648. Long is the same as Int64. Int is 
            //the same as Int32.

            List<long> input = new List<long>();

            foreach (var line in lines)
            {
                input.Add(Int64.Parse(line));
            }

            long target = 0;
            for (int x = 0; x < (input.Count - 25); x++)
            {
                target = input[x + 25];

                for (int firstNumber = x; firstNumber < (x + 25); firstNumber++)
                {
                    for (int secondNumber = x; secondNumber < (x + 25); secondNumber++)
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


            //We now have found the invalid number. We now need to find the contiguous set of numbers that add up to be this number

            bool loopTime;
            long part2Answer = 0;

            for (int startingIndex = 0; startingIndex < (input.Count - 1); startingIndex++)
            {
                long count = 0;
                int currentIndex = startingIndex + 1;
                loopTime = true;
                long smallest = 0;
                long biggest = 0; 

                while (loopTime == true)
                {
                    
                    if (count == 0)
                    {
                        count = input[startingIndex] + input[currentIndex];
                        if (input[startingIndex] < input[currentIndex])
                        {
                            smallest = input[startingIndex];
                            biggest = input[currentIndex];
                        }
                        else
                        {
                            smallest = input[currentIndex];
                            biggest = input[startingIndex];
                        }
                    }
                    else
                    {
                        count += input[currentIndex];
                    }

                    if (smallest > input[currentIndex])
                    {
                        smallest = input[currentIndex];
                    }
                    if (biggest < input[currentIndex])
                    {
                        biggest = input[currentIndex];
                    }

                    if (target == count) //check to see if the count equals the bad number
                    {
                        //we have found the contiguous numbers. Adding the smallest number to the biggest number in the list will give us the answer for this puzzle.
                        part2Answer = biggest + smallest;
                        loopTime = false; //break out of the while loop
                        startingIndex = input.Count;  //break out of the for loop
                    }
                    else if (count > target)
                    {
                        //the current contiguous list doesn't add up to the target. Proceed to next contiguous set
                        loopTime = false; //break out of the while loop
                    }
                    else
                    {
                        currentIndex++;
                    }
                }
            }

            Console.WriteLine("The invalid number is " + target + ".");
            Console.WriteLine("The answer to part two is " + part2Answer);

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
