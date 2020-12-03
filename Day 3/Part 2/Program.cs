/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 4,2020
 * 
 * Day 3 Part 2
 * 
 */

using System;
using System.IO;
using System.Linq;

namespace Part_2
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

            char[,] fileArray = new char[numberOfLines, lineLength];

            var input = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 3\Part 1\input.txt");
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

            

            int patternRight = 0;
            int patternDown = 0;
            int treeCount = 0;
            int[] treeEncounterAnswers = new int[5];

            for (int routeCount = 1; routeCount <= 5; routeCount++)
            {
                int shouldLoop = 1;
                rowCount = 0;
                colCount = 0;
                treeCount = 0;
                

                if (routeCount == 1)
                {
                    patternRight = 1;
                    patternDown = 1;
                }
                else if (routeCount == 2)
                {
                    patternRight = 3;
                    patternDown = 1;
                }
                else if (routeCount == 3)
                {
                    patternRight = 5;
                    patternDown = 1;
                }
                else if (routeCount == 4)
                {
                    patternRight = 7;
                    patternDown = 1;
                }
                else if (routeCount == 5)
                {
                    patternRight = 1;
                    patternDown = 2;
                }

                while (shouldLoop == 1)
                {
                    colCount = colCount + patternRight;
                    if (colCount > (lineLength - 1))
                    {
                        //roll over to the start of the row if we go past the end of it
                        colCount = colCount - lineLength;
                    }
                    rowCount += patternDown;
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
                treeEncounterAnswers[routeCount -1] = treeCount;
                Console.WriteLine("Route " + rowCount + " will encounter " + treeCount + " trees.");
            }

            int answer = treeEncounterAnswers[0] * treeEncounterAnswers[1] * treeEncounterAnswers[2] * treeEncounterAnswers[3] * treeEncounterAnswers[4];

            Console.WriteLine("The number of trees on each route multipled together is " + answer + " trees.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
