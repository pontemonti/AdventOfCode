using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Geometry
{
    [TestClass]
    public class WirePathTests
    {
        [TestMethod]
        public void TestCalculateManhattanDistanceForClosestIntersectionExample1()
        {
            const string wire1PathInput = "R8,U5,L5,D3";
            const string wire2PathInput = "U7,R6,D4,L4";
            int expectedClosestDistance = 6;
            IEnumerable<WirePath> wire1Paths = InputHelper.ReadWirePathCommaList(wire1PathInput);
            IEnumerable<Point> wire1Points = WirePath.GetPoints(wire1Paths);
            IEnumerable<WirePath> wire2Paths = InputHelper.ReadWirePathCommaList(wire2PathInput);
            IEnumerable<Point> wire2Points = WirePath.GetPoints(wire2Paths);
            int actualClosestPoint = GeometryHelper.CalculateManhattanDistanceForClosestIntersection(wire1Points, wire2Points);
            Assert.AreEqual(expectedClosestDistance, actualClosestPoint);
        }

        [TestMethod]
        public void TestCalculateManhattanDistanceForClosestIntersectionExample2()
        {
            const string wire1PathInput = "R75, D30, R83, U83, L12, D49, R71, U7, L72";
            const string wire2PathInput = "U62, R66, U55, R34, D71, R55, D58, R83";
            int expectedClosestDistance = 159;
            IEnumerable<WirePath> wire1Paths = InputHelper.ReadWirePathCommaList(wire1PathInput);
            IEnumerable<Point> wire1Points = WirePath.GetPoints(wire1Paths);
            IEnumerable<WirePath> wire2Paths = InputHelper.ReadWirePathCommaList(wire2PathInput);
            IEnumerable<Point> wire2Points = WirePath.GetPoints(wire2Paths);
            int actualClosestPoint = GeometryHelper.CalculateManhattanDistanceForClosestIntersection(wire1Points, wire2Points);
            Assert.AreEqual(expectedClosestDistance, actualClosestPoint);
        }

        [TestMethod]
        public void TestCalculateManhattanDistanceForClosestIntersectionExample3()
        {
            const string wire1PathInput = "R98, U47, R26, D63, R33, U87, L62, D20, R33, U53, R51";
            const string wire2PathInput = "U98, R91, D20, R16, D67, R40, U7, R15, U6, R7";
            int expectedClosestDistance = 135;
            IEnumerable<WirePath> wire1Paths = InputHelper.ReadWirePathCommaList(wire1PathInput);
            IEnumerable<Point> wire1Points = WirePath.GetPoints(wire1Paths);
            IEnumerable<WirePath> wire2Paths = InputHelper.ReadWirePathCommaList(wire2PathInput);
            IEnumerable<Point> wire2Points = WirePath.GetPoints(wire2Paths);
            int actualClosestPoint = GeometryHelper.CalculateManhattanDistanceForClosestIntersection(wire1Points, wire2Points);
            Assert.AreEqual(expectedClosestDistance, actualClosestPoint);
        }

        [TestMethod]
        public void TestFindClosestIntersectionExample1()
        {
            const string wire1PathInput = "R8,U5,L5,D3";
            const string wire2PathInput = "U7,R6,D4,L4";
            Point expectedClosesPoint = new Point(3, 3);
            IEnumerable<WirePath> wire1Paths = InputHelper.ReadWirePathCommaList(wire1PathInput);
            IEnumerable<Point> wire1Points = WirePath.GetPoints(wire1Paths);
            IEnumerable<WirePath> wire2Paths = InputHelper.ReadWirePathCommaList(wire2PathInput);
            IEnumerable<Point> wire2Points = WirePath.GetPoints(wire2Paths);
            Point actualClosestPoint = GeometryHelper.FindClosestIntersection(wire1Points, wire2Points);
            Assert.AreEqual(expectedClosesPoint, actualClosestPoint);
        }

        [TestMethod]
        public void TestGetPointsWithR1ShouldReturnOnePoint()
        {
            const string wirePathString = "R1";
            Point expectedPosition = new Point(1, 0);
            WirePath wirePath = WirePath.Parse(wirePathString);
            Point[] positions = WirePath.GetPoints(new[] { wirePath }).ToArray();
            Assert.AreEqual(1, positions.Length);
            Assert.AreEqual(expectedPosition, positions[0]);
        }

        [TestMethod]
        public void TestGetPointsWithD2ShouldReturnTwoPoints()
        {
            const string wirePathString = "D2";
            Point expectedPoint1 = new Point(0, -1);
            Point expectedPoint2 = new Point(0, -2);
            WirePath wirePath = WirePath.Parse(wirePathString);
            Point[] points = WirePath.GetPoints(new[] { wirePath }).ToArray();
            Assert.AreEqual(2, points.Length);
            Assert.AreEqual(expectedPoint1, points[0]);
            Assert.AreEqual(expectedPoint2, points[1]);
        }

        [TestMethod]
        public void TestGetPointsWithL1AndU2ShouldReturnThreePoints()
        {
            const string wirePathString1 = "L1";
            const string wirePathString2 = "U2";
            Point expectedPoint1 = new Point(-1, 0);
            Point expectedPoint2 = new Point(-1, 1);
            Point expectedPoint3 = new Point(-1, 2);
            WirePath wirePath1 = WirePath.Parse(wirePathString1);
            WirePath wirePath2 = WirePath.Parse(wirePathString2);
            Point[] points = WirePath.GetPoints(new[] { wirePath1, wirePath2 }).ToArray();
            Assert.AreEqual(3, points.Length);
            Assert.AreEqual(expectedPoint1, points[0]);
            Assert.AreEqual(expectedPoint2, points[1]);
            Assert.AreEqual(expectedPoint3, points[2]);
        }

        [TestMethod]
        public void TestParseR75ShouldReturnWirePathWithDirectionRightAndDistance75()
        {
            const string wirePathString = "R75";
            const WireDirection expectedWireDirection = WireDirection.Right;
            const int expectedDistance = 75;
            this.TestParse(wirePathString, expectedWireDirection, expectedDistance);
        }

        [TestMethod]
        public void TestParseD30ShouldReturnWirePathWithDirectionDownAndDistance30()
        {
            const string wirePathString = "D30";
            const WireDirection expectedWireDirection = WireDirection.Down;
            const int expectedDistance = 30;
            this.TestParse(wirePathString, expectedWireDirection, expectedDistance);
        }

        [TestMethod]
        public void TestParseU8ShouldReturnWirePathWithDirectionUpAndDistance8()
        {
            const string wirePathString = "U8";
            const WireDirection expectedWireDirection = WireDirection.Up;
            const int expectedDistance = 8;
            this.TestParse(wirePathString, expectedWireDirection, expectedDistance);
        }

        [TestMethod]
        public void TestParseL12ShouldReturnWirePathWithDirectionLeftAndDistance12()
        {
            const string wirePathString = "L12";
            const WireDirection expectedWireDirection = WireDirection.Left;
            const int expectedDistance = 12;
            this.TestParse(wirePathString, expectedWireDirection, expectedDistance);
        }

        private void TestParse(string wirePathString, WireDirection expectedDirection, int expectedDistance)
        {
            WirePath wirePath = WirePath.Parse(wirePathString);
            Assert.AreEqual(expectedDirection, wirePath.WireDirection);
            Assert.AreEqual(expectedDistance, wirePath.Distance);
        }
    }
}
