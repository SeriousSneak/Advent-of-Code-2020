/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 2,2020
 * 
 * Day 2 Part 1
 * 
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 2\Part 1\input.txt");

            //creating a List with the input
            var linesList = new List<string>(lines);
            int validPasswords = 0;

            for (int loop = 0; loop < linesList.Count; loop++)
            {
                string passwordCheck = linesList[loop];

                //This will split a string based on a single character
                //string[] subStrings = passwordCheck.Split(' ',':');
                
                //This will split a string based on a string
                string[] stringSeparators = new string[] { "-"," ", ": " };
                string[] subStrings = passwordCheck.Split(stringSeparators, StringSplitOptions.None);


                char character = char.Parse(subStrings[2]);
                int firstNumber = Convert.ToInt32(subStrings[0]);
                int secondNumber = Convert.ToInt32(subStrings[1]);
                string password = subStrings[3];

                int freq = password.Count(x => x == character);

                if (freq >= firstNumber && freq <= secondNumber)
                {
                    validPasswords++;
                }
            }

            Console.WriteLine("There are " + validPasswords + " valid passwords.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }
    }
}
