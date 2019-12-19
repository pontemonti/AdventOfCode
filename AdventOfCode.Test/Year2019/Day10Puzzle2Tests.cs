using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Utilities;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day10Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 1309
            long expectedResult = 1309;
            long actualResult = Day10Puzzle2.CalculateResult(Day10Puzzle1.input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestVaporizedAsteroid1()
        {
            // The 1st asteroid to be vaporized is at 11,12.
            const int positionInVaporizationList = 0;
            const int expectedPositionX = 11;
            const int expectedPositionY = 12;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid2()
        {
            // The 2nd asteroid to be vaporized is at 12,1.
            const int positionInVaporizationList = 1;
            const int expectedPositionX = 12;
            const int expectedPositionY = 1;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid3()
        {
            // The 3rd asteroid to be vaporized is at 12,2.
            const int positionInVaporizationList = 2;
            const int expectedPositionX = 12;
            const int expectedPositionY = 2;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid10()
        {
            // The 10th asteroid to be vaporized is at 12,8.
            const int positionInVaporizationList = 9;
            const int expectedPositionX = 12;
            const int expectedPositionY = 8;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid20()
        {
            // The 20th asteroid to be vaporized is at 16,0.
            const int positionInVaporizationList = 19;
            const int expectedPositionX = 16;
            const int expectedPositionY = 0;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid50()
        {
            // The 50th asteroid to be vaporized is at 16,9.
            const int positionInVaporizationList = 49;
            const int expectedPositionX = 16;
            const int expectedPositionY = 9;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid100()
        {
            // The 100th asteroid to be vaporized is at 10,16.
            const int positionInVaporizationList = 99;
            const int expectedPositionX = 10;
            const int expectedPositionY = 16;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid199()
        {
            // The 199th asteroid to be vaporized is at 9,6.
            const int positionInVaporizationList = 198;
            const int expectedPositionX = 9;
            const int expectedPositionY = 6;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid200()
        {
            // The 200th asteroid to be vaporized is at 8,2.
            const int positionInVaporizationList = 199;
            const int expectedPositionX = 8;
            const int expectedPositionY = 2;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid201()
        {
            // The 201st asteroid to be vaporized is at 10,9.
            const int positionInVaporizationList = 200;
            const int expectedPositionX = 10;
            const int expectedPositionY = 9;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        [TestMethod]
        public void TestVaporizedAsteroid299()
        {
            // The 299th and final asteroid to be vaporized is at 11,1.
            const int positionInVaporizationList = 298;
            const int expectedPositionX = 11;
            const int expectedPositionY = 1;
            this.Test(Day10Puzzle1Tests.largestExampleMap, positionInVaporizationList, expectedPositionX, expectedPositionY);
        }

        private void Test(string map, int positionInVaporizationList, int expectedPositionX, int expectedPositionY)
        {
            AsteroidMap asteroidMap = InputHelper.ReadAsteroidMap(map);
            Asteroid asteroidWithMostVisibleAsteroids = asteroidMap.GetAsteroidWithMostVisibleAsteroids();
            Asteroid vaporizedAsteroid = asteroidMap.FindAsteroidAtPositionInVaporizationList(asteroidWithMostVisibleAsteroids, positionInVaporizationList);
            int actualPositionX = vaporizedAsteroid.Position.X;
            int actualPositionY = vaporizedAsteroid.Position.Y;
            Console.WriteLine($"Position found: {actualPositionX}, {actualPositionY}");
            Assert.AreEqual(expectedPositionX, actualPositionX, "X position doesn't match");
            Assert.AreEqual(expectedPositionY, actualPositionY, "Y position doesn't match");
        }
    }
}
