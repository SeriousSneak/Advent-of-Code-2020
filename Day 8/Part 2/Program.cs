/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 15,2020 
 * 
 * Day 8 Part 2
 *
 */


using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_2
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
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 8\Part 2\input.txt");

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


            int accCounter = 0;
            for (int x = 0; x < instructionSet.Count; x++)
            {
                //List<codeStruct> modifiedInstructionSet = instructionSet; //this does not work as both lists contain pointers to the same set of data, 
                                                                            //so modifying one modifies the other. Instead of this, I have to clone the list
                                                                            //so that both lists are independant from each other. The following line
                                                                            //accomplishes this.
                                                        
                List<codeStruct> modifiedInstructionSet = instructionSet.ToList();

                codeStruct CSObj = new codeStruct();

                if (modifiedInstructionSet[x].instruction == "nop" || modifiedInstructionSet[x].instruction == "jmp")
                {
                    CSObj = modifiedInstructionSet[x];
                    if (modifiedInstructionSet[x].instruction == "nop")
                    {
                        CSObj.instruction = "jmp";
                    }
                    else //then it must be jmp
                    {
                        CSObj.instruction = "nop";
                    }
                    modifiedInstructionSet[x] = CSObj;
                    accCounter = 0;
                    
                    int pointer = 0;
                    bool breakWhileLoop = false;
                    bool lastline = false;

                    while (modifiedInstructionSet[pointer].hasBeenExecuted == false && breakWhileLoop == false)
                    {
                        codeStruct currentInstruction = new codeStruct();
                        currentInstruction = modifiedInstructionSet[pointer];
                        

                        //mark the current instruction has having been executed
                        currentInstruction.hasBeenExecuted = true;
                        modifiedInstructionSet[pointer] = currentInstruction;

                        if (pointer == (modifiedInstructionSet.Count - 1))
                        {
                            //we are at the last line of the application
                            lastline = true;
                        }

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

                        if (lastline == true)
                        {
                            //we just executed the last line of the application. We need to break out of the loop and report accCounter
                            breakWhileLoop = true;
                            Console.WriteLine("We terminated succesfully. Line " + (x + 1) + " was changed.");
                            x = Int32.MaxValue - 1; //break out of For loop. -1 because when the for loop increments x, this will loop to a negative if we don't take 1 away now.
                            pointer = (modifiedInstructionSet.Count - 1);
                        }

                    }
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
