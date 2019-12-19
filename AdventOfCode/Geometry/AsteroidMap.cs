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
                        double radians = Math.Atan2(target.Y - source.Y, target.X - source.X);
                        double normalAngle = radians * 180 / Math.PI;

                        // For giant laser to start at the top and rotate clockwise
                        // The easiest solution is to rotate the plane 90 degrees
                        // We can then sort descending; 90 degrees is at the top, one full lap ends at -270.
                        double angleFromTop = normalAngle - 90;
                        this.Asteroids[i].Slopes.Add(angleFromTop);
                    }
                }
            }
        }

        public List<Asteroid> CalculateVaporizationList(Asteroid sourceAsteroid)
        {
            List<Asteroid> asteroidsInUniverse = this.Asteroids
                .Except(new[] { sourceAsteroid })
                .Select(a => new Asteroid(a.Position))
                .ToList();
            Point source = sourceAsteroid.Position;
            sourceAsteroid = new Asteroid(source);
            for (int i = 0; i < asteroidsInUniverse.Count; i++)
            {
                Point target = asteroidsInUniverse[i].Position;
                double radians = Math.Atan2(source.Y - target.Y, target.X - source.X);
                double normalAngle = radians * 180 / Math.PI;
                double adjustedAngle = normalAngle;
                if (adjustedAngle > 90)
                {
                    // 90 - 180 degrees should become -270 to -180
                    adjustedAngle = -1 * (360 - adjustedAngle);
                }

                // For giant laser to start at the top and rotate clockwise
                // The easiest solution is to rotate the plane 90 degrees
                // We can then sort descending; 90 degrees is at the top, one full lap ends at -270.
                sourceAsteroid.Slopes.Add(adjustedAngle);
                asteroidsInUniverse[i].Slopes.Add(adjustedAngle);
            }

            List<Asteroid> vaporizedAsteroids = new List<Asteroid>();
            double[] sortedSlopes = sourceAsteroid.Slopes.OrderByDescending(n => n).ToArray();

            while (asteroidsInUniverse.Any())
            {
                foreach (double slope in sortedSlopes)
                {
                    Asteroid[] asteroidsWithSlope = asteroidsInUniverse.Where(a => a.Slopes.Contains(slope)).ToArray();

                    if (asteroidsWithSlope.Any())
                    {
                        // Vaporize the asteroid closest to the current asteroid
                        Asteroid asteroidToVaporize = asteroidsWithSlope.OrderBy(a => a.Position.CalculateDistanceTo(sourceAsteroid.Position)).First();
                        asteroidsInUniverse.Remove(asteroidToVaporize);
                        vaporizedAsteroids.Add(asteroidToVaporize);
                    }
                }
            }

            return vaporizedAsteroids;
        }

        public Asteroid FindAsteroidAtPositionInVaporizationList(Asteroid asteroid, int position)
        {
            Asteroid[] vaporizedAsteroids = this.CalculateVaporizationList(asteroid).ToArray();
            Asteroid vaporizedAsteroid = vaporizedAsteroids[position];
            return vaporizedAsteroid;
        }

        public Asteroid GetAsteroidWithMostVisibleAsteroids()
            => this.Asteroids.OrderByDescending(a => a.NumberOfVisibleAsteroids).First();
    }
}
