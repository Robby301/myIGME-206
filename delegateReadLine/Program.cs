using System;

namespace delegateReadLine
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Using a delegate method to replace the ReadLine function
    // Restrictions: None
    class Program
    {
        //Step 1 of making a delegate method: defining the delegate method data type based on the method signature
        delegate string LineReader();

        // Method: Main
        // Purpose: Finish the creation and use of the replacement ReadLine using a delegate method
        // Restrictions: None
        static void Main(string[] args)
        {
            //Step 2 of making a delegate method: Declaring the delegate method variable
            LineReader consoleReader;

            //Step 3 of creating a delegate method: point the variable to the method it should call
            consoleReader = new LineReader(Console.ReadLine);

            //The final step of the delegate method implementation: calling the delegate method
            string userLine = consoleReader();

            //This last line posts the user's string onto the console to see if the delegate method is working properly
            Console.WriteLine(userLine);
        }
    }
}