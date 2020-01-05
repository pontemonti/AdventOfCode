using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day16Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 41402171
            const string expectedResult = "41402171";
            string actualResult = Day16Puzzle2.CalculateResult(Day16Puzzle1.input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestExample1()
        {
            const string inputString = "03036732577212944063491565474664";
            const string expectedOutputString = "84462026";
            this.TestCalculateResult(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample2()
        {
            const string inputString = "02935109699940807407585447034323";
            const string expectedOutputString = "78725270";
            this.TestCalculateResult(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample3()
        {
            const string inputString = "03081770884921959731165446850517";
            const string expectedOutputString = "53553731";
            this.TestCalculateResult(inputString, expectedOutputString);
        }

        private void TestCalculateResult(string inputString, string expectedOutputString)
        {
            string actualOutputString = Day16Puzzle2.CalculateResult(inputString);
            Assert.AreEqual(expectedOutputString, actualOutputString);
        }
    }
}
