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

            int Calculate(string nums){
                List<string> inputNums = new List<string>(nums.Split(','));
                int total;

                if (inputNums.Count == 0)
                {
                    total = 0;
                    return (total);
                }

                IEnumerable<int> convertedNums =  inputNums.Select(input => CheckForValid(input));
                total = convertedNums.Sum();

                return(total);
            }

            void Testing(string input, int expected)
            {
                Console.WriteLine($"Input: {input}\nExpected output: {expected}");
                int answer = Calculate(input);
                Console.WriteLine(answer == expected ? "Correct\n" : $"Incorrect. Got {answer}\n");
            }

            Testing("1,1", 2);
            Testing("", 0);
            Testing("1,hi", 1);
            Testing("hi,1", 1);
            Testing("hi", 0);
            Testing("hi,hi", 0);
            Testing("2,2", 4);
            Testing(",", 0);
            Testing("-1,5", 4);
            Testing("1,2,3", 6);
            Testing("1,2,3,4", 10);
            Testing("hi,hi,hi", 0);
            Testing("hi,1,hi", 1);
            Testing("1,1,hi", 2);
            Testing("hi,1,1", 2);
            Testing(",1,1", 2);

        }
    }
}
