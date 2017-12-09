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

        public Edge(Vertex<T> a, Vertex<T> b)
        {
            A = a;
            B = b;
        }
    }
}
