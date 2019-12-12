using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Graph
{
    public class DirectedNode<T>
        where T : notnull
    {
        private int? orbits;

        public DirectedNode(T value)
        {
            this.Value = value;
        }

        public DirectedNode<T>? LinksTo { get; private set; }
        public int NumberOfOrbits
        {
            get
            {
                if (!this.orbits.HasValue)
                {
                    this.orbits = this.CountOrbits();
                }

                return this.orbits.Value;
            }
        }
        public T Value { get; }

        public void AddLinkTo(DirectedNode<T> toNode) => this.LinksTo = toNode;

        private int CountOrbits()
        {
            int orbits = 0;
            DirectedNode<T> node = this;
            while (node.LinksTo != null)
            {
                orbits++;
                node = node.LinksTo;
            }

            return orbits;
        }
    }
}
