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
                    return Int32.Parse(input);
                }
                return 0;
            }

            string Calculate(string nums){
                List<string> inputNums = new List<string>(nums.Split(new char[] { ',', '\n' }));
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

            Testing("1,1", "2");
            Testing("", "0");
            Testing("1,hi", "1");
            Testing("hi,1", "1");
            Testing("hi", "0");
            Testing("hi,hi", "0");
            Testing("2,2", "4");
            Testing(",", "0");
            Testing("-1,5", "Error");
            Testing("1,2,3", "6");
            Testing("1,2,3,4", "10");
            Testing("hi,hi,hi", "0");
            Testing("hi,1,hi", "1");
            Testing("1,1,hi", "2");
            Testing("hi,1,1", "2");
            Testing(",1,1", "2");
            Testing("1\n1,1", "3");
            Testing("-1,-2,-3", "Error");

        }
    }
}
