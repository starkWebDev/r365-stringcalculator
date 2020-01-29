using System;
using System.Collections;
using System.Collections.Generic;

namespace r365challengecalculator
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int Calculate(string nums){
                List<string> inputNums = new List<string>(nums.Split(','));
                int total;
                int num1;
                int num2;

                int CheckForValid(string input)
                {
                    if (Int32.TryParse(input, out _))
                    {
                        return Int32.Parse(input);
                    }
                    return 0;
                }

                if (inputNums.Count == 0)
                {
                    num1 = 0;
                    num2 = 0;
                }
                else if (inputNums.Count == 1)
                {
                    num1 = CheckForValid(inputNums[0]);
                    num2 = 0;
                }
                else
                {
                    num1 = CheckForValid(inputNums[0]);
                    num2 = CheckForValid(inputNums[1]);
                }

                total = num1 + num2;

                return(total);
            }

            void Testing(string input, int expected)
            {
                Console.WriteLine($"Input: {input}. Expected output: {expected}");
                int answer = Calculate(input);
                Console.WriteLine(answer == expected ? "Correct" : $"Incorrect. Got {answer}");
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

        }
    }
}
