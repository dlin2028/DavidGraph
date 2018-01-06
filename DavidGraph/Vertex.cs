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
        public Dictionary<string, Stack<Vertex<T>>> Paths;

        public bool Visited;
        public int Distance;
        public Vertex<T> Host;

        public Vertex(T item)
            : this(item, new List<Edge<T>>())
        {

        }
        public Vertex(T item, List<Edge<T>> edges)
        {
            Item = item;
            Edges = edges;
        }

        public bool AddEdge(Vertex<T> vertex, int weight)
        {
            foreach (Edge<T> edge in Edges)
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
                if (edge.A == this)
                {
                    edge.B.Edges.Remove(edge);
                }
                else
                {
                    edge.A.Edges.Remove(edge);
                }
            }
        }





    }
}
