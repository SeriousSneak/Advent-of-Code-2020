/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 5,2020
 * 
 * Day 5 Part 1
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
            //read the number of lines in the file
            int numberOfLines = File.ReadLines(@"D:\Advent of Code 2020\Advent-of-Code-2020\Day 5\Part 1\input.txt").Count();

            //read the number of characters in the first line
            string firstLine = File.ReadLines(@"D:\Advent of Code 2020\Advent-of-Code-2020\Day 5\Part 1\input.txt").First();
            int lineLength = firstLine.Count();

            char[,] fileArray = new char[numberOfLines, lineLength];

            var input = File.ReadLines(@"D:\Advent of Code 2020\Advent-of-Code-2020\Day 5\Part 1\input.txt");
            int rowCount = 0, colCount = 0;

            //fill up my array so that each cell has a single character
            foreach (var line in input)
            {
                string currentLine = line;
                colCount = 0;
                foreach (char c in currentLine)
                {
                    fileArray[rowCount, colCount] = c;
                    colCount++;
                }
                rowCount++;
            }

            int seatID = 0;
            

            for (int lineNumber = 0; lineNumber < numberOfLines; lineNumber++)
            {
                int rowUpper = 127;
                int rowLower = 0;
                int colUpper = 7;
                int colLower = 0;
                int currentSeatID = 0;

                for (int letterNumber = 0; letterNumber < lineLength; letterNumber++)
                {
                    if (fileArray[lineNumber, letterNumber] == 'F')
                    {
                        rowUpper = takeLower(rowUpper, rowLower);
                    }
                    if (fileArray[lineNumber, letterNumber] == 'B')
                    {
                        rowLower = takeUpper(rowUpper, rowLower);
                    }
                    if (fileArray[lineNumber, letterNumber] == 'L')
                    {
                        colUpper = takeLower(colUpper, colLower);
                    }
                    if (fileArray[lineNumber, letterNumber] == 'R')
                    {
                        colLower = takeUpper(colUpper, colLower);
                    }
                }

                currentSeatID = (rowUpper * 8) + colUpper; 
                if(currentSeatID > seatID)
                {
                    seatID = currentSeatID;
                }

                
            }


            Console.WriteLine("The highest seat ID is " + seatID + ".");


            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static int takeUpper(int upper, int lower)
        {
            return (lower + ((upper - lower) / 2) + 1);
        }

        public static int takeLower(int upper, int lower)
        {
                return (upper - ((upper - lower) / 2) - 1);
        }
    }
}
