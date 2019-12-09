using Pontemonti.AdventOfCode.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Utilities
{
    public class GeometryHelper
    {
        public static int CalculateManhattanDistance(Point point1, Point point2)
        {
            int xDistance = point2.X - point1.X;
            int yDistance = point2.Y - point1.Y;
            int result = Math.Abs(xDistance) + Math.Abs(yDistance);
            return result;
        }

        public static int CalculateManhattanDistanceForClosestIntersection(IEnumerable<WirePath> wire1Paths, IEnumerable<WirePath> wire2Paths)
        {
            Point startingPoint = new Point(0, 0);
            Point closestPoint = FindClosestIntersection(wire1Paths, wire2Paths);
            return CalculateManhattanDistance(startingPoint, closestPoint);
        }

        public static int CalculateManhattanDistanceForClosestIntersection(IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            Point startingPoint = new Point(0, 0);
            Point closestPoint = FindClosestIntersection(wire1Points, wire2Points);
            return CalculateManhattanDistance(startingPoint, closestPoint);
        }

        public static Point FindClosestIntersection(IEnumerable<WirePath> wire1Paths, IEnumerable<WirePath> wire2Paths)
        {
            Point startingPoint = new Point(0, 0);
            Point[] intersections = FindIntersections(wire1Paths, wire2Paths).ToArray();
            Point closestPoint = intersections.OrderBy(point => CalculateManhattanDistance(startingPoint, point)).First();
            return closestPoint;
        }

        public static Point FindClosestIntersection(IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            Point startingPoint = new Point(0, 0);
            Point[] intersections = FindIntersections(wire1Points, wire2Points).ToArray();
            Point closestPoint = intersections.OrderBy(point => CalculateManhattanDistance(startingPoint, point)).First();
            return closestPoint;
        }

        public static IEnumerable<Point> FindIntersections(IEnumerable<WirePath> wire1Paths, IEnumerable<WirePath> wire2Paths)
        {
            Console.WriteLine("Getting points for wire1...");
            Point[] wire1Points = WirePath.GetPoints(wire1Paths).ToArray();
            Console.WriteLine($"Found {wire1Points.Length} points for wire1.");
            Console.WriteLine("Getting points for wire2...");
            Point[] wire2Points = WirePath.GetPoints(wire2Paths).ToArray();
            Console.WriteLine($"Found {wire2Points.Length} points for wire2.");
            Console.WriteLine("Finding intersections...");
            Point[] intersections = FindIntersections(wire1Points, wire2Points).ToArray();
            Console.WriteLine($"Found {intersections.Length} intersections...");
            return intersections;
        }

        public static IEnumerable<Point> FindIntersections(IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            HashSet<Point> wire2PointsSet = new HashSet<Point>(wire2Points);
            foreach (Point point in wire1Points)
            {
                if (wire2PointsSet.Contains(point))
                {
                    yield return point;
                }
            }
        }
    }
}
