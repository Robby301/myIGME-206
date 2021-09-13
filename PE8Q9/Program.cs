using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q9
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Puts double quotes around each word within a string
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Using a string variable, each word within that string is changed to have double quotes around it
        // Restrictions: None
        static void Main(string[] args)
        {
            //The three lines below have two string variables (one that holds the final sentence with quotes, and one that holds the accepted sentence)
            //and the final line is a string array that holds each word that is within the sentence (this is done using the Split method).
            string quotedSentence = null;
            string sentence = "No, I have nothing in my purse!";
            string[] words = sentence.Split(' ');

            //This foreach looks at each word within the sentence (which were all held in the words array), and by using the quotedSentence variable,
            //adds quotes around each word and then all the words are added into this one string variable.
            foreach (string word in words)
            {
                //This first statement puts the first double quote in front of the word
                quotedSentence += "\"";

                //This next statement adds the word after the first quote
                quotedSentence += word;

                //This final statement adds the second double quotes after the word, and because of the foreach loop this is done to all the words until
                //each word from the original sentence has double quotes around it
                quotedSentence += "\" ";
            }

            //This last statement just prints the changed sentence into the console, now with each word having double quotes around it
            Console.WriteLine(quotedSentence);
        }
    }
}