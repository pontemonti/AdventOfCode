using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
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
