using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_Expression_Calculator
{
    internal class Program
    {
        /// <summary>
        /// Main method for the S-Expression calculations.
        /// </summary>
        /// <param name="args">Command line argument that gets passed for evaluation. </param>
        static void Main(string[] args)
        {

            List<String> inputList = args.ToList();

            if(inputList.Count == 1)
            {
                Console.WriteLine(int.Parse(inputList[0]));
            }

            else
            {
                var addExpression = new Program();
                var results = addExpression.Expression(inputList);

                Console.WriteLine(results[0]);
            }
        }

        /// <summary>
        /// Method to iterate through the list, and call the add or multiply methods. 
        /// </summary>
        /// <param name="inputList">Gets a list of expressions and goes through it</param>
        /// <returns>Returns an updated list of expressions </returns>
        public List<String> Expression(List<String> inputList)
        {
            for (int i = 0; i < inputList.Count; i++)
            {
                if (inputList[i].Contains(")"))
                {
                    // Count how many parentheses there are
                    int count = inputList[i].Count(f => (f == ')'));

                    int second = int.Parse(inputList[i].Replace(")", ""));
                    int first = int.Parse(inputList[i - 1]);
                    if (inputList[i - 2].Contains("add"))
                    {
                        var addinstance = new Program();
                        var addResult = addinstance.Add(second, first);
                        string parameter = "";
                        if (count > 1)
                        {
                            for (int j = 1; j < count; j++)
                            {
                                parameter += ")";
                            }
                        }
                        inputList[i] = addResult.ToString() + parameter;
                        inputList.RemoveAt(i - 1);
                        inputList.RemoveAt(i - 2);
                    }

                    if (inputList[i - 2].Contains("multiply"))
                    {
                        var multiplyinstance = new Program();
                        var addResult = multiplyinstance.Multiply(second, first);
                        string parameter = "";
                        if (count > 1)
                        {
                            for (int j = 1; j < count; j++)
                            {
                                parameter += ")";
                            }
                        }
                        inputList[i] = addResult.ToString() + parameter;
                        inputList.RemoveAt(i - 1);
                        inputList.RemoveAt(i - 2);
                    }
                }
            }

            // Recursion to go through the expression.
            while(inputList.Count > 1)
            {
                Expression(inputList);
            }

            return inputList;
        }

        /// <summary>
        /// Method to add two number together and return the sum.
        /// </summary>
        /// <param name="firstNumber">First number to add</param>
        /// <param name="secondNumber">Second number to add</param>
        /// <returns>The value that gets returned. </returns>
        public int Add(int firstNumber, int secondNumber)
        {
           int output = firstNumber + secondNumber;
            return output;
        }

        /// <summary>
        /// Method to multiply two numbers together and return the sum. 
        /// </summary>
        /// <param name="firstNumber">First number to multiply.</param>
        /// <param name="secondNumber">Second number to muktiply.</param>
        /// <returns></returns>
        public int Multiply(int firstNumber, int secondNumber)
        {
            int output = firstNumber * secondNumber;
            return output;
        }
    }
}
