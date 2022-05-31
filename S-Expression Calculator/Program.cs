using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S_Expression_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var input = args;
            List<String> inputList = input.ToList();

            int answer = 0;

            if(input.Length == 1)
            {
                answer = int.Parse(input[0]);
                Console.WriteLine(answer);
            }

            else
            {
                var addExpression = new Program();
                var results = addExpression.Expression(inputList);
                
                while(results.Count > 1)
                {
                    results = addExpression.Expression(inputList);
                }

                Console.WriteLine(results[0]);
            }
        }

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

            return inputList;
        }

        /// <summary>
        /// Method to add two number together and return the sum.
        /// </summary>
        /// <param name="firstNumber">First number</param>
        /// <param name="secondNumber"></param>
        /// <returns></returns>
        public int Add(int firstNumber, int secondNumber)
        {
           int output = firstNumber + secondNumber;
            return output;
        }

        public int Multiply(int firstNumber, int secondNumber)
        {
            int output = firstNumber * secondNumber;
            return output;
        }
    }
}
