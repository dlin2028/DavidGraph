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

        public Vertex(T item)
        {
            Item = item;
        }

        public bool AddEdge(Vertex<T> vertex)
        {
            foreach(Edge<T> edge in Edges)
            {
                if (edge.B == vertex)
                {
                    return false;
                }
            }
            Edge<T> newEdge = new Edge<T>(this, vertex);
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
    }
}
