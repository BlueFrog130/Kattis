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
            IEnumerable<int> g = Console.ReadLine().Split(" ").Select(x => int.Parse(x));
            int verticies = g.First();
            int edges = g.Last();
            List<Node> nodes = new List<Node>(Enumerable.Range(0, verticies).Select(x => new Node(x + 1)));
            for (int i = 0; i < edges; i++)
            {
                IEnumerable<int> e = Console.ReadLine().Split(" ").Select(x => int.Parse(x));
                nodes[e.First() - 1].Connect(nodes[e.Last() - 1]);
            }

            switch (Graph.HasEulerianPath(nodes))
            {
                case Path.NONE:
                    Console.WriteLine("no");
                    break;
                case Path.ANYWHERE:
                    Console.WriteLine("anywhere");
                    break;
                case Path.YES:
                    ValueTuple<Node, Node>? p = Graph.GetEulerianPath(nodes);
                    if (p == null)
                        Console.WriteLine("no");
                    else
                        Console.WriteLine($"{p.Value.Item1.Id} {p.Value.Item2.Id}");
                    break;
            }
        }
    }

    class Node
    {
        public List<Edge> Incomming { get; }
        public List<Edge> Outgoing { get; }
        public int? Id { get; }

        public Node()
        {
            Outgoing = new List<Edge>();
            Incomming = new List<Edge>();
        }

        public Node(int v) : this()
        {
            Id = v;
        }

        public void Connect(Node node)
        {
            Edge e = new Edge(node);
            Outgoing.Add(e);
            node.Incomming.Add(e);
        }
    }

    class Edge
    {
        public Node Node { get; }

        public Edge(Node node)
        {
            Node = node;
        }
    }

    enum Path
    {
        NONE,
        YES,
        ANYWHERE
    }

    static class Graph
    {
        public static Path HasEulerianPath(List<Node> graph)
        {
            if (!graph.SelectMany(e => e.Outgoing).Distinct().Any())
            {
                return Path.NONE;
            }
            int start = 0, end = 0;
            foreach (Node node in graph)
            {
                if (Math.Abs(node.Outgoing.Count - node.Incomming.Count) > 1) return Path.NONE;
                else if (node.Outgoing.Count - node.Incomming.Count == 1) start++;
                else if (node.Incomming.Count - node.Outgoing.Count == 1) end++;
            }
            if (end == 0 && start == 0) return Path.ANYWHERE;
            return (end == 1 && start == 1) ? Path.YES : Path.NONE;
        }

        public static Node StartNode(List<Node> graph)
        {
            int start = 0;
            for (int i = 0; i < graph.Count; i++)
            {
                if (graph[i].Outgoing.Count - graph[i].Incomming.Count == 1) return graph[i];
                if (graph[i].Outgoing.Count > 0) start = i;
            }
            return graph[start];
        }

        public static void DFS(Node node, List<Node> path)
        {
            while (node.Outgoing.Count > 0)
            {
                Edge next = node.Outgoing.Last();
                node.Outgoing.Remove(next);
                DFS(next.Node, path);
            }
            path.Add(node);
        }

        public static ValueTuple<Node, Node>? GetEulerianPath(List<Node> graph)
        {
            if (HasEulerianPath(graph) == Path.NONE) return null;
            int edges = graph.SelectMany(n => n.Outgoing).Distinct().Count();
            List<Node> path = new List<Node>();
            DFS(StartNode(graph), path);
            if (path.Count != edges + 1) return null;
            return new ValueTuple<Node, Node>(path.Last(), path.First());
        }
    }
}
