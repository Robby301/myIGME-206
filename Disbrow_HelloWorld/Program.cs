using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disbrow_HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = 1 + 2;
            int num2 = 3;

            Console.WriteLine("Num 1 + Num 2 = " + (num1 + num2) + "\n");

            for(int i = 0; i < (num1 + num2); i++)
            {Console.WriteLine("Hello World!");}
        }
    }
}