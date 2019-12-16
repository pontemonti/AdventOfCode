using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
    public class AsteroidMap
    {
        public AsteroidMap(Point[] asteroidPositions)
        {
            this.AsteroidPositions = asteroidPositions;
        }

        public Point[] AsteroidPositions { get; }
    }
}
