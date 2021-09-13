using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q8
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Replaces any occurences of the word no within a string to the word yes (case-insensitive)
    // Restrictions: None
    class Program
    {

        // Method: Main
        // Purpose: Using two replace methods, all occurences of the word no within the string variable labeled "sentence" will be replaced with the word
        //yes. Two replace methods are used to take into account the case-insensitivity.
        // Restrictions: None
        static void Main(string[] args)
        {
            //The string variable that takes whatever sentence that will be used for replacing nos with yeses
            string sentence = "No, I have nothing in my purse!";

            //Below are the two replace methods used to replace any occurence of the word no with the word yes
            sentence = sentence.Replace("No", "Yes");
            sentence = sentence.Replace("no", "yes");

            //Finally, this just prints the sentence onto the console to see that the replace methods worked properly.
            Console.WriteLine(sentence);
        }
    }
}