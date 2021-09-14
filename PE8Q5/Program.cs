using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE8Q5
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: Using the formula z = 3y2 + 2x - 1, z was calculated for these ranges of x and y:
    //          -1 <= x <= 1 in 0.1 increments
    //          1 <= y <= 4 in 0.1 increments
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: With the formula z = 3y2 + 2x - 1, z was calculated with the ranges of x and y:
        //          -1 <= x <= 1 in 0.1 increments
        //          1 <= y <= 4 in 0.1 increments
        //          All of this information was put into a 3 dimensional array labeled function, and this was done by using for loops that increment
        //          through the 3 dimensional array until the 3 dimensional array was completely filled.
        // Restrictions: None
        static void Main(string[] args)
        {
            double x;
            double y;
            double z;

            double xCounter1 = 0;
            int xCounter2 = 0;
            double yCounter1 = 0;
            int yCounter2 = 0;

            double[,,] function = new double[20, 30, 3];

            for(x = -1; x <= 1; xCounter1 += 0.1)
            {
                yCounter1 = 0;
                yCounter2 = 0;

                for(y = 1; y <= 4; yCounter1 += 0.1)
                {
                    z = (3 * Math.Pow(y, 2)) + (2 * x) - 1;

                    function[xCounter2, yCounter2, 0] = x;
                    function[xCounter2, yCounter2, 1] = y;
                    function[xCounter2, yCounter2, 2] = z;

                    yCounter2++;
                }

                xCounter2++;
            }
        }
    }
}