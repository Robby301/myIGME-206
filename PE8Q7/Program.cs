using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q7
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Asks the user for a string an is reversed
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Asks the user for a string, and using a for loop, is reversed. I've also added a bonus line of text to check to see if the user's
        //          string is a palindrome (a word that is the same backwards as it is forwards).
        // Restrictions: None
        static void Main(string[] args)
        {
            //Below are the two string variables that handle the user's string and the reversed form of the user's string
            string userString = null;
            string reverseUserString = null;

            //Below prompts the user for their string and makes the variable userString equal to what the user typed
            Console.WriteLine("Please type a string: ");
            userString = Console.ReadLine();

            //This for loop handles traversing the string in a reverse fashion by having the incremented value start at the bottom of the string and
            //increment down till the start of the string is met. While this is happening the reverseUserString variable is equal to each letter/space
            //that appears in the user's string (each of these letter/spaces is added onto the reverseUserString variable).
            for(int i = (userString.Length - 1); i >= 0; i--)
            {
                //This statement adds each letter/space from the userString onto the reverseUserString in a reverse fashion caused by the for loop
                reverseUserString += userString[i].ToString();
            }

            //This statement simply displays the reverse form of the userString to the console
            Console.WriteLine(reverseUserString);

            //This final if statement sees if the original string and the new string are equal to eachother. If so that means the user's string was a
            //palindrome, which is just a word that is the same backwards as it is forwards, and the user is told this within the console.
            if(reverseUserString.Equals(userString))
            {
                //Displays a message onto the console saying that the user's string was a palindrome
                Console.WriteLine("Congrats! You've found a Palindrome!");
            }
        }
    }
}