using System;
using System.Collections.Generic;
using System.Linq;

namespace EulerianGraphs
{
    /// <summary>
    /// https://open.kattis.com/problems/eulerian
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<int> graph = Console.ReadLine().Split(" ").Select(x => int.Parse(x));
            Node[] nodes = new Node[graph.First()];
            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node();
            }
            int edges = graph.Last();
            for (int i = 0; i < edges; i++)
            {
                IEnumerable<int> edge = Console.ReadLine().Split(" ").Select(x => int.Parse(x));
                nodes[edge.First() - 1].Edges.Add(new Edge(nodes[edge.Last() - 1]));
            }
            IEnumerable<bool> t = nodes.Select(n => n.Traversable(edges));
        }
    }

    class Node
    {
        public List<Edge> Edges { get; }
        public Node()
        {
            Edges = new List<Edge>();
        }

        public bool Traversable(int totalEdges)
        {
            HashSet<Edge> visited = new HashSet<Edge>();
            Queue<Node> q = new Queue<Node>();

            q.Enqueue(this);

            while (q.Count > 0)
            {
                Node u = q.Dequeue();
                foreach (Edge e in u.Edges)
                {
                    if (!visited.Contains(e))
                    {
                        visited.Add(e);
                        q.Enqueue(e.To);
                    }
                }
            }

            return visited.Count == totalEdges;
        }
    }

    class Edge
    {
        public Node To { get; }

        public Edge(Node node)
        {
            To = node;
        }
    }
}
