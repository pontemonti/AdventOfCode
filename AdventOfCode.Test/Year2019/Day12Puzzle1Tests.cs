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
    public class Day12Puzzle1Tests
    {
        private const string exampleInput = @"<x=-1, y=0, z=2>
<x=2, y=-10, z=-7>
<x=4, y=-8, z=8>
<x=3, y=5, z=-1>";

        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 9958
            const long expectedResult = 9958;
            long actualResult = Day12Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// After 0 steps:
        /// pos=<x=-1, y=  0, z= 2>, vel=<x= 0, y= 0, z= 0>
        /// pos=<x= 2, y=-10, z=-7>, vel=<x= 0, y= 0, z= 0>
        /// pos=<x= 4, y= -8, z= 8>, vel=<x= 0, y= 0, z= 0>
        /// pos=<x= 3, y=  5, z=-1>, vel=<x= 0, y= 0, z= 0>
        /// </summary>
        [TestMethod]
        public void TestExampleStep0()
        {
            Moon[] expectedMoonStates = new[]
            {
                new Moon(-1, 0, 2, 0, 0, 0),
                new Moon(2, -10, -7, 0, 0, 0),
                new Moon(4, -8, 8, 0, 0, 0),
                new Moon(3, 5, -1, 0, 0, 0)
            };
            this.TestExample(0, expectedMoonStates);
        }

        /// <summary>
        /// After 1 step:
        /// pos=<x= 2, y=-1, z= 1>, vel=<x= 3, y=-1, z=-1>
        /// pos=<x= 3, y=-7, z=-4>, vel=<x= 1, y= 3, z= 3>
        /// pos=<x= 1, y=-7, z= 5>, vel=<x=-3, y= 1, z=-3>
        /// pos=<x= 2, y= 2, z= 0>, vel=<x=-1, y=-3, z= 1>
        /// </summary>
        [TestMethod]
        public void TestExampleStep1()
        {
            Moon[] expectedMoonStates = new[]
            {
                new Moon(2, -1, 1, 3, -1, -1),
                new Moon(3, -7, -4, 1, 3, 3),
                new Moon(1, -7, 5, -3, 1, -3),
                new Moon(2, 2, 0, -1, -3, 1)
            };
            this.TestExample(1, expectedMoonStates);
        }

        /// <summary>
        /// After 2 steps:
        /// pos=<x= 5, y=-3, z=-1>, vel=<x= 3, y=-2, z=-2>
        /// pos=<x= 1, y=-2, z= 2>, vel=<x=-2, y= 5, z= 6>
        /// pos=<x= 1, y=-4, z=-1>, vel=<x= 0, y= 3, z=-6>
        /// pos=<x= 1, y=-4, z= 2>, vel=<x=-1, y=-6, z= 2>
        /// </summary>
        [TestMethod]
        public void TestExampleStep2()
        {
            Moon[] expectedMoonStates = new[]
            {
                new Moon(5, -3, -1, 3, -2, -2),
                new Moon(1, -2, 2, -2, 5, 6),
                new Moon(1, -4, -1, 0, 3, -6),
                new Moon(1, -4, 2, -1, -6, 2)
            };
            this.TestExample(2, expectedMoonStates);
        }

        /// <summary>
        /// After 3 steps:
        /// pos=<x= 5, y=-6, z=-1>, vel=<x= 0, y=-3, z= 0>
        /// pos=<x= 0, y= 0, z= 6>, vel=<x=-1, y= 2, z= 4>
        /// pos=<x= 2, y= 1, z=-5>, vel=<x= 1, y= 5, z=-4>
        /// pos=<x= 1, y=-8, z= 2>, vel=<x= 0, y=-4, z= 0>
        /// </summary>
        [TestMethod]
        public void TestExampleStep3()
        {
            Moon[] expectedMoonStates = new[]
            {
                new Moon(5, -6, -1, 0, -3, 0),
                new Moon(0, 0, 6, -1, 2, 4),
                new Moon(2, 1, -5, 1, 5, -4),
                new Moon(1, -8, 2, 0, -4, 0)
            };
            this.TestExample(3, expectedMoonStates);
        }

        /// <summary>
        /// After 4 steps:
        /// pos=<x= 2, y=-8, z= 0>, vel=<x=-3, y=-2, z= 1>
        /// pos=<x= 2, y= 1, z= 7>, vel=<x= 2, y= 1, z= 1>
        /// pos=<x= 2, y= 3, z=-6>, vel=<x= 0, y= 2, z=-1>
        /// pos=<x= 2, y=-9, z= 1>, vel=<x= 1, y=-1, z=-1>
        /// </summary>
        [TestMethod]
        public void TestExampleStep4()
        {
            Moon[] expectedMoonStates = new[]
            {
                new Moon(2, -8, 0, -3, -2, 1),
                new Moon(2, 1, 7, 2, 1, 1),
                new Moon(2, 3, -6, 0, 2, -1),
                new Moon(2, -9, 1, 1, -1, -1)
            };
            this.TestExample(4, expectedMoonStates);
        }

        private void TestExample(int numberOfSteps, Moon[] expectedMoonStates)
        {
            JupiterMoons jupiterMoons = InputHelper.ReadJupiterMoons(exampleInput);
            jupiterMoons.RunSteps(numberOfSteps);
            Moon[] actualMoonStates = jupiterMoons.Moons;
            for (int i = 0; i < actualMoonStates.Length; i++)
            {
                Console.WriteLine($"Moon {i + 1}: {actualMoonStates[i].ToString()}");
                Assert.AreEqual(expectedMoonStates[i].X, actualMoonStates[i].X, "X");
                Assert.AreEqual(expectedMoonStates[i].Y, actualMoonStates[i].Y, "Y");
                Assert.AreEqual(expectedMoonStates[i].Z, actualMoonStates[i].Z, "Z");
                Assert.AreEqual(expectedMoonStates[i].VelocityX, actualMoonStates[i].VelocityX, "VelocityX");
                Assert.AreEqual(expectedMoonStates[i].VelocityY, actualMoonStates[i].VelocityY, "VelocityY");
                Assert.AreEqual(expectedMoonStates[i].VelocityZ, actualMoonStates[i].VelocityZ, "VelocityZ");
            }
        }
    }
}
