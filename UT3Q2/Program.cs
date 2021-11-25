using System;
using System.Collections.Generic;
using System.Linq;

namespace UT3Q2
{
    public class Node : IComparable<Node>
    {
        public int vertex;

        public List<Edge> edges = new List<Edge>();

        public int minCostToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int vertex)
        {
            this.vertex = vertex;
            this.minCostToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minCostToStart.CompareTo(n.minCostToStart);
        }
    }

    public class Edge :IComparable<Edge>
    {
        public int cost;
        public Node connectedNode;

        public Edge(int cost, Node connectedNode)
        {
            this.cost = cost;
            this.connectedNode = connectedNode;
        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }

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

        static List<Node> colors = new List<Node>();

        static int[][] cGraph = new int[][]
        {
            new int[] { 1, 2 },
            new int[] { 3, 4 },
            new int[] { 3, 6 },
            new int[] { 1, 2 },
            new int[] { 7 },
            new int[] { 4 },
            new int[] { 5 },
            null
        };

        static int[][] costCGraph = new int[][]
        {
            new int[] { 1, 5 },
            new int[] { 1, 8 },
            new int[] { 0, 1 },
            new int[] { 1, 0 },
            new int[] { 6 },
            new int[] { 1 },
            new int[] { 1 },
            null
        };

        static string[] colorNodes = new string[]
        {
            "Red",         //0
            "Blue",        //1
            "Grey",        //2
            "Light-Blue",  //3
            "Yellow",      //4
            "Purple",      //5
            "Orange",      //6
            "Green"        //7
        };

        static void DFS(int v)
        {
            bool[] visited = new bool[cGraph.Length];

            DFSUtil(v, ref visited);
        }

        static void DFSUtil(int v, ref bool[] visited)
        {
            visited[v] = true;
            Console.Write(colorNodes[v] + " ");

            int[] thisStateList = cGraph[v];

            if (thisStateList != null)
            {
                foreach (int n in thisStateList)
                {
                    if (!visited[n])
                    {
                        DFSUtil(n, ref visited);
                    }
                }
            }
        }

        static public List<Node> GetShortestPathDijkstra()
        {
            DijkstraSearch();
            List<Node> shortestPath = new List<Node>();
            shortestPath.Add(colors[7]);
            BuildShortestPath(shortestPath, colors[7]);
            shortestPath.Reverse();
            return (shortestPath);
        }

        static public void BuildShortestPath(List<Node> list, Node node)
        {
            if(node.nearestToStart == null)
            {
                return;
            }

            list.Add(node.nearestToStart);
            BuildShortestPath(list, node.nearestToStart);
        }

        static public void DijkstraSearch()
        {
            Node start = colors[0];

            start.minCostToStart = 0;
            List<Node> priorityQueue = new List<Node>();

            priorityQueue.Add(start);

            do
            {
                priorityQueue.Sort();

                Node node = priorityQueue.First();
                priorityQueue.Remove(node);

                foreach (Edge cnn in node.edges)
                {
                    Node childNode = cnn.connectedNode;
                    if (childNode.visited)
                    {
                        continue;
                    }

                    if (childNode.minCostToStart == int.MaxValue ||
                        node.minCostToStart + cnn.cost < childNode.minCostToStart)
                    {
                        childNode.minCostToStart = node.minCostToStart + cnn.cost;
                        childNode.nearestToStart = node;
                        if (!priorityQueue.Contains(childNode))
                        {
                            priorityQueue.Add(childNode);
                        }
                    }
                }

                node.visited = true;

                if (node == colors[7])
                {
                    return;
                }
            } while (priorityQueue.Any());
        }

        static LinkedList<Node> nodesList = new LinkedList<Node>();

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

            DFS(rand.Next(0, 8));
            Console.WriteLine();

            Node node;
            int i = 0;

            for(i = 0; i < cGraph.Length; ++i)
            {
                node = new Node(i);
                colors.Add(node);
            }

            for(i = 0; i < (cGraph.Length - 1); ++i)
            {
                int[] thisState = cGraph[i];
                int[] thisCost = costCGraph[i];

                for(int costCount = 0; costCount < thisState.Length; ++costCount)
                {
                    colors[i].AddEdge(thisCost[costCount], colors[thisState[costCount]]);
                }

                colors[i].edges.Sort();
            }

            List<Node> shortestPath = GetShortestPathDijkstra();

            for(i = 0; i < colors.Count; i++)
            {
                nodesList.AddLast(colors[i]);
            }
        }
    }
}