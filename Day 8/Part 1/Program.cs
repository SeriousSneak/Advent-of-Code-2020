/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 15,2020 
 * 
 * Day 8 Part 1
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

        struct codeStruct
        {
            public string instruction;
            public int value;
            public bool hasBeenExecuted;
        }


        static void Main(string[] args)
        {

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 8\Part 1\input.txt");

            List<codeStruct> instructionSet = new List<codeStruct>();

            string[] stringSeparators = new string[] { " ", "+" };


            foreach (var line in lines)
            {
                string[] subStrings = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                codeStruct currentLine = new codeStruct();

                currentLine.instruction = subStrings[0];
                currentLine.value = Int32.Parse(subStrings[1]);
                currentLine.hasBeenExecuted = false;

                instructionSet.Add(currentLine);
            }

            int pointer = 0;
            int accCounter = 0;

            while(instructionSet[pointer].hasBeenExecuted == false)
            {
                codeStruct currentInstruction = new codeStruct();
                currentInstruction = instructionSet[pointer];

                //mark the current instruction has having been executed
                currentInstruction.hasBeenExecuted = true;
                instructionSet[pointer] = currentInstruction;

                switch (currentInstruction.instruction)
                {
                    case "acc":
                        accCounter += currentInstruction.value;
                        pointer++;
                        break;

                    case "jmp":
                        pointer += currentInstruction.value;
                        break;

                    case "nop":
                        pointer++;
                        break;

                    default:
                        break;
                }

            }

            Console.Write("The global Global Accumulator is at " + accCounter + ".");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }
    }
}

