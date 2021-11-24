using System;

namespace UT3Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] alphabet =
            {
                "a",
                "b",
                "c",
                "d",
                "e",
                "f",
                "g",
                "h",
                "i",
                "j",
                "k",
                "l",
                "m",
                "n",
                "o",
                "p",
                "q",
                "r",
                "s",
                "t",
                "u",
                "v",
                "w",
                "x",
                "y",
                "z",
            };
            string userString;
            string noPunctuationString = null;
            string reverseUserString = null;
            string noPunctReverse = null;

            Console.Write("Please type a string: ");
            userString = Console.ReadLine();
            Console.WriteLine();

            //Below will print the amount of occurences of each letter of the alphabet

            for(int i = 0; i < alphabet.Length; i++)
            {
                int letterCount = 0;

                for(int k = 0; k < userString.Length; k++)
                {
                    if(alphabet[i].Equals((userString[k].ToString()).ToLower()))
                    {
                        letterCount++;
                    }
                }

                Console.WriteLine("Number of occurences of " + alphabet[i].ToUpper() + ": " + letterCount);
            }

            //Below will reverse the user's string (userString variable)

            Console.WriteLine();

            for(int i = userString.Length - 1; i >= 0; i--)
            {
                reverseUserString += userString[i].ToString();
            }

            Console.WriteLine("Reverse order: " + reverseUserString);

            //Below will determine and say if the string is a palindrome

            Console.WriteLine();

            for(int i = 0; i < userString.Length; i++)
            {
                for (int k = 0; k < alphabet.Length; k++)
                {
                    if (((userString[i].ToString()).ToLower()).Equals(alphabet[k]))
                    {
                        noPunctuationString += (userString[i].ToString()).ToLower();
                    }
                }
            }

            for(int i = 0; i < reverseUserString.Length; i++)
            {
                for (int k = 0; k < alphabet.Length; k++)
                {
                    if (((reverseUserString[i].ToString()).ToLower()).Equals(alphabet[k]))
                    {
                        noPunctReverse += (reverseUserString[i].ToString()).ToLower();
                    }
                }
            }

            if(noPunctuationString.Equals(noPunctReverse))
            {
                Console.WriteLine("Palindrome: This is a palindrome!");
            }
            else
            {
                Console.WriteLine("Palindrome: This is not a palindrome!");
            }
        }
    }
}