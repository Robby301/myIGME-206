using System;
using System.Collections.Generic;

namespace PE21
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: This class/program creates an adjacency matrix and list for a diagram that was given
    // Restrictions: None
    class Program
    {
        //Below is the code used to make the weighted adjacency matrix (-1 means no connection)
        static int[,] adjMatrix = new int[,]
        {
            //    A    B    C    D    E    F    G    H
            /*A*/{0,   2,  -1,  -1,  -1,  -1,  -1,  -1},
            /*B*/{-1, -1,   2,   3,  -1,  -1,  -1,  -1},
            /*C*/{-1,  2,  -1,  -1,  -1,  -1,  -1,  20},
            /*D*/{-1,  3,   5,  -1,   2,   4,  -1,  -1},
            /*E*/{-1, -1,  -1,  -1,  -1,   3,  -1,  -1},
            /*F*/{-1, -1,  -1,  -1,  -1,  -1,   1,  -1},
            /*G*/{-1, -1,  -1,  -1,   0,  -1,  -1,   2},
            /*H*/{-1, -1,  -1,  -1,  -1,  -1,  -1,  -1}
        };

        //Bellow creates a sorted list that will be used for the adjacency list
        static SortedList<(string, string), int> adjList = new SortedList<(string, string), int>();

        // Method: Main
        // Purpose: The main will be used to fill the sorted list with the weights of the adjacency list (-1
        //          indicates no connection)
        // Restrictions: None
        static void Main(string[] args)
        {
            //Weights for A
            adjList[("A", "A")] =  0;
            adjList[("A", "B")] =  2;
            adjList[("A", "C")] = -1;
            adjList[("A", "D")] = -1;
            adjList[("A", "E")] = -1;
            adjList[("A", "F")] = -1;
            adjList[("A", "G")] = -1;
            adjList[("A", "H")] = -1;

            //Weights for B
            adjList[("B", "A")] = -1;
            adjList[("B", "B")] = -1;
            adjList[("B", "C")] =  2;
            adjList[("B", "D")] =  3;
            adjList[("B", "E")] = -1;
            adjList[("B", "F")] = -1;
            adjList[("B", "G")] = -1;
            adjList[("B", "H")] = -1;

            //Weights for C
            adjList[("C", "A")] = -1;
            adjList[("C", "B")] =  2;
            adjList[("C", "C")] = -1;
            adjList[("C", "D")] = -1;
            adjList[("C", "E")] = -1;
            adjList[("C", "F")] = -1;
            adjList[("C", "G")] = -1;
            adjList[("C", "H")] = 20;

            //Weights for D
            adjList[("D", "A")] = -1;
            adjList[("D", "B")] =  3;
            adjList[("D", "C")] =  5;
            adjList[("D", "D")] = -1;
            adjList[("D", "E")] =  2;
            adjList[("D", "F")] =  4;
            adjList[("D", "G")] = -1;
            adjList[("D", "H")] = -1;

            //Weights for E
            adjList[("E", "A")] = -1;
            adjList[("E", "B")] = -1;
            adjList[("E", "C")] = -1;
            adjList[("E", "D")] = -1;
            adjList[("E", "E")] = -1;
            adjList[("E", "F")] =  3;
            adjList[("E", "G")] = -1;
            adjList[("E", "H")] = -1;

            //Weights for F
            adjList[("F", "A")] = -1;
            adjList[("F", "B")] = -1;
            adjList[("F", "C")] = -1;
            adjList[("F", "D")] = -1;
            adjList[("F", "E")] = -1;
            adjList[("F", "F")] = -1;
            adjList[("F", "G")] =  1;
            adjList[("F", "H")] = -1;

            //Weights for G
            adjList[("G", "A")] = -1;
            adjList[("G", "B")] = -1;
            adjList[("G", "C")] = -1;
            adjList[("G", "D")] = -1;
            adjList[("G", "E")] =  0;
            adjList[("G", "F")] = -1;
            adjList[("G", "G")] = -1;
            adjList[("G", "H")] =  2;

            //Weights for H
            adjList[("H", "A")] = -1;
            adjList[("H", "B")] = -1;
            adjList[("H", "C")] = -1;
            adjList[("H", "D")] = -1;
            adjList[("H", "E")] = -1;
            adjList[("H", "F")] = -1;
            adjList[("H", "G")] = -1;
            adjList[("H", "H")] = -1;
        }
    }
}