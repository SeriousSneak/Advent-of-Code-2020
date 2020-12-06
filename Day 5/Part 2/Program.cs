/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 6,2020
 * 
 * Day 5 Part 2
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
            //read the number of lines in the file
            int numberOfLines = File.ReadLines(@"D:\Advent of Code 2020\Advent-of-Code-2020\Day 5\Part 2\input.txt").Count();

            //read the number of characters in the first line
            string firstLine = File.ReadLines(@"D:\Advent of Code 2020\Advent-of-Code-2020\Day 5\Part 2\input.txt").First();
            int lineLength = firstLine.Count();

            char[,] fileArray = new char[numberOfLines, lineLength];

            var input = File.ReadLines(@"D:\Advent of Code 2020\Advent-of-Code-2020\Day 5\Part 2\input.txt");
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

            //create 2D array which will act as my seating map for the plane

            char[,] seatingMap = new char[128,8];

            for (int x = 0; x < 128; x++)
            {
                for (int y=0; y < 8; y++)
                {
                    seatingMap[x, y] = 'O';
                }
            }

            int seatID = 0;

            for (int lineNumber = 0; lineNumber < numberOfLines; lineNumber++)
            {
                int rowUpper = 127;
                int rowLower = 0;
                int colUpper = 7;
                int colLower = 0;

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

                //mark a seat as occupied
                seatingMap[rowUpper, colUpper] = 'X';
            }

            //search for Santa's seat

            //search column 0
            //we know that Santa has a passenger on each side of him, so he can't have a window seat

            for (int colCounter = 0; colCounter < 8; colCounter++)
            {
                for (int rowCounter = 0; rowCounter < 128; rowCounter++)
                {
                    //empty seat found. Next I check if we are in the very last row or very first row. If so,
                    //we don't check if Santa's seat if found becaues at least the back row and front row are empty
                    if (seatingMap[rowCounter,colCounter] == 'O' && rowCounter != 0 && rowCounter !=127)
                    {
                        //empty seat has been found. Now we need to see if the seat on either side is occupied
                        if (colCounter == 0) //special case where we need to check the previous row
                        {
                            if (seatingMap[(rowCounter + 1), 7] == 'X' && seatingMap[rowCounter, (colCounter + 1)] == 'X')
                            {
                                //Santa's seat found
                                seatID = (rowCounter * 8) + colCounter;
                                Console.WriteLine("Santa is sitting at row " + rowCounter + " column " + colCounter + ".");
                                Console.WriteLine("Santa's seat ID is " + seatID + ".");

                                rowCounter = 128;
                                colCounter = 8;
                            }
                        }
                        else if (colCounter == 7) //special case where we need to check the next row
                        {
                            if (seatingMap[rowCounter, (colCounter -1)] == 'X' && seatingMap[(rowCounter - 1), 0] == 'X')
                            {
                                //Santa's seat found
                                seatID = (rowCounter * 8) + colCounter;
                                Console.WriteLine("Santa is sitting at row " + rowCounter + " column " + colCounter + ".");
                                Console.WriteLine("Santa's seat ID is " + seatID + ".");

                                rowCounter = 128;
                                colCounter = 8;
                            }
                        }
                        else if (seatingMap[rowCounter,(colCounter - 1)] == 'X' && seatingMap[rowCounter,(colCounter + 1)] == 'X')
                        {
                            //Santa's seat found
                            seatID = (rowCounter * 8) + colCounter;
                            Console.WriteLine("Santa is sitting at row " + rowCounter +" column " + colCounter +".");
                            Console.WriteLine("Santa's seat ID is " + seatID + ".");

                            rowCounter = 128;
                            colCounter = 8;
                        }
                    }
                }
            }

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
