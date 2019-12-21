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
    public class Day12Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 318382803780324
            const long expectedResult = 318382803780324;
            long actualResult = Day12Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestExample1()
        {
            const int expectedNumberOfStepsToRepeatState = 2772;
            this.Test(Day12Puzzle1Tests.example1Input, expectedNumberOfStepsToRepeatState);
        }

        [TestMethod]
        public void TestExample2()
        {
            const long expectedNumberOfStepsToRepeatState = 4686774924;
            this.Test(Day12Puzzle1Tests.example2Input, expectedNumberOfStepsToRepeatState);
        }

        private void Test(string input, long expectedNumberOfStepsToRepeatState)
        {
            JupiterMoons jupiterMoons = InputHelper.ReadJupiterMoons(input);
            long actualNumberOfStepsToRepeatState = jupiterMoons.FindNumberOfStepsToRepeatState();
            Assert.AreEqual(expectedNumberOfStepsToRepeatState, actualNumberOfStepsToRepeatState);
        }
    }
}
