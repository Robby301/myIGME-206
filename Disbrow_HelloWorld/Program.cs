//The statement belows allows the access to the system namespace for easier coding within the program
using System;

//Below is the namespace for the HelloWorld project/assignment
namespace Disbrow_HelloWorld
{
    //The "class program" statement simply creates a class called program that within can be used to write the core of this assignment
    class Program
    {
        //The next statement is a method called the main method where the code will be written
        static void Main(string[] args)
        {
            //The next two statements declare integer variables num1 and num2 so that math calculations can be made
            int num1 = 1 + 2;
            int num2 = 3;

            //The next statement prints the sum of num1 and num2 into the console
            Console.WriteLine("Num 1 + Num 2 = " + (num1 + num2) + "\n");

            //This final part is a for loop that prints the statement "Hello World!" six times (or the number of times the sum of num1 and num2 equals)
            for(int i = 0; i < (num1 + num2); i++)
            {Console.WriteLine("Hello World!");}
        }
    }
}