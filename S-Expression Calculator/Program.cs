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
            int answer = 0;

            if(input.Length == 1)
            {
                answer = int.Parse(input[0]);
            }

            else
            {
                if(input[0] == "Add")
                { 

                }
            }

            Console.WriteLine(answer);
        }
    }
}
