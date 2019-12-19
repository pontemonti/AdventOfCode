using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
    [DebuggerDisplay("X = {Position.X}; Y = {Position.Y}")]
    public class Asteroid
    {
        public Asteroid(Point position)
        {
            this.Position = position;
            this.Slopes = new HashSet<double>();
        }

        public int NumberOfVisibleAsteroids => this.Slopes.Count;
        public Point Position { get; }
        public HashSet<double> Slopes { get; }
    }
}
