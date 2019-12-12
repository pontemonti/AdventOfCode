using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Graph
{
    public class DirectedGraph<T>
        where T : notnull
    {
        private Dictionary<T, DirectedNode<T>> nodes;

        public DirectedGraph()
        {
            this.nodes = new Dictionary<T, DirectedNode<T>>();
        }

        public static DirectedGraph<T> CreateFromInput((T, T)[] inputArray)
        {
            DirectedGraph<T> directedGraph = new DirectedGraph<T>();
            foreach ((T to, T from) in inputArray)
            {
                directedGraph.AddNodes(to, from);
            }

            return directedGraph;
        }

        public void AddNodes(T to, T from)
        {
            if (!this.nodes.ContainsKey(from))
            {
                this.nodes.Add(from, new DirectedNode<T>(from));
            }

            if (!this.nodes.ContainsKey(to))
            {
                this.nodes.Add(to, new DirectedNode<T>(to));
            }

            DirectedNode<T> fromNode = this.nodes[from];
            DirectedNode<T> toNode = this.nodes[to];
            fromNode.AddLinkTo(toNode);
        }

        public int GetTotalNumberOfOrbits()
        {
            int totalNumberOfOrbits = 0;
            foreach (DirectedNode<T> node in this.nodes.Values)
            {
                totalNumberOfOrbits += node.NumberOfOrbits;
            }

            return totalNumberOfOrbits;
        }

        public int FindMinimumNumberOfOrbitalTransfers(T from, T to)
        {
            // We're starting from the node we're orbiting, hence the immediate LinksTo
            DirectedNode<T> fromNode = this.nodes[from].LinksTo;
            DirectedNode<T> toNode = this.nodes[to].LinksTo;

            Dictionary<T, DirectedNode<T>> fromNodes = this.GetNodeChain(fromNode);
            Dictionary<T, DirectedNode<T>> toNodes = this.GetNodeChain(toNode);

            // Find the "root" (first shared node) of the two nodes
            DirectedNode<T>[] commonNodes = Enumerable.Intersect(fromNodes.Values, toNodes.Values).ToArray();
            DirectedNode<T> commonNodeWithLargestOrbit = commonNodes.OrderByDescending(node => node.NumberOfOrbits).First();

            // Calculate distance to "root" from each node
            int distanceFromRoot = this.CalculateDistanceBetween(fromNode, commonNodeWithLargestOrbit);
            int distanceToRoot = this.CalculateDistanceBetween(toNode, commonNodeWithLargestOrbit);

            int totalDistance = distanceFromRoot + distanceToRoot;
            return totalDistance;
        }

        private int CalculateDistanceBetween(DirectedNode<T> fromNode, DirectedNode<T> targetNode)
        {
            int distance = 0;
            while(fromNode.LinksTo != null && fromNode != targetNode)
            {
                distance++;
                fromNode = fromNode.LinksTo;
            }

            return distance;
        }

        private Dictionary<T, DirectedNode<T>> GetNodeChain(DirectedNode<T> node)
        {
            Dictionary<T, DirectedNode<T>> nodesDictionary = new Dictionary<T, DirectedNode<T>>();
            while (node.LinksTo != null)
            {
                // Protect against circular references?
                if (nodesDictionary.ContainsKey(node.Value))
                {
                    break;
                }

                nodesDictionary.Add(node.Value, node);
                node = node.LinksTo;
            }

            return nodesDictionary;
        }
    }
}
