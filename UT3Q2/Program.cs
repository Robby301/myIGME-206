using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UT3Q2
{
    class Program
    {
        //Below is the code used to make the weighted adjacency matrix (-1 means no connection)
        static int[,] adjMatrix = new int[,]
        {
            //       Red  Blue  Grey  LB   Y    P    O  Green
            /*Red*/  {-1,   1,   5,  -1,  -1,  -1,  -1,  -1},
            /*Blue*/ {-1,  -1,  -1,   1,   8,  -1,  -1,  -1},
            /*Grey*/ {-1,  -1,  -1,   0,  -1,  -1,   1,  -1},
            /*LB*/   {-1,   1,   0,  -1,  -1,  -1,  -1,  -1},
            /*Y*/    {-1,  -1,  -1,  -1,  -1,  -1,  -1,   6},
            /*P*/    {-1,  -1,  -1,  -1,   1,  -1,  -1,  -1},
            /*O*/    {-1,  -1,  -1,  -1,  -1,   1,  -1,  -1},
            /*Green*/{-1,  -1,  -1,  -1,  -1,  -1,  -1,  -1}
        };

        //Bellow creates a sorted list that will be used for the adjacency list
        static SortedList<(string, string), int> adjList = new SortedList<(string, string), int>();

        static string[][] lGraph = new string[][]
        {
            new string[] { "Blue", "Grey" },
            new string[] { "LightBlue", "Yellow" },
            new string[] { "LightBlue", "Orange" },
            new string[] { "Blue", "Grey" },
            new string[] { "Green" },
            new string[] { "Yellow" },
            new string[] { "Purple" },
            null
        };

        static void DFS(int v)
        {
            bool[] visited = new bool[lGraph.Length];

            DFSUtil(v, ref visited);
        }

        static void DFSUtil(int v, ref bool[] visited)
        {
            int count = -1;
            visited[v] = true;
            Console.Write(v + " ");

            string[] thisStateList = lGraph[v];

            if (thisStateList != null)
            {
                foreach (string n in thisStateList)
                {
                    count++;

                    if (!visited[count])
                    {
                        DFSUtil(count, ref visited);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //Weights for Red
            adjList[("Red", "Red")]             = -1;
            adjList[("Red", "Blue")]            = 1;
            adjList[("Red", "Grey")]            = 5;
            adjList[("Red", "LightBlue")]       = -1;
            adjList[("Red", "Yellow")]          = -1;
            adjList[("Red", "Purple")]          = -1;
            adjList[("Red", "Orange")]          = -1;
            adjList[("Red", "Green")]           = -1;

            //Weights for Blue
            adjList[("Blue", "Red")]            = -1;
            adjList[("Blue", "Blue")]           = -1;
            adjList[("Blue", "Grey")]           = -1;
            adjList[("Blue", "LightBlue")]      = 1;
            adjList[("Blue", "Yellow")]         = 8;
            adjList[("Blue", "Purple")]         = -1;
            adjList[("Blue", "Orange")]         = -1;
            adjList[("Blue", "Green")]          = -1;

            //Weights for Grey
            adjList[("Grey", "Red")]            = -1;
            adjList[("Grey", "Blue")]           = -1;
            adjList[("Grey", "Grey")]           = -1;
            adjList[("Grey", "LightBlue")]      = 0;
            adjList[("Grey", "Yellow")]         = -1;
            adjList[("Grey", "Purple")]         = -1;
            adjList[("Grey", "Orange")]         = 1;
            adjList[("Grey", "Green")]          = -1;

            //Weights for Light Blue
            adjList[("LightBlue", "Red")]       = -1;
            adjList[("LightBlue", "Blue")]      = 1;
            adjList[("LightBlue", "Grey")]      = 0;
            adjList[("LightBlue", "LightBlue")] = -1;
            adjList[("LightBlue", "Yellow")]    = -1;
            adjList[("LightBlue", "Purple")]    = -1;
            adjList[("LightBlue", "Orange")]    = -1;
            adjList[("LightBlue", "Green")]     = -1;

            //Weights for Yellow
            adjList[("Yellow", "Red")]          = -1;
            adjList[("Yellow", "Blue")]         = -1;
            adjList[("Yellow", "Grey")]         = -1;
            adjList[("Yellow", "LightBlue")]    = -1;
            adjList[("Yellow", "Yellow")]       = -1;
            adjList[("Yellow", "Purple")]       = -1;
            adjList[("Yellow", "Orange")]       = -1;
            adjList[("Yellow", "Green")]        = 6;

            //Weights for Purple
            adjList[("Purple", "Red")]          = -1;
            adjList[("Purple", "Blue")]         = -1;
            adjList[("Purple", "Grey")]         = -1;
            adjList[("Purple", "LightBlue")]    = -1;
            adjList[("Purple", "Yellow")]       = 1;
            adjList[("Purple", "Purple")]       = -1;
            adjList[("Purple", "Orange")]       = -1;
            adjList[("Purple", "Green")]        = -1;

            //Weights for Orange
            adjList[("Orange", "Red")]          = -1;
            adjList[("Orange", "Blue")]         = -1;
            adjList[("Orange", "Grey")]         = -1;
            adjList[("Orange", "LightBlue")]    = -1;
            adjList[("Orange", "Yellow")]       = -1;
            adjList[("Orange", "Purple")]       = 1;
            adjList[("Orange", "Orange")]       = -1;
            adjList[("Orange", "Green")]        = -1;

            //Weights for Green
            adjList[("Green", "Red")]           = -1;
            adjList[("Green", "Blue")]          = -1;
            adjList[("Green", "Grey")]          = -1;
            adjList[("Green", "LightBlue")]     = -1;
            adjList[("Green", "Yellow")]        = -1;
            adjList[("Green", "Purple")]        = -1;
            adjList[("Green", "Orange")]        = -1;
            adjList[("Green", "Green")]         = -1;

            Random rand = new Random();

            DFS(5);
            Console.WriteLine();
        }
    }
}