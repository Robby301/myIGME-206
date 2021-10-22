using System;
using System.Collections.Generic;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tuple<string, int, double> avgRainfall = new Tuple<string, int, double>("USA", 2017, 32.21);
            //(string, int, double) avgRainfall = ("USA", 2017, 32.21);
            //SortedList<string, double> sortedList = new SortedList<string, double>();
            //SortedList<(string, int), double> avgRainfall = new SortedList<(string, int), double>();
            SortedList<(double, double, double), double> tupleList = new SortedList<(double, double, double), double>();

            for(double x = 0; x <= 4; x += 0.1)
            {
                x = Math.Round(x, 1);

                for(double y = -1; y <= 1; y += 0.1)
                {
                    y = Math.Round(y, 1);

                    for(double w = -2; w <= 0; w += 0.2)
                    {
                        w = Math.Round(w, 1);
                        double z = (4 * Math.Pow(y, 3)) + (2 * Math.Pow(x, 2)) - (8 * w) + 7;
                        z = Math.Round(z, 3);

                        tupleList[(w, x, y)] = z;
                    }
                }
            }
        }
    }
}