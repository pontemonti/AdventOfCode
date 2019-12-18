using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Geometry
{
    public class AsteroidMap
    {
        public AsteroidMap(Point[] asteroidPositions)
        {
            this.Asteroids = asteroidPositions.Select(p => new Asteroid(p)).ToArray();
            this.CalculateVisibleAsteroids();
        }

        public Asteroid[] Asteroids { get; }

        public void CalculateVisibleAsteroids()
        {
            for (int i = 0; i < this.Asteroids.Length; i++)
            {
                for (int j = 0; j < this.Asteroids.Length; j++)
                {
                    if (this.Asteroids[j] != this.Asteroids[i])
                    {
                        Point source = this.Asteroids[i].Position;
                        Point target = this.Asteroids[j].Position;
                        double slope = Math.Atan2(target.Y - source.Y, target.X - source.X);
                        this.Asteroids[i].Slopes.Add(slope);
                    }
                }
            }
        }

        public Asteroid GetAsteroidWithMostVisibleAsteroids()
            => this.Asteroids.OrderByDescending(a => a.NumberOfVisibleAsteroids).First();
    }
}
