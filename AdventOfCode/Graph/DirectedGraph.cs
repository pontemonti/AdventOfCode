using System;
using System.Collections.Generic;
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
    }
}
