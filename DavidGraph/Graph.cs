using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DavidGraph
{
    class Graph<T>
    {
        public Dictionary<T, Vertex<T>> Verticies;

        private List<Vertex<T>> verticies;

        public Graph(List<Vertex<T>> initialNodes)
        {
            verticies = initialNodes;
            Verticies = new Dictionary<T, Vertex<T>>();

            foreach (Vertex<T> vertex in verticies)
            {
                Verticies.Add(vertex.Item, vertex);
            }
        }

        public bool AddPair(T a, T b, int weight)
        {
            return AddPair(Verticies[a], Verticies[b], weight);
        }
        public bool AddPair(Vertex<T> a, Vertex<T> b, int weight)
        {
            try
            {
                a.AddEdge(b, weight);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void AddVertex(Vertex<T> vertex)
        {
            verticies.Add(vertex);
            Verticies.Add(vertex.Item, vertex);
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (verticies.Contains(vertex))
            {
                vertex.RemoveEdges();
                verticies.Remove(vertex);
                return true;
            }
            return false;
        }

        public void RemoveEdge(T a, T b)
        {
            Vertex<T> vertexA = Verticies[a];
            Vertex<T> vertexB = Verticies[b];

            for (int i = 0; i < vertexA.Edges.Count; i++)
            {
                if(vertexA.Edges[i].A == vertexA && vertexA.Edges[i].B == vertexB)
                {
                    vertexA.Edges.RemoveAt(i);
                    break;
                }
            }
            for (int i = 0; i < vertexB.Edges.Count; i++)
            {
                if (vertexB.Edges[i].A == vertexA && vertexB.Edges[i].B == vertexB)
                {
                    vertexB.Edges.RemoveAt(i);
                    break;
                }
            }
        }
        public void RemoveEdge(Edge<T> edge)
        {
            foreach (Vertex<T> vertex in verticies)
            {
                if (vertex.Edges.Contains(edge))
                {
                    vertex.Edges.Remove(edge);
                }
            }
        }

        public bool HasVertex(Vertex<T> vertex)
        {
            return verticies.Contains(vertex);
        }


        Queue<Vertex<T>> queue;
        List<Vertex<T>> visited;
        public void BreadthFirstTrasversal(Vertex<T> input)
        {
            queue = new Queue<Vertex<T>>();
            visited = new List<Vertex<T>>();
            queue.Enqueue(input);
            visited.Add(input);
            Console.WriteLine(input.Item);

            while (queue.Count > 0)
            {
                Vertex<T> currentNode = queue.Dequeue();
                foreach (Edge<T> edge in currentNode.Edges)
                {
                    if (!visited.Contains(edge.B))
                    {
                        Console.WriteLine(edge.B.Item);
                        queue.Enqueue(edge.B);
                        visited.Add(edge.B);
                    }
                }
            }
        }
        Stack<Vertex<T>> stack;
        public void DepthFirstTrasversal(Vertex<T> input)
        {
            stack = new Stack<Vertex<T>>();
            stack.Push(input);
            depthTrasversal(input);
        }
        private void depthTrasversal(Vertex<T> currentNode)
        {
            Console.WriteLine(currentNode.Item);
            if (currentNode.Edges.Count == 0)
            {
                stack.Pop();
            }
            foreach (Edge<T> edge in currentNode.Edges)
            {
                if (!stack.Contains(edge.B))
                {
                    stack.Push(edge.B);
                    depthTrasversal(edge.B);
                }
            }
        }


        public Stack<T> GetPathTo(T startKey, T endKey)
        {
            Stack<Vertex<T>> temp =  GetPathTo(Verticies[startKey], Verticies[endKey]);
            Stack<T> output = new Stack<T>();
            while(temp.Count > 0)
            {
                output.Push(temp.Pop().Item);
            }
            return output;
        }
        public Stack<Vertex<T>> GetPathTo(Vertex<T> start, Vertex<T> end)
        {
            UpdatePaths(start);
            return GetPath(end);
        }

        public void UpdatePaths(Vertex<T> start)
        {
            foreach (Vertex<T> v in verticies)
            {
                v.Distance = int.MaxValue;
                v.Host = null;
                v.Visited = false;
            }

            Queue<Vertex<T>> que = new Queue<Vertex<T>>();
            que.Enqueue(start);
            start.Distance = 0;

            while (que.Count != 0)
            {
                Vertex<T> currentNode = que.Dequeue();
                currentNode.Visited = true;

                foreach (Edge<T> edge in currentNode.Edges)
                {
                    Vertex<T> friend = edge.B;
                    if(edge.B == currentNode)
                    {
                        continue;
                    }

                    int newDistance = currentNode.Distance + edge.Weight;
                    if (!friend.Visited)
                    {
                        friend.Distance = newDistance;
                        friend.Host = currentNode;
                        friend.Visited = true;
                        que.Enqueue(friend);
                    }
                    else if (friend.Distance > newDistance && friend.Visited)
                    {
                        friend.Distance = newDistance;
                        friend.Host = currentNode;
                        que.Enqueue(friend);
                    }
                }
            }
        }
        
        public Stack<Vertex<T>> GetPath(T key)
        {
            return GetPath(Verticies[key]);
        }
        public Stack<Vertex<T>> GetPath(Vertex<T> vertex)
        {
            Stack<Vertex<T>> stack1 = new Stack<Vertex<T>>();
            Stack<Vertex<T>> stack2 = new Stack<Vertex<T>>();
            stack1.Push(vertex);
            while (vertex.Host != null)
            {
                stack1.Push(vertex.Host);
                vertex = vertex.Host;
            }
            while(stack1.Count > 0)
            {
                stack2.Push(stack1.Pop());
            }
            return stack2;
        }
    }
}
