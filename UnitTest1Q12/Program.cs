using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest1Q12
{
    class Program
    {
        static bool GiveRaise(string name, ref double salary)
        {
            if(name.Equals("Robert Gregory Disbrow"))
            {
                salary += 19999.99;
                return true;
            }

            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            Console.Write("Please type your name: ");
            sName = Console.ReadLine();

            if(GiveRaise(sName, ref dSalary))
            {
                Console.WriteLine("Congratulations " + sName + " you got a raise!\nYour new salary is: $" + dSalary);
            }

            else
            {
                Console.WriteLine("Sorry " + sName + " you are not getting a raise...\nYour salary still is: $" + dSalary);
            }
        }
    }
}