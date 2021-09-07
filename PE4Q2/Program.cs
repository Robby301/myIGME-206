using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE4Q2
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Asks user for 2 numbers then displays them; unless both those numbers are bigger than 10, in which case the user is asked to try again
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Takes two number inputs from the user and displays them, if both those numbers are bigger than 10 the user must retype their numbers.
        //          The program repeats based upon whether the user then types a y for yes or an n for no.
        // Restrictions: None
        static void Main(string[] args)
        {
            //The next two statements declare 2 int variables (num1 and num2) and also a boolean variable (programRun) for later use in the program
            //(num1 and num2 are used for the numbers the user types into the console, and the boolean statement is used to keep the program in a loop
            //until the user wants to terminate the program)
            int num1, num2;
            bool programRun = true;

            //below is the while loop that handles letting the user type two numbers until that user wants to terminate the program
            while(programRun)
            {
                //the next couple lines declare two variables
                //the "replay" string variable is used to see whether the user types y or n to determine whether they continue or terminate the program
                //the boolean variable is used later in the program in another loop to make sure the user types in y or n specifically
                string replay = null;
                bool isReplay = true;

                //this try catch is used to make sure the user types in legitimate numbers for the program to work properly
                try
                {
                    //the interior of this try just prompts the user for each number and sets the appropriate variables to those answers
                    Console.WriteLine("What is your first number:");
                    num1 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("What is your second number:");
                    num2 = Convert.ToInt32(Console.ReadLine());
                }
                
                //the catch handles whether the user did type a legitimate number when prompted to do so
                catch
                {
                    //the writeline statement just tells the user that they've caused an error and the program then continues to the start of the loop
                    //to prompt them for new numbers
                    Console.WriteLine("Error: please type the numbers you want correctly");
                    continue;
                }

                //this if statement handles whether both of the numbers the user inputed were bigger than 10, if so the program continues to the start of
                //the loop to ask for new numbers
                if((num1 > 10) && (num2 > 10))
                {
                    //similarly to the catch, the interior of this if tells the user that they cause an error by inputting two numbers higher than 10
                    //and then the program continues to the start of the loop to prompt the user for new numbers
                    Console.WriteLine("ERROR: both numbers can't be larger than 10, please type your numbers again");
                    continue;
                }

                //this next statement simply posts the numbers the user inputted onto the console
                Console.WriteLine("Your numbers: " + num1 + ", " + num2);

                //this next while handles whether the user inputted either y or n for yes or no to determine whether they want to run the program again
                //or just termintate the program
                //it is a loop because if the user doesn't type y or n properly it forces the user to eventually type it correctly to either terminate or
                //continue the program
                while (isReplay)
                {
                    //the next two statements ask the user whether they want to continue or not, which then their answer gets read into the string
                    //variable replay
                    Console.WriteLine("Would you like to display numbers again (please type only y for yes or n for no):");
                    replay = Console.ReadLine();

                    //this if checks to see if the user inputted y for yes to continue the program
                    if (replay.Equals("y"))
                    {
                        //because the user wants to continue the program, returning to the start is necessary by simply breaking out of this while loop
                        //so that the program can continue into the normal while loop, without changing the boolean variable that controls whether the
                        //program continues or not
                        break;
                    }

                    //the else if statement checks to see if the user typed n, if so the program terminates by changing the while loop's boolean variable
                    //to false and breaking out of this inner while loop to reach the outter while loop which then will lead to the program finishing 
                    //because the while loop is no longer continued
                    else if (replay.Equals("n"))
                    {
                        //the first statement tells the user that the program terminated, then the next two control the termination of the program by
                        //setting the outer while loop boolean variable to false and then breaking out of this inner while loop with a break statement
                        //so that the outter while loop can be reached and finished
                        Console.WriteLine("Program Terminated, goodbye");
                        programRun = false;
                        break;
                    }

                    //this final else statement tells the user that they need to type either y or n to continue or terminate the program
                    else
                    {
                        //this next statement gives the user an error message saying that they need to type their answer properly with either a y for yes
                        //or n for no
                        Console.WriteLine("ERROR: type either y for yes or n for no");
                    }
                }
            }
        }
    }
}