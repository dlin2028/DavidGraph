using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidGraph
{
    class Graph<T>
    {
        List<Vertex<T>> Verticies;

        public Graph(List<Vertex<T>> initialNodes)
        {
            Verticies = initialNodes;
        }

        public bool AddPair(Vertex<T> a, Vertex<T> b)
        {
            try
            {
                a.AddEdge(b);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void AddVertex(Vertex<T> vertex)
        {
            Verticies.Add(vertex);
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if(Verticies.Contains(vertex))
            {
                vertex.RemoveEdges();
                Verticies.Remove(vertex);
                return true;
            }
            return false;
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            return Verticies.Contains(vertex);
        }

        public List<Vertex<T>> queue;
        public void DepthFirstTrasversal(Vertex<T> input)
        {
            queue = new List<Vertex<T>>();
            depthTrasversal(input);
        }
        private void depthTrasversal(Vertex<T> currentNode)
        {
            Console.WriteLine(currentNode.Item);
            foreach (Edge<T> edge in currentNode.Edges)
            {
                if(queue.Contains(edge.B))
                {
                    return;
                }
                queue.Add(edge.B);
                depthTrasversal(edge.B);
            }
        }

        public void BreadthFirstTrasversal(Vertex<T> input)
        {
            queue = new List<Vertex<T>>();
            queue.Add(input);
            while(queue.Count != 0)
            {
                foreach(Vertex<T> vertex in queue)
                {
                    Console.WriteLine(vertex.Item);
                    queue.Remove(vertex);
                    foreach (Edge<T> edge in input.Edges)
                    {
                        queue.Add(edge.B);
                    }
                }
            }
        }
    }
}
