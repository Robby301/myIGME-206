namespace FinalQ2
{
    // Class: Program
    // Author: Robert Gregory Disbrow
    // Purpose: This program makes an adjacency matrix and an adjacency list based on a weighted digraph given
    // Restrictions: None
    class Program
    {
        //Adjaceny Matrix
        static int[,] adjMatrix = new int[,]
        {
            //       A    B    C    D    E    F    G    H
            /*A*/  {-1,   1,   5,  -1,  -1,  -1,  -1,  -1},
            /*B*/  {-1,  -1,  -1,   1,  -1,   7,  -1,  -1},
            /*C*/  {-1,  -1,  -1,   0,   2,  -1,  -1,  -1},
            /*D*/  {-1,   1,   0,  -1,  -1,  -1,  -1,  -1},
            /*E*/  {-1,  -1,   2,  -1,  -1,  -1,   2,  -1},
            /*F*/  {-1,  -1,  -1,  -1,  -1,  -1,  -1,   4},
            /*G*/  {-1,  -1,  -1,  -1,   2,   1,  -1,  -1},
            /*H*/  {-1,  -1,  -1,  -1,  -1,  -1,  -1,  -1}
        };

        // Adjacency List (neighbors, weight)
        static (int, int)[][] listGraph = new (int, int)[][]
        {
            /* A (0) */ new (int, int)[] {(1, 1), (2, 5)},
            /* B (1) */ new (int, int)[] {(3, 1), (5, 7)},
            /* C (2) */ new (int, int)[] {(3, 0), (4, 2)},
            /* D (3) */ new (int, int)[] {(1, 1), (2, 0)},
            /* E (4) */ new (int, int)[] {(2, 2), (6, 2)},
            /* F (5) */ new (int, int)[] {(7, 4)},
            /* G (6) */ new (int, int)[] {(4, 2), (5,1)},
            /* H (7) */ null
        };
    }
}