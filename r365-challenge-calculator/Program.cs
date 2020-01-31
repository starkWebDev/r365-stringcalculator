using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace r365challengecalculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // this function is used to check each of the given values to make sure they are valid
            int CheckForValid(string input)
            {
                if (Int32.TryParse(input, out _))
                {
                    int outNum = Int32.Parse(input);
                    if ( outNum > 1000)
                    {
                        return 0;
                    }
                    else
                    {
                        return outNum;
                    }
                    
                }
                return 0;
            }

            // this is the main calculation function
            string Calculate(string _nums){
                // initializing variable
                string testingNums = _nums;
                List<string> inputNums = new List<string>();
                List<string> lstDelims = new List<string>('\n');
                int cutLoc;
                // use regex to try to see if its giving multiple delimiters
                Match regMatch = Regex.Match(testingNums, @"\[([^]]*)\]");

                //check if the regex match worked
                if (regMatch.Success)
                {
                    // loop until all delimiters found
                    while (regMatch.Success)
                    {
                        string val = regMatch.Groups[1].Value;
                        cutLoc = testingNums.IndexOf(val) + val.Length + 1;
                        testingNums = testingNums.Substring(cutLoc);
                        lstDelims.Add(val);
                        regMatch = Regex.Match(testingNums, @"\[([^]]*)\]");
                        inputNums = new List<string>(testingNums.Split(lstDelims.ToArray(), StringSplitOptions.None)) ;
                    }
                }
                else
                {
                    // run normal condition, given a single delimiter
                    int loc = _nums.IndexOf('\n');
                    string delimStr = _nums.Substring(0, loc);
                    testingNums = testingNums.Substring(loc);
                    inputNums = new List<string>(testingNums.Split(new string[] { delimStr, "\n" }, StringSplitOptions.None)) ;

                }

                int total;

                // safety check to cut out immediately if there are no inputs
                if (inputNums.Count == 0)
                {
                    total = 0;
                    return (total.ToString());
                }

                // initialized lists
                List<int> negNums = new List<int>();
                List<int> convertedNums = new List<int>();

                // go through each given value, check for validity
                foreach(var num in inputNums)
                {
                    int _num = CheckForValid(num);
                    if (_num < 0)
                    {
                        negNums.Add(_num);
                    }
                    convertedNums.Add(_num);
                }

                //deal with any negative numbers found
                if (negNums.Count != 0)
                {
                    string msg = "Error. Inputs cannot be negative. you input: ";
                    foreach(var num in negNums)
                    {
                        msg += $" {num},";
                    }
                    return (msg);

                }

                // calculate and return total
                total = convertedNums.Sum();
                return(total.ToString());
            }

            // this is a testing function that outputs what we expect and what we actually got
            void Testing(string input, string expected)
            {
                Console.WriteLine($"Input: {input.Replace("\n", "\\n")}\nExpected output: {expected}");
                string answer = Calculate(input);
                Console.WriteLine($"Output: {answer}\n");
            }

            // these are the various tests
            Testing(",\n1,1", "2");
            Testing(",\n", "0");
            Testing(",\n1,hi", "1");
            Testing(",\nhi,1", "1");
            Testing(",\nhi", "0");
            Testing(",\nhi,hi", "0");
            Testing(",\n2,2", "4");
            Testing(",\n,", "0");
            Testing(",\n-1,5", "Error");
            Testing(",\n1,2,3", "6");
            Testing(",\n1,2,3,4", "10");
            Testing(",\nhi,hi,hi", "0");
            Testing(",\nhi,1,hi", "1");
            Testing(",\n1,1,hi", "2");
            Testing(",\nhi,1,1", "2");
            Testing(",\n,1,1", "2");
            Testing(",\n1\n1,1", "3");
            Testing(",\n-1,-2,-3", "Error");
            Testing(",\n1,1002,3", "4");
            Testing("*\n4*5", "9");
            Testing("**\n4**5", "9");
            Testing("hello\n4hello5", "9");
            Testing("[**][$$$][@]\n4$$$3**2@2@3$$$4", "18");


        }
    }
}
