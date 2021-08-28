//The statement belows allows the access to the system namespace for easier coding within the program
using System;

//Below is the namespace for the HelloWorld project/assignment
namespace Disbrow_HelloWorld
{
    //Class: Program
    //Author: Robert Gregory Disbrow
    //Purpose: Outputs the sum of two author made variables to the console, and prints "Hello World!" that number of times.
    //Restriction: None
    static class Program
    {
        //Method: Main
        //Purpose: Within the main two int variables, called num1 and num2, are made to be added and that sum is printed to the console.
        //         That sum is then used in the final for loop to print the statement "Hello World!" that number of times.
        //Restriction: None
        static void Main(string[] args)
        {
            //The next two statements declare integer variables num1 and num2 so that math calculations can be made
            int num1 = 1 + 2;
            int num2 = 3;

            //The next statement prints the sum of num1 and num2 into the console (the new line is only used for formatting purposes in the console)
            Console.WriteLine("Num 1 + Num 2 = " + (num1 + num2) + "\n");

            //This final part is a for loop that prints the statement "Hello World!" six times (or the number of times the sum of num1 and num2 equals)
            for(int i = 0; i < (num1 + num2); i++)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}