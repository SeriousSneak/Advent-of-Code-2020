﻿/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 4,2020
 * 
 * Day 4 Part 1
 * 
 * This code could be made much more efficient.... but it got me the write answer and I'm leaving it like this.
 */


using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 4\Part 1\input.txt");

            string passport = "";

            string[,] passportValidation = new string[2,8];

            passportValidation[0, 0] = "byr";
            passportValidation[0, 1] = "iyr";
            passportValidation[0, 2] = "eyr";
            passportValidation[0, 3] = "hgt";
            passportValidation[0, 4] = "hcl";
            passportValidation[0, 5] = "ecl";
            passportValidation[0, 6] = "pid";
            passportValidation[0, 7] = "cid";

            for (int sirCount = 0; sirCount < 8; sirCount++)
            {
                passportValidation[1, sirCount] = "";
            }


            int numberOfValidPassports = 0;
            int numberOfInvalidPassports = 0;
            int totalNumberOfPassports = 0;

            foreach (var line in lines)
            {
                if (line != "")
                {
                    if (passport != "")
                    {
                        passport = passport + " ";
                        passport += line;
                    }
                    else
                    {
                        passport = line;
                    }
                }
                else
                {
                    //we now have a single passport contained in the passport string. We need to split it up and place the values in the PassportVlidation array
                    totalNumberOfPassports++;

                    string[] subStrings = passport.Split(':', ' ');
                    for (int theLoop = 0; theLoop < subStrings.Count(); theLoop += 2)
                    {
                        if (subStrings[theLoop] == "byr")
                        {
                            passportValidation[1,0] = subStrings[theLoop + 1];
                        }
                        else if (subStrings[theLoop] == "iyr")
                        {
                            passportValidation[1,1] = subStrings[theLoop + 1];
                        }
                        else if (subStrings[theLoop] == "eyr")
                        {
                            passportValidation[1,2] = subStrings[theLoop + 1];
                        }
                        else if (subStrings[theLoop] == "hgt")
                        {
                            passportValidation[1,3] = subStrings[theLoop + 1];
                        }
                        else if (subStrings[theLoop] == "hcl")
                        {
                            passportValidation[1,4] = subStrings[theLoop + 1];
                        }
                        else if (subStrings[theLoop] == "ecl")
                        {
                            passportValidation[1,5] = subStrings[theLoop + 1];
                        }
                        else if (subStrings[theLoop] == "pid")
                        {
                            passportValidation[1,6] = subStrings[theLoop + 1];
                        }
                        else if (subStrings[theLoop] == "cid")
                        {
                            passportValidation[1,7] = subStrings[theLoop + 1];
                        }
                    }


                    //check password validity here by passing the passportValidation arry


                    if (CheckValidity(passportValidation) == true)
                    {
                        numberOfValidPassports++;
                        Console.WriteLine("Passport number " + totalNumberOfPassports + " is valid. Passport = " + passport + ". Total valid = " +numberOfValidPassports);
                    }
                    else
                    {
                        numberOfInvalidPassports++;
                        Console.WriteLine("Passport number " + totalNumberOfPassports + " is not valid. Passport = " + passport);
                    }

                    //clear passport string and passportValidation array
                    passport = "";
                    for (int x = 0; x < 8; x++)
                    {
                        passportValidation[1, x] = "";
                    }
                }

            }

            totalNumberOfPassports++;

            //to check the very last passport on the list. This is needed as there is no blank line after the last entry

            string[] subStrings2 = passport.Split(':', ' ');
            for (int theLoop = 0; theLoop < subStrings2.Count(); theLoop += 2)
            {
                if (subStrings2[theLoop] == "byr")
                {
                    passportValidation[1, 0] = subStrings2[theLoop + 1];
                }
                else if (subStrings2[theLoop] == "iyr")
                {
                    passportValidation[1, 1] = subStrings2[theLoop + 1];
                }
                else if (subStrings2[theLoop] == "eyr")
                {
                    passportValidation[1, 2] = subStrings2[theLoop + 1];
                }
                else if (subStrings2[theLoop] == "hgt")
                {
                    passportValidation[1, 3] = subStrings2[theLoop + 1];
                }
                else if (subStrings2[theLoop] == "hcl")
                {
                    passportValidation[1, 4] = subStrings2[theLoop + 1];
                }
                else if (subStrings2[theLoop] == "ecl")
                {
                    passportValidation[1, 5] = subStrings2[theLoop + 1];
                }
                else if (subStrings2[theLoop] == "pid")
                {
                    passportValidation[1, 6] = subStrings2[theLoop + 1];
                }
                else if (subStrings2[theLoop] == "cid")
                {
                    passportValidation[1, 7] = subStrings2[theLoop + 1];
                }
            }


            if (CheckValidity(passportValidation) == true)
            {
                numberOfValidPassports++;
                Console.WriteLine("Passport number " + totalNumberOfPassports + " is valid. Passport = " + passport + ". Total valid = " + numberOfValidPassports);
            }
            else
            {
                numberOfInvalidPassports++;
                Console.WriteLine("Passport number " + totalNumberOfPassports + " is not valid. Passport = " + passport);
            }

            Console.WriteLine("");
            Console.WriteLine("There are " + numberOfValidPassports + " valid passports and " + numberOfInvalidPassports + " invalid passports.");
            Console.WriteLine("There are " + totalNumberOfPassports + " total passports.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            /*
            That's not the right answer; your answer is too low. If you're stuck, make sure you're using the full input data; there are also some general tips on the about page, 
            or you can ask for hints on the subreddit. Please wait one minute before trying again. (You guessed 181.) [Return to Day 4]
            */
        }

        public static bool CheckValidity(string[,] pv)
        {
            if (pv [1,0] == "" || pv[1,1] == "" || pv[1,2] == "" || pv[1,3] == "" || pv[1,4] == "" || pv[1,5] == "" || pv[1,6] == "")
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }


    }
}

