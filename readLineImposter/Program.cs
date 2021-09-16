using System;

namespace readLineImposter
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Using a delegate method, the ReadLine function is impersonated
    // Restrictions: None
    class Program
    {
        //Below is the first step to making a delegate method: defining the delegate method data type based on the method signature
        delegate string LineReader();

        //Method: ReadLine
        //Purpose: This method is used to impersonate the normal ReadLine function
        //Restrictions: None
        public static string ReadLine()
        {
            //Below sets a string called userLine to whatever the console reads (this is how ReadLine is impersonated)
            string userLine = Console.ReadLine();

            //Finally the string the user typed in is returned so the method can conclude
            return userLine;
        }

        // Method: Main
        // Purpose: Finish the creation and use of the ReadLine imposter using a delegate method
        // Restrictions: None
        static void Main(string[] args)
        {
            //The next statement is for the next step of making a delegate method: Declaring the delegate method variable
            LineReader consoleReader;

            //Next the 3 part of creating a delegate method is done: point the variable to the method it should call
            consoleReader = new LineReader(ReadLine);

            //This line is used for the final part of creating/using a delegate method: calling the delegate method
            string userLine = consoleReader();

            //This final line just posts the string variable to see if it read the line correctly
            Console.WriteLine(userLine);
        }
    }
}