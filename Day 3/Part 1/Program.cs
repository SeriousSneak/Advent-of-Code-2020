/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 3,2020
 * 
 * Day 3 Part 1
 * 
 */

using System;
using System.IO;
using System.Linq;


namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //read the number of lines in the file
            int numberOfLines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 3\Part 1\input.txt").Count();

            //read the number of characters in the first line
            string firstLine = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 3\Part 1\input.txt").First();
            int lineLength = firstLine.Count();

            char[,] fileArray = new char[numberOfLines,lineLength];

            var input = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 3\Part 1\input.txt");
            int rowCount = 0,  colCount = 0;

            //fill up my array so that each cell has a single character
            foreach (var line in input)
            {
                string currentLine = line;
                colCount = 0;
                foreach (char c in currentLine)
                {
                    fileArray[rowCount,colCount] = c;
                    colCount++;
                }
                rowCount++;
            }

            rowCount = 0;
            colCount = 0;
            int treeCount = 0;
            int shouldLoop = 1;

            while (shouldLoop == 1)
            {
                colCount = colCount + 3;
                if (colCount > (lineLength - 1))
                {
                    //roll over to the start of the row if we go past the end of it
                    colCount = colCount - lineLength;
                }
                rowCount++;
                if (fileArray[rowCount, colCount] == '#')
                {
                    treeCount++;
                }
                
                //I used the following to verify that the proper indexes were being checked
                //Console.WriteLine("Checked index [" + rowCount + ", " + colCount + "]");

                if (rowCount == (numberOfLines - 1))
                {
                    shouldLoop = 0;
                }                
            }

            Console.WriteLine("Santa will encounter " + treeCount + " trees.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
