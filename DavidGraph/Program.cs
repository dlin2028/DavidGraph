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
            Graph<int> graph;

            graph = new Graph<int>(new List<Vertex<int>>());

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
                    graph.AddPair(int.Parse(nodeA), int.Parse(nodeB));
                    Console.WriteLine("Done");
                }
                else if(input == "addvertex")
                {
                    Console.Write("Value: ");
                    int value = int.Parse(Console.ReadLine());
                    Console.Write("Weight: ");
                    graph.AddVertex(new Vertex<int>(value));
                    Console.WriteLine("Done");
                }
                else if(input == "removevertex")
                {
                    Console.Write("value: ");
                    int value = int.Parse(Console.ReadLine());
                    if(graph.RemoveVertex(new Vertex<int>(value)))
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
                    int value = int.Parse(Console.ReadLine());
                    Console.WriteLine(graph.HasVertex(new Vertex<int>(value)));
                        
                }
                else if(input == "depth")
                {
                    Console.Write("start node value: ");
                    int value = int.Parse(Console.ReadLine());

                    Console.WriteLine("       Output       ");
                    Console.WriteLine("--------------------");
                    graph.DepthFirstTrasversal(graph.Verticies[value]);
                }
                else if(input == "breadth")
                {
                    Console.WriteLine("start node value: ");
                    int value = int.Parse(Console.ReadLine());

                    Console.WriteLine("       Output       ");
                    Console.WriteLine("--------------------");
                    graph.BreadthFirstTrasversal(graph.Verticies[value]);
                }
                else if(input == "lazy")
                {
                    for (int i = 0; i < 5; i++)
                    {
                        graph.AddVertex(new Vertex<int>(i+1));
                    }
                    graph.AddPair(1, 2);
                    graph.AddPair(1, 3);
                    graph.AddPair(2, 4);
                    graph.AddPair(3, 4);
                    graph.AddPair(3, 5);
                }
                else
                {
                    Console.WriteLine("Available commands: addpair addvertex removevertex hasvertex depth breadth");
                }
            }
        }
    }
}
