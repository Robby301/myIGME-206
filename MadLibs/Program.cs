using System;
using System.IO;

namespace MadLibs
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Play Mad Libs from a list a stories determined by a text document
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Asks the user for their name and whether they want to play mad libs or not, if not the program closes. If they say yes the game continues to play normal Mad Libs
        // Restrictions: None
        static void Main(string[] args)
        {
            int numStories = 0;
            int storyChoice;
            string[] stories;
            string[] madLibsStory;
            string chosenStory;
            string name;
            string willPlay = null;
            string resultString = null;
            string holder = null;
            string madLibsWord = null;
            StreamReader firstReader = null;
            StreamReader madLibsStories = null;
            StreamReader story = null;

            Console.WriteLine("Please type your name: ");
            name = Console.ReadLine();

            while(true)
            {
                Console.Write("Would you like to play Mad Libs (type yes or no): ");
                willPlay = Console.ReadLine();

                if((willPlay.ToLower()).StartsWith("y"))
                {
                    Console.WriteLine("Welcome to Mad Libs " + name + "!");
                    break;
                }

                else if((willPlay.ToLower()).StartsWith("n"))
                {
                    Console.WriteLine("Goodbye " + name + "!");
                    System.Environment.Exit(0);
                }
            }

            try
            {
                firstReader = new StreamReader("C:\\Users\\roble\\OneDrive\\Desktop\\College Things\\RIT\\Semester 1\\Game Dev For Programmers\\GitHubRepos\\myIGME-206\\MadLibs\\MadLibsTemplate.txt");
                madLibsStories = new StreamReader("C:\\Users\\roble\\OneDrive\\Desktop\\College Things\\RIT\\Semester 1\\Game Dev For Programmers\\GitHubRepos\\myIGME-206\\MadLibs\\MadLibsTemplate.txt");
            }
            catch
            {
                Console.WriteLine("Error: UH OH, could not find the file!");
            }

            while ((holder = firstReader.ReadLine()) != null)
            {
                numStories++;
            }

            firstReader.Close();

            stories = new string[numStories];

            for(int i = 0; i < stories.Length; i++)
            {
                stories[i] = madLibsStories.ReadLine();
            }

            madLibsStories.Close();

            while (true)
            {
                Console.Write("Please type a number 1 - " + stories.Length + " to pick which Mad Libs story you wish to play: ");

                try
                {
                    storyChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Error: not a number, please type again");
                    continue;
                }

                if (storyChoice > 6 || storyChoice < 1)
                {
                    Console.WriteLine("Error: please type a number withint the range given");
                    continue;
                }
                else
                {
                    break;
                }
            }

            chosenStory = stories[storyChoice - 1];

            madLibsStory = chosenStory.Split(' ');

            foreach(string word in madLibsStory)
            {
                String holderWord = word;

                if(word.StartsWith("{"))
                {
                    holderWord = word.Replace("{", "");
                    holderWord = holderWord.Replace("}", "");
                    holderWord = holderWord.Replace("_", " ");
                    Console.WriteLine("Please type a(n): " + holderWord);

                    madLibsWord = Console.ReadLine();

                    resultString += madLibsWord + " ";
                }

                else if(word.Equals("\\n"))
                {
                    resultString += '\n';
                }

                else
                {
                    resultString += word + " ";
                }
            }

            Console.WriteLine(resultString);
        }
    }
}