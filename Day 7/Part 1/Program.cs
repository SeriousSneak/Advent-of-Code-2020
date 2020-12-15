/* Advent of Code 2020
 * 
 * Programmer: Andrew Stobart
 * Started December 8,2020
 * Solved December 11, 2020
 * 
 * Day 7 Part 1
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

    //this really helped me out https://www.reddit.com/r/adventofcode/comments/k8iun0/what_is_the_cleanestcanonical_day_7_part_1/
    
    class Program
    {

        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2020\Day 7\Part 1\input.txt");

                        
            string[] stringSeparators = new string[] { "contain" , " " , "bags" , "bag" , "." , "," , ""};
            Dictionary<string, List<string>> myDic = new Dictionary<string, List<string>>();

            foreach (var line in lines)
            {
                string outsideBag = "";
                List<string> insideBagsList = new List<string>();

                //set the key for the dictionary to be the first colour on the line
                string[] currentLine = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);

                for (int x = 3; x < currentLine.Count(); x+=3)
                {
                    if (currentLine[x] != "" && currentLine[x] != "other")
                    {
                        insideBagsList.Add(currentLine[x] + " " + currentLine[x + 1]);
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
            foreach(string item in myDic.Keys)
            {
                if (item != "shiny gold")    //prevents us from couting if the outside bag is Shiny gold. We don't want Shiny gold to be the outside bag
                {
                    if (containsShiny(item, myDic) == true)
                    {
                        bagCounter++;
                    }
                }
            }

            Console.WriteLine("There are " + bagCounter + " bags that can contain shiny gold bags."); 

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }


        static bool containsShiny(string bag, Dictionary<string, List<string>> myDic)
        {
            if (bag == "shiny gold")
            {
                return true;
            }
            else
            {
                List<string> subBags = new List<string>();

                subBags = myDic[bag];

                foreach (string subBag in subBags)
                {
                    if (containsShiny(subBag, myDic) == true)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        
    }
}
