/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 7,2020
 * 
 * Day 6 Part 2
 *
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //read the number of lines in the file
            int numberOfLines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 6\Part 1\input.txt").Count();

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 6\Part 1\input.txt");


            string firstPerson = "";
            int counter = 1;
            int answer = 0;
            bool goToNextGroup = false;

            foreach (var line in lines)
            {
                if (line != "")
                {
                    if (firstPerson == "" && goToNextGroup == false)
                    {
                        firstPerson = line;
                    }
                    else
                    {
                        //loop through all the letters in FirstPerson to see if they exist in line. If so, move on, if not, remove the letter from FirstPerson
                        int letterCounter = 0;

                        //I'm using the first entry in a group as an anchor. I'm then looping through each letter and looking to see if it's in the selections of the next user
                        //If they are not, that letter is removed from the first person. This loops through subsequent people in the group, where I remove letters from the first user
                        //if they are not prsent in the next user. firstPerson will then be left with only the letters that are common in each of the strings in a group
                        foreach (char c in firstPerson)
                        {
                            if (!line.Contains(c))
                            {
                                firstPerson = firstPerson.Remove(letterCounter, 1);
                                letterCounter--; //I need to step the counter back because I removed a letter

                                if (firstPerson == "") //we don't need to evaluate the rest of the group if all the letters are removed from the first line
                                {
                                    goToNextGroup = true;
                                }
                            }
                            letterCounter++;
                        }

                    }
                }

                //this allows us to process the last entry which does not have a blank line after it
                if (line == "" || counter == numberOfLines)
                {
                    answer += firstPerson.Count();
                    firstPerson = "";
                    goToNextGroup = false;
                }
                counter++;
            }

            Console.WriteLine("The answer is " + answer + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
