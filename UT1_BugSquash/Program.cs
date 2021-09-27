using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //Compile-time error: end of statement needs a semicolon
            //int nY
            int ny;
            int nAnswer;

            //Compile-time error: console.writeline statement is written wrong, needs quotes around the sentence to be considered a string
            //Console.WriteLine(This program calculates x ^ y.);
            Console.WriteLine("Thi program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Run-time error: while it is possible to just do Console.ReadLine, the program in this case will not work correctly because what is being
                //read is suppoused to be put into the sNumber variable.
                //Console.ReadLine();
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
                //Run-time error: without the negator ! in front of the tryparse, the do-while will loop if the user types in a number correctly. But really
                //when the user types the number correctly the do-while should be breaking, which will happen with a ! in front of the statement.
            //} while (int.TryParse(sNumber, out nX));
                //Logical error: at the end of the tryparse the program is setting what the user types into nX when it should really be setting to ny. This
                //wants the user to type their number for why, which is why it needs to be set to ny and not nX.
            //} while (!int.TryParse(sNumber, out nX));
            } while (!int.TryParse(sNumber, out ny));

            // compute the factorial of the number using a recursive function
            //Compile-time error: the nY within the below statement really should be ny because the programmer did not set a variable named nY, only a variable
            //named ny.
            //nAnswer = Power(nX, nY);
            nAnswer = Power(nX, ny);

            //Logical error: the way the programmer wants to use the Console.WriteLine is not set up properly, what is done below will always print the same
            //string into the console
            //Console.WriteLine("{nX}^{nY} = {nAnswer}");
            Console.WriteLine("{0}^{1} = {2}", nX, ny, nAnswer);
        }

        //Compile-time error: in order for the method to be used within the main in the upper code, this method needs to be static.
        //int Power(int nBase, int nExponent)
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //Run-time error: need to use return so that the recursive method is returning a value to allow it to recurse backwards
                //returnVal = 0;
                //Logical error: need to have returnVal be set to 1, if not the program will keep multiplying by zero resulting in a constant answer of 0
                //return (returnVal = 0);
                return (returnVal = 1);
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //Logical error: program wants to subtract 1 from nExponent, but it is adding 1
                //nextVal = Power(nBase, nExponent + 1);
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
                returnVal = nBase * nextVal;
            }

            //Compile-time error: need to have a return in front of the below statement, without it the method will never recurse
            //returnVal;
            return returnVal;
        }
    }
}