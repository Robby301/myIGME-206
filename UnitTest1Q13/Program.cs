using System;

namespace UnitTest1Q13
{
    //the below struct is used to handle the name and salary of the employee for later use within the program
    struct employee
    {
        public string sName;
        public double dSalary;
    }

    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: This program accepts the user's name and, based on if their name is my name, increases the
    //          already set salary by 19,999.99
    // Restrictions: None
    class Program
    {
        // Method: GiveRaise
        // Purpose: This method is what allows the salary to get added by 19,999.99 is the user's name is
        //          my name
        // Restrictions: None
        private static bool GiveRaise(ref employee person)
        {
            //This if checks to see if the user name is equal to my name, if it is salary is added by 19,999.99
            //then the method returns true
            if ((person.sName).Equals("Robert Gregory Disbrow"))
            {
                //19,999.99 is added to salary and then the method returns true
                person.dSalary += 19999.99;
                return true;
            }

            //The else happens if the user's name isn't mine
            else
            {
                //method returns false because the user's name was not mine
                return false;
            }
        }

        // Method: Main
        // Purpose: The main has the salary variable and prompts the user for their name and sets it
        //          to the name variable. Then the giveraise method is called to determine whether the user's name
        //          is my name and then adds 19,999.99 to salary. If the user's salary was increased the console
        //          displays a message congratulating the user.
        // Restrictions: None
        static void Main(string[] args)
        {
            //this statement creates a new emloyee just called person, this is so that the struct can be used for later in the program
            employee person = new employee();

            //Variable salary is made for the program's use
            person.dSalary = 30000;

            //The user is prompted to input their name and then the name variable is set to the user inputted name
            Console.Write("Please type your name: ");
            person.sName = Console.ReadLine();

            //This if checks to see, using the giveraise method, if the user's name was mine. If it is the console
            //displays a message congratulating the user that they got a raise
            if (GiveRaise(ref person))
            {
                //Below is the statement that congratulations the user that they got a raise
                Console.WriteLine("Congratulations " + person.sName + " you got a raise!\nYour new salary is: $" + person.dSalary);
            }

            //The else is for when the user's name was not mine, and then tells the user this
            else
            {
                //This is the statement that tells the user that they did not get a raise
                Console.WriteLine("Sorry " + person.sName + " you are not getting a raise...\nYour salary still is: $" + person.dSalary);
            }
        }
    }
}