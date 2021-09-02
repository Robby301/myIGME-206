using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //Syntax Error: No Semicolon at the end of the statement
            //int i = 0

            int i = 0;

            // declare the string for all numbers through the loop
            string allNumbers = null;

            // loop through the numbers 1 through 10
            //Logic Error: comment wants to use the for loop to loop through 1 through 10, but the given code will not loop through those numbers
            //for (i = 1; i < 10; ++i)
            for (i = 1; i <= 10; ++i)
            {
                // declare string to hold all numbers
                // Logic Error: Mainly a logic error for later in the program, this declaration needs to be on the outside of the for loop
                //string allNumbers = null;

                // output explanation of calculation
                //Syntax Error: the - symbol needs to have quotes and have the + symbol on the left & right of it (program is trying to subtract an
                //int from a string
                //Console.Write(i + "/" + i - 1 + " = ");

                Console.Write(i + "/" + i + "-" + 1 + " = ");

                // output the calculation based on the numbers
                //Run-time Error: When i = 1 the program trys to divide by 0, which can not be done
                //Console.WriteLine(i / (i - 1));

                if(i == 1)
                {
                    Console.WriteLine("Undefined (divide by zero)");
                }

                else
                {
                    Console.WriteLine(i / (i - 1));
                }

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                //Logic Error: Don't need to increment the counter when the for loop already handles the incrementation
                //i = i + 1;
            }

            // output all numbers which have been processed
            //Syntax Error: need the + symbol between the quoted text and the allNumbers variable
            //Console.WriteLine("These numbers have been processed: " allNumbers);

            //Logic Error: In order for all numbers to work and be concatenated is needs to be declared before the for loop
            //Console.WriteLine("These numbers have been processed: " + allNumbers);

            Console.WriteLine("These numbers have been processed: " + allNumbers);
        }
    }
}