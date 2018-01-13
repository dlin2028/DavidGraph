using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph;

            graph = new Graph<string>(new List<Vertex<string>>());

            while(true)
            {
                Console.Write("Operation: ");
                string input = Console.ReadLine().ToLower();


                if(input == "addpair")
                {
                    Console.Write("Node A: ");
                    string nodeA = Console.ReadLine();
                    Console.Write("Node B: ");
                    string nodeB = Console.ReadLine();
                    Console.Write("Weight: ");
                    string weight = Console.ReadLine();
                    graph.AddPair(nodeA, nodeB, int.Parse(weight));
                    Console.WriteLine("Done");
                }
                else if (input == "removepair")
                {
                    Console.Write("Node A: ");
                    string nodeA = Console.ReadLine();
                    Console.Write("Node B: ");
                    string nodeB = Console.ReadLine();
                    graph.RemoveEdge(nodeA, nodeB);
                    Console.WriteLine("Done");
                }
                else if(input == "updatepair")
                {
                    Console.Write("Node A: ");
                    string nodeA = Console.ReadLine();
                    Console.Write("Node B: ");
                    string nodeB = Console.ReadLine();
                    Console.Write("Weight: ");
                    string weight = Console.ReadLine();
                    graph.RemoveEdge(nodeA, nodeB);
                    graph.AddPair(nodeA, nodeB, int.Parse(weight));
                }
                else if(input == "addvertex")
                {
                    Console.Write("Value: ");
                    string value = Console.ReadLine();
                    graph.AddVertex(new Vertex<string>(value));
                    Console.WriteLine("Done");
                }
                else if(input == "removevertex")
                {
                    Console.Write("value: ");
                    string value = Console.ReadLine();
                    if (graph.RemoveVertex(new Vertex<string>(value)))
                    {
                        Console.WriteLine("Done");
                    }
                    else
                    {
                        Console.WriteLine("Vertex not found");
                    }
                }
                else if(input == "hasvertex")
                {
                    Console.Write("value: ");
                    string value = Console.ReadLine();
                    Console.WriteLine(graph.HasVertex(new Vertex<string>(value)));
                        
                }
                else if(input == "depth")
                {
                    Console.Write("start node value: ");
                    string value = Console.ReadLine();

                    Console.WriteLine("       Output       ");
                    Console.WriteLine("--------------------");
                    graph.DepthFirstTrasversal(graph.Verticies[value]);
                }
                else if(input == "breadth")
                {
                    Console.WriteLine("start node value: ");
                    string value = Console.ReadLine();

                    Console.WriteLine("       Output       ");
                    Console.WriteLine("--------------------");
                    graph.BreadthFirstTrasversal(graph.Verticies[value]);
                }
                else if(input == "lazy")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        graph.AddVertex(new Vertex<string>((i+1).ToString()));
                    }
                    graph.AddPair("1", "2", 3);
                    graph.AddPair("2", "3", 1);
                    graph.AddPair("1", "4", 1);
                    graph.AddPair("2", "4", 1);
                    graph.AddPair("4", "3", 5);
                    graph.AddPair("2", "5", 5);
                }
                else if(input == "path")
                {
                    Console.WriteLine("start node value: ");
                    string start = Console.ReadLine();
                    Console.WriteLine("end node value: ");
                    string end = Console.ReadLine();

                    Stack<string> stack = graph.GetPathTo(start,end);

                    Console.WriteLine("       Output       ");
                    Console.WriteLine("--------------------");
                    Console.Write("Distnce: ");
                    Console.WriteLine(graph.Verticies[end].Distance);

                    while (stack.Count > 0)
                    {
                        Console.WriteLine(stack.Pop());
                    }


                }
                else
                {
                    Console.WriteLine("Available commands: addpair addvertex removevertex hasvertex depth breadth");
                }
            }
        }
    }
}
