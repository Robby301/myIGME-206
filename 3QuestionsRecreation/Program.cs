using System;
using System.Timers;

namespace _3QuestionsRecreation
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Ask the user for a number from 1 to 3, depending on that number the user is asked a certian question. The user is expected to answer that question
    //          within a 5 second window. If they don't answer it within the time limit then they are told time is up and given the answer, which they are then
    //          asked whether they want to play again. The user can keep playing the game over and over and look at and answer all of the three questions.
    // Restrictions: None
    class Program
    {
        //These variables below help with the game process. The variables will hold which number the user picks for the question, the question itself, what
        //that question's answer is, and then finally the user's input for what they think the answer is.
        static int questionChoice;
        static string question;
        static string questionAnswer;
        static string userAnswer;

        //this bool variable will be used in the time feature to make sure the user types an answer within the 5 second window
        static bool timeOut;

        //this is the timer that will be used to create the 5 second window that the user has to answer the questions
        static Timer questionTimeOut;

        // Method: TimesUp
        // Purpose: This method controls the time feature to make sure the user answers within 5 seconds
        // Restrictions: None
        static void TimesUp(object source, ElapsedEventArgs e)
        {
            //The user is told that the time is up, then they are given the answer, then they are told to press enter so that they can be asked to play again
            Console.WriteLine("Times up!\nThe answer is: " + questionAnswer + "\nPlease press enter.");

            //this will tell the program later that the user was unable to answer before the 5 second window
            timeOut = true;

            //this stops the timer so it doesn't needlessly continue
            questionTimeOut.Stop();
        }

        // Method: Main
        // Purpose: The main method controls the entire game using many if statements to check what question the user wants, and then determines whether they:
        //          got it right, got it wrong, or timed out.
        //          The user is then finally asked whether they want to play the game again, the program then responds accordingly depending on the user's answer
        // Restrictions: None
        static void Main(string[] args)
        {
            //this statement is to match the format of the original program
            Console.WriteLine();

            //the start will be used to replay the game
            start:

            //this sets the timeOut bool to false so that when a player wants to answer a new question the timeOut bool isn't permantely set to true if they
            //timed out on the previous question
            timeOut = false;

            //this try-cath is to make sure the user typed a number, if not they go to the start to try again
            try
            {
                Console.Write("Choose your question (1-3): ");
                questionChoice = int.Parse(Console.ReadLine());
            }
            catch
            {
                goto start;
            }

            //this entire if statement is for the game process if the user wants to answer question 1 (this format is used exactly the same on the other questions
            //which is why those if statements will have no comments, because the code is essentially the same with minor differences)
            if(questionChoice == 1)
            {
                //the next two variables set the question and answer for question 1
                question = "What is your favorite color?";
                questionAnswer = "black";

                //this statement tells the user that they have 5 seconds and then prompts the question they need to ask
                Console.WriteLine("You have 5 seconds to answer the following question:\n" + question);

                //the next statements all set up the timer for when the user needs to answer within the 5 second period
                questionTimeOut = new Timer(5000);
                ElapsedEventHandler elapsedEventHandler;
                elapsedEventHandler = new ElapsedEventHandler(TimesUp);
                questionTimeOut.Elapsed += elapsedEventHandler;

                //the next few statements start the timer, get the user's input as long as they answered before the 5 second limit, and then stop the timer so
                //that is doesn't needlessly continue
                questionTimeOut.Start();
                userAnswer = Console.ReadLine();
                questionTimeOut.Stop();

                //This if statement checks to see whether the user's answer was correct and within the 5 second allowable answer period
                if(userAnswer.Equals(questionAnswer) && !timeOut)
                {
                    //this statement tells the user they answered correctly
                    Console.WriteLine("Well done!");

                    //this statement is used to reset the user if they did not answer whether they will play again
                    playcheck:

                    //the next two statements ask the user if they want to play again, and then reads their answer from the console and puts it into the
                    //userAnswer variable
                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    //the next if checks to see whether the user answered yes, if they did they go back to the start of the game
                    if(userAnswer.ToLower().StartsWith("y"))
                    {
                        //the next two statements add and indent in the console, for formatting purposes, and then returns to the start of the game
                        Console.WriteLine();
                        goto start;
                    }

                    //this else-if checks to see if the user responded with no, if so the program terminates and is finished
                    else if(userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    //this final else just checks to see if the user typed nothing as an answer to play again, if so they are reset to the playcheck label and
                    //are prompted if they want to play again again.
                    else
                    {
                        goto playcheck;
                    }
                }

                //this else-if checks to see if the user type something in the 5 second period but was wrong. If so they are told so, and then given the right
                //answer. Then they are asked if they want to play again
                else if(!(userAnswer.Equals(questionAnswer)) && !timeOut)
                {
                    //this statement tells the user that they are wrong and then gives them the correct answer
                    Console.WriteLine("Wrong!  The answer is: " + questionAnswer);

                    //all the code below is now the same as it was within the first if statement, so it doesn't need to be repeated
                    elseplaycheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto elseplaycheck;
                    }
                }

                //this last else statement is used for when the user times out and can't answer, they are asked to play again and that is it
                else
                {
                    lastplaycheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto lastplaycheck;
                    }
                }
            }

            //This else-if statement checks to see if the user wanted question 2, if so all of the below code is done in the same way and functions just like the
            //previous if statement that checked for if the user wanted question 1. Because of this no more comments are needed.
            else if (questionChoice == 2)
            {
                question = "What is the answer to life, the universe and everything?";
                questionAnswer = "42";

                Console.WriteLine("You have 5 seconds to answer the following question:\n" + question);

                questionTimeOut = new Timer(5000);

                ElapsedEventHandler elapsedEventHandler;

                elapsedEventHandler = new ElapsedEventHandler(TimesUp);

                questionTimeOut.Elapsed += elapsedEventHandler;

                questionTimeOut.Start();

                userAnswer = Console.ReadLine();

                questionTimeOut.Stop();

                if (userAnswer.Equals(questionAnswer) && !timeOut)
                {
                    Console.WriteLine("Well done!");

                    playcheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto playcheck;
                    }
                }

                else if (!(userAnswer.Equals(questionAnswer)) && !timeOut)
                {
                    Console.WriteLine("Wrong!  The answer is: " + questionAnswer);

                    elseplaycheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto elseplaycheck;
                    }
                }

                else
                {
                    lastplaycheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto lastplaycheck;
                    }
                }
            }

            //This else-if statement checks to see if the user wanted question 3, if so all of the below code is done in the same way and functions just like the
            //previous if statements that checked for if the user wanted question 1 or 2. Because of this no more comments are needed.
            else if (questionChoice == 3)
            {
                question = "What is the airspeed velocity of an unladen swallow?";
                questionAnswer = "What do you mean? African or European swallow?";

                Console.WriteLine("You have 5 seconds to answer the following question:\n" + question);

                questionTimeOut = new Timer(5000);

                ElapsedEventHandler elapsedEventHandler;

                elapsedEventHandler = new ElapsedEventHandler(TimesUp);

                questionTimeOut.Elapsed += elapsedEventHandler;

                questionTimeOut.Start();

                userAnswer = Console.ReadLine();

                questionTimeOut.Stop();

                if (userAnswer.Equals(questionAnswer) && !timeOut)
                {
                    Console.WriteLine("Well done!");

                    playcheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto playcheck;
                    }
                }

                else if (!(userAnswer.Equals(questionAnswer)) && !timeOut)
                {
                    Console.WriteLine("Wrong!  The answer is: " + questionAnswer);

                    elseplaycheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto elseplaycheck;
                    }
                }

                else
                {
                    lastplaycheck:

                    Console.Write("Play again? ");
                    userAnswer = Console.ReadLine();

                    if (userAnswer.ToLower().StartsWith("y"))
                    {
                        Console.WriteLine();
                        goto start;
                    }

                    else if (userAnswer.ToLower().StartsWith("n"))
                    {
                        System.Environment.Exit(0);
                    }

                    else
                    {
                        goto lastplaycheck;
                    }
                }
            }

            //this final else statement handles if the user did not type anything for choosing which question they wanted, if this is the case they are reset
            //to the start of the game and asked again. This is to ensure the user types one of the question numbers.
            else
            {
                goto start;
            }
        }
    }
}