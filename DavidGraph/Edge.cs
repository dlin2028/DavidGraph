using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidGraph
{
    class Edge<T>
    {
        public Vertex<T> A;
        public Vertex<T> B;
        public int Weight = 0;

        public Edge(Vertex<T> a, Vertex<T> b, int weight = 0)
        {
            A = a;
            B = b;
            Weight = weight;
        }
        
        int CompareTo(Edge<T> b)
        {
            return Weight.CompareTo(b.Weight);
        }
    }
}
