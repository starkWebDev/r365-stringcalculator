using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace r365challengecalculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
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

            string Calculate(string _nums){
                char delim = _nums[0];
                string nums = _nums.Substring(2);
                List<string> inputNums = new List<string>(nums.Split(new char[] { delim, '\n' }));

                int total;

                if (inputNums.Count == 0)
                {
                    total = 0;
                    return (total.ToString());
                }

                List<int> negNums = new List<int>();

                List<int> convertedNums = new List<int>();

                foreach(var num in inputNums)
                {
                    int _num = CheckForValid(num);
                    if (_num < 0)
                    {
                        negNums.Add(_num);
                    }
                    convertedNums.Add(_num);
                }

                if (negNums.Count != 0)
                {
                    string msg = "Error. Inputs cannot be negative. you input: ";
                    foreach(var num in negNums)
                    {
                        msg += $" {num},";
                    }
                    return (msg);

                }

                total = convertedNums.Sum();
                return(total.ToString());
            }

            void Testing(string input, string expected)
            {
                Console.WriteLine($"Input: {input.Replace("\n", "\\n")}\nExpected output: {expected}");
                string answer = Calculate(input);
                Console.WriteLine($"Output: {answer}\n");
            }

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

            // Based on the examples given in requirement 6, specifically ",\n2,ff,100 will return 102",
            // I am going go on the assumption that the previous formats will be accepted in this way as well.
            // my reason for this is that if both methods of submission were allowed there would be no way
            // to know if the submission "1\n2" was supposed to return 3 - like previous format - or if
            // the 1 was the delimiter - like the new format -  which would result in 2

        }
    }
}
