using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Spaceship;
using Pontemonti.AdventOfCode.Utilities;
using Pontemonti.AdventOfCode.Year2019;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day17Puzzle1Tests
    {
        private const string exampleMapString = @"..#..........
..#..........
#######...###
#.#...#...#.#
#############
..#...#...#..
..#####...^..";

        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 4220
            const int expectedResult = 4220;
            int actualResult = Day17Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestExampleCalculateSumOfAlignmentParameters()
        {
            AsciiMap asciiMap = InputHelper.ReadAsciiMap(exampleMapString);
            const int expectedSumOfAlignmentParameters = 76;
            int actualSumOfAlignmentParamters = asciiMap.CalculateSumOfAlignmentParameters();
            Assert.AreEqual(expectedSumOfAlignmentParameters, actualSumOfAlignmentParamters);
        }

        [TestMethod]
        public void TestExampleFindIntersections()
        {
            AsciiMap asciiMap = InputHelper.ReadAsciiMap(exampleMapString);
            Point[] expectedIntersections = new[]
            {
                new Point(2, 2),
                new Point(2, 4),
                new Point(6, 4),
                new Point(10, 4)
            };
            string expectedIntersectionsString = string.Join("; ", expectedIntersections);
            Point[] actualIntersections = asciiMap.FindIntersections().ToArray();
            string actualIntersectionsString = string.Join("; ", actualIntersections);

            CollectionAssert.AreEquivalent(expectedIntersections, actualIntersections, $"Expected intersections: {expectedIntersectionsString}; Actual intersections; {actualIntersectionsString}");
        }
    }
}
