using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day10Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 267
            long expectedResult = 267;
            long actualResult = Day10Puzzle1.CalculateResult(Day10Puzzle1.input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestBestResultIs8()
        {
            const string map = @".#..#
.....
#####
....#
...##";
            const int expectedPositionX = 3;
            const int expectedPositionY = 4;
            const int expectedBestResult = 8;
            this.Test(map, expectedPositionX, expectedPositionY, expectedBestResult);
        }

        [TestMethod]
        public void TestBestResultIs33()
        {
            const string map = @"......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####";
            const int expectedPositionX = 5;
            const int expectedPositionY = 8;
            const int expectedBestResult = 33;
            this.Test(map, expectedPositionX, expectedPositionY, expectedBestResult);
        }

        [TestMethod]
        public void TestBestResultIs35()
        {
            const string map = @"#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###.";
            const int expectedPositionX = 1;
            const int expectedPositionY = 2;
            const int expectedBestResult = 35;
            this.Test(map, expectedPositionX, expectedPositionY, expectedBestResult);
        }

        [TestMethod]
        public void TestBestResultIs41()
        {
            const string map = @".#..#..###
####.###.#
....###.#.
..###.##.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#..";
            const int expectedPositionX = 6;
            const int expectedPositionY = 3;
            const int expectedBestResult = 41;
            this.Test(map, expectedPositionX, expectedPositionY, expectedBestResult);
        }

        [TestMethod]
        public void TestBestResultIs210()
        {
            const string map = @".#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##";
            const int expectedPositionX = 11;
            const int expectedPositionY = 13;
            const int expectedBestResult = 210;
            this.Test(map, expectedPositionX, expectedPositionY, expectedBestResult);
        }

        private void Test(string map, int expectedPositionX, int expectedPositionY, int expectedBestResult)
        {
            Asteroid bestAsteroid = Day10Puzzle1.FindBestAsteroid(map);
            int actualPositionX = bestAsteroid.Position.X;
            int actualPositionY = bestAsteroid.Position.Y;
            Console.WriteLine($"Position found: {actualPositionX}, {actualPositionY}");
            Assert.AreEqual(expectedPositionX, actualPositionX, "X position doesn't match");
            Assert.AreEqual(expectedPositionY, actualPositionY, "Y position doesn't match");
            int actualBestResult = Day10Puzzle1.CalculateResult(map);
            Assert.AreEqual(expectedBestResult, actualBestResult, "Number of visible asteroids don't match");
        }
    }
}
