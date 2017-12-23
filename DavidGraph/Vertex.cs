using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidGraph
{
    class Vertex<T>
    {
        public T Item;
        public List<Edge<T>> Edges;
        public int Weight;
        public Dictionary<string, Stack<Vertex<T>>> Paths;

        public Vertex(T item, int weight = 0)
            :this(item, new List<Edge<T>>(), weight)
        {
            
        }
        public Vertex(T item, List<Edge<T>> edges, int weight = 0)
        {
            Item = item;
            Edges = edges;
            Weight = weight;
        }

        public bool AddEdge(Vertex<T> vertex, int weight)
        {
            foreach(Edge<T> edge in Edges)
            {
                if (edge.B == vertex)
                {
                    return false;
                }
            }
            Edge<T> newEdge = new Edge<T>(this, vertex, weight);
            Edges.Add(newEdge);
            vertex.Edges.Add(newEdge);
            return true;
        }

        public void RemoveEdges()
        {
            foreach (Edge<T> edge in Edges)
            {
                if(edge.A == this)
                {
                    edge.B.Edges.Remove(edge);
                }
                else
                {
                    edge.A.Edges.Remove(edge);
                }
            }
        }

        public void UpdatePaths()
        {
            Dictionary<Vertex<T>, int> distances = new Dictionary<Vertex<T>, int>();
            HashSet<Vertex<T>> visited;
            Edges.Sort((a, b) => (a.Weight.CompareTo(b.Weight)));

            
        }

    }
}
