/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Date: December 14,2020
 * 
 * Day 7 Part 2
 *
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Channels;

namespace Part_2
{
    class Program
    {

        struct bagDataStruct
        {
            public string colour;
            public int count;
        }

        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 7\Part 2\input.txt");

            bagDataStruct bagData = new bagDataStruct();

            string[] stringSeparators = new string[] { "contain", " ", "bags", "bag", ".", ",", "" };
            Dictionary<string, List<bagDataStruct>> myDic = new Dictionary<string, List<bagDataStruct>>();

            foreach (var line in lines)
            {
                string outsideBag = "";
                List<bagDataStruct> insideBagsList = new List<bagDataStruct>();

                //set the key for the dictionary to be the first colour on the line
                string[] currentLine = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (int x = 3; x < currentLine.Count(); x += 3)
                {
                    if (currentLine[x] != "" && currentLine[x] != "other")
                    {
                        bagData.colour = currentLine[x] + " " + currentLine[x + 1];
                        bagData.count = Int32.Parse(currentLine[x - 1]);

                        insideBagsList.Add(bagData);
                    }
                    else
                    {
                        break;
                    }
                }

                outsideBag = currentLine[0] + " " + currentLine[1];

                myDic.Add(outsideBag, insideBagsList);


            }

            int bagCounter = 0;


            bagCounter = countBagsInside("shiny gold", myDic);

            Console.WriteLine("There are " + bagCounter + " bags inside of a shiny gold bags.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }


        static int countBagsInside(string bag, Dictionary<string, List<bagDataStruct>> myDic)
        {
            List<bagDataStruct> subBags = new List<bagDataStruct>();
            int count = 0; 

            subBags = myDic[bag];


            foreach (bagDataStruct subBag in subBags)
            {
                count += subBag.count; //add amount of current bag
                count += subBag.count * countBagsInside(subBag.colour, myDic); //Add amount of current bag (the coefficient) * the amount of bags inside the bag to the count
            }

            return count; //return a count of all the bags inside the current bag


            /* the following from https://www.reddit.com/r/adventofcode/comments/k8xatx/2020_day_7_part_2_help_with_python3_recursive/gf11o1d/?utm_source=share&utm_medium=web2x&context=3
             * helped me immensely. Also https://www.reddit.com/r/adventofcode/comments/kaf8v6/2020_day_7_part_2_something_missing/
             * 
             * 
             *    def count_bags_inside(string):
                  bags = rules_dict[string] #Dict of all bags in current bag
                  count = 0 #init count
                  if bags == {}: #If empty, return 0 because no bags are in it
                      print(f"{string} empty, returning 0")
                      return 0
                  print(f"bags = {bags}")
                  for bag in bags: #For each bag
                    print(f"adding {rules_dict[string][bag]}")
                    count += bags[bag] #Add amount of current bag
                    print(f"going into {bag}")
                    count += bags[bag] * count_bags_inside(bag) #Add amount of current bag (the coefficient) * the amount of bags inside the bag to the count
                  return count #return a count of all the bags inside the current bag
             * 
             * 
             */


        }
    }
}
