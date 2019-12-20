using Pontemonti.AdventOfCode.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Utilities
{
    public class GeometryHelper
    {
        public static System.Drawing.Rectangle CalculateBounds(IEnumerable<Point> points)
        {
            int minX = 0;
            int maxX = 0;
            int minY = 0;
            int maxY = 0;
            foreach (Point point in points)
            {
                if (point.X < minX)
                {
                    minX = point.X;
                }

                if (point.X > maxX)
                {
                    maxX = point.X;
                }

                if (point.Y < minY)
                {
                    minY = point.Y;
                }

                if (point.Y > maxY)
                {
                    maxY = point.Y;
                }
            }

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(minX, maxY, maxX - minX, maxY - minY);
            return rectangle;
        }

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
            Point closestPoint = FindClosestIntersectionByManhattanDistance(wire1Paths, wire2Paths);
            return CalculateManhattanDistance(startingPoint, closestPoint);
        }

        public static int CalculateManhattanDistanceForClosestIntersection(IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            Point startingPoint = new Point(0, 0);
            Point closestPoint = FindClosestIntersectionByManhattanDistance(wire1Points, wire2Points);
            return CalculateManhattanDistance(startingPoint, closestPoint);
        }

        public static int CalculateStepsToClosestIntersection(IEnumerable<WirePath> wire1Paths, IEnumerable<WirePath> wire2Paths)
        {
            Point[] wire1Points = WirePath.GetPoints(wire1Paths).ToArray();
            Point[] wire2Points = WirePath.GetPoints(wire2Paths).ToArray();
            return CalculateStepsToClosestIntersection(wire1Points, wire2Points);
        }

        public static int CalculateStepsToClosestIntersection(IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            Point closestPoint = FindClosestIntersectionBySteps(wire1Points, wire2Points);
            return CalculateTotalStepsToPoint(closestPoint, wire1Points, wire2Points);
        }

        public static int CalculateStepsToPoint(Point pointToFind, IEnumerable<Point> points)
        {
            int steps = 0;
            foreach (Point point in points)
            {
                steps++;
                if (point.Equals(pointToFind))
                {
                    return steps;
                }
            }

            throw new InvalidOperationException();
        }

        public static int CalculateTotalStepsToPoint(Point pointToFind, IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            int wire1Steps = CalculateStepsToPoint(pointToFind, wire1Points);
            int wire2Steps = CalculateStepsToPoint(pointToFind, wire2Points);
            int totalSteps = wire1Steps + wire2Steps;
            return totalSteps;
        }

        public static Point FindClosestIntersectionByManhattanDistance(IEnumerable<WirePath> wire1Paths, IEnumerable<WirePath> wire2Paths)
        {
            Point startingPoint = new Point(0, 0);
            Point[] intersections = FindIntersections(wire1Paths, wire2Paths).ToArray();
            Point closestPoint = intersections.OrderBy(point => CalculateManhattanDistance(startingPoint, point)).First();
            return closestPoint;
        }

        public static Point FindClosestIntersectionByManhattanDistance(IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            Point startingPoint = new Point(0, 0);
            Point[] intersections = FindIntersections(wire1Points, wire2Points).ToArray();
            Point closestPoint = intersections.OrderBy(point => CalculateManhattanDistance(startingPoint, point)).First();
            return closestPoint;
        }

        public static Point FindClosestIntersectionBySteps(IEnumerable<WirePath> wire1Paths, IEnumerable<WirePath> wire2Paths)
        {
            Point[] intersections = FindIntersections(wire1Paths, wire2Paths).ToArray();
            Point[] wire1Points = WirePath.GetPoints(wire1Paths).ToArray();
            Point[] wire2Points = WirePath.GetPoints(wire2Paths).ToArray();
            Point closestPoint = intersections.OrderBy(point => CalculateTotalStepsToPoint(point, wire1Points, wire2Points)).First();
            return closestPoint;
        }

        public static Point FindClosestIntersectionBySteps(IEnumerable<Point> wire1Points, IEnumerable<Point> wire2Points)
        {
            Point[] intersections = FindIntersections(wire1Points, wire2Points).ToArray();
            Point closestPoint = intersections.OrderBy(point => CalculateTotalStepsToPoint(point, wire1Points, wire2Points)).First();
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
