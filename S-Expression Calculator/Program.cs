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
                for(int i = 0; i < inputList.Count; i++)
                {
                    if (inputList[i].Contains(")"))
                    {
                        int second = int.Parse(inputList[i].Remove(inputList[i].Length - 1, 1));
                        int first = int.Parse(inputList[i - 1]);
                        if (inputList[i - 2].Contains("add"))
                        {
                            var addinstance = new Program();
                            var addResult = addinstance.Add(second, first);
                            inputList[i] = addResult.ToString();
                            inputList.RemoveAt(i - 1);
                            inputList.RemoveAt(i - 2);
                        }
                    }
                } 
            }
        }

        public int Add(int firstNumber, int secondNumber)
        {
           int output = firstNumber + secondNumber;
            return output;
        }
    }
}
