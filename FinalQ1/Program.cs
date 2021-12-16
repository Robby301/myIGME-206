using System;

namespace FinalQ1
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: This program will take a user's inputted sentence and output how much of each alphabetical letter appears in that sentence
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: The main is where the program performs the operations to get the user sentence and output how much of each letter appears in the sentence
        // Restrictions: None
        static void Main(string[] args)
        {
            string sentence;
            string letter;
            int[] letterCount = new int[26];

            Random rand = new Random();

            Console.Write("Enter your sentence: ");
            sentence = Console.ReadLine();

            //This foreach loop handles getting the count/amount of how much each letter appears in the sentence by using the char value of lowercase "a" as a
            //pointer to each index of each letter in the alphabet (with 0 being a, 1 being b and so on until 25 is z (the 26th letter)).
            //That's done by subtracting the letter's char value by the char value of "a"
            foreach (char c in sentence.ToLower())
            {
                if (char.IsLetter(c))
                {
                    ++letterCount[c - 'a'];
                }
            }

            Console.WriteLine("Character counts:");

            //This for loop is what outputs the information of how much each letter appears in the user's sentence
            for (int i = 0; i < letterCount.Length; ++i)
            {
                letter = ((char)(i + 'a')).ToString();
                Console.WriteLine(letter.ToUpper() + ": " + letterCount[i]);
            }
        }
    }
}