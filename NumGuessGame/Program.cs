using System;

namespace NumGuessGame
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: A number guessing game where the user inputs numbers until they either can or can't guess the randomly generated number
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: A number guessing game where a number between 0 to 100 (inclusive) is generated randomly, the user needs to guess that number and
        //          they are only allowed 8 attempts to do this. The program detects for false guesses that aren't a number or for guesses that are beyond
        //          the 0 to 100 bounds (but these don't count as a turn), and it will also tell the user when they guessed too low or too high from the
        //          randomly generated number (these count as turns). If the user guess correctly before their 8 turns are up they get a congratulations
        //          message. If they can't guess the number before 8 turns they get a failure message.
        // Restrictions: None
        static void Main(string[] args)
        {
            //This statement just tells the user that they are playing a number guessing game and it states the rules of the game
            Console.WriteLine("Number Guessing Game: please guess a number from 0 to 100, there are only 8 attempts, Good Luck!");

            //The next statement creates a Random object (called rand) from the Random class to be used later for making the random number
            Random rand = new Random();

            //The next two statements declare int variables: the first is used to run the while loop that controls the game, the second will be used to
            //hold the number the player guesses during the game
            int loopCounter = 0;
            int numGuess;

            // generate a random number between 0 inclusive and 101 exclusive
            int randomNumber = rand.Next(0, 101);

            //This statement displays the randomly generated number for testing purposes
            Console.WriteLine(randomNumber);

            //This while loop controls the main game and it is controlled by the loopCounter variable which increments by +1 after each successful guess
            while (loopCounter < 8)
            {
                //This statement tells the user what turn they are on and then prompts them for what their guess is
                Console.Write("Turn #" + (loopCounter + 1) + ": Enter your guess: ");

                //the try catch is used to detect any inputs that aren't a number, and if it isn't it returns to the start of the while loop
                try
                {
                    //this statement converts the guess the user typed into an integer
                    numGuess = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    //The next two statements tell the user that they typed an invalid guess and then proceeds to restart the while loop by using a
                    //continue statement so that the user can guess another number
                    Console.WriteLine("Invalid guess - try again");
                    continue;
                }

                //This list of if, else if, and else statements is used to check what sorts of guesses the user made:
                //The if statement checks to see if the user went out of the bounds of guess range, if so the loop resets without costing a turn
                //The first else if statement checks to see if the user's guess was higher, if so loopCounter increments and the user is told "too high"
                //The second else if statement checks to see if the user's guess was lower, if so loopCounter increments and the user is told "too low"
                //Finally, the else statement handles if the user guessed correctly. If they did the counter increments and they are told so and the loop
                //breaks
                if ((numGuess < 0) || (numGuess > 100))
                {
                    //The next two statements tell the user they made an invalid guess and then the loop is reset with a continue so they can guess again
                    Console.WriteLine("Invalid guess - try again");
                    continue;
                }
                else if(numGuess > randomNumber)
                {
                    //These statements increment the loopCounter because the user's guess was valid, but it also tells the user that their guess was too
                    //high
                    loopCounter++;
                    Console.WriteLine("Too high");
                }
                else if (numGuess < randomNumber)
                {
                    //These statements increment the loopCounter because the guess was valid, but then the user is told that their guess is too low
                    loopCounter++;
                    Console.WriteLine("Too low");
                }
                else
                {
                    //These statements are reached because the user guessed the number correctly, so the loopCounter is incremented, the user is given
                    //a congratulations message in the console and is told how many turns it took to win, then finally a break statement is used to break
                    //from the while loop and end the game
                    loopCounter++;
                    Console.WriteLine("\nCorrect! You won in " + loopCounter + " turns.");
                    break;
                }
            }

            //This last if statement checks to see if the while loop was broken do to it's loopCounter condition being greater than 8, if this is the case
            //that means the user reached their maximum amount of turns and has lost the game
            if(loopCounter == 8)
            {
                //This statement just tells the user that they have lost the number guessing game
                Console.WriteLine("\nYou ran out of turns. The number was " + randomNumber + ".");
            }
        }
    }
}