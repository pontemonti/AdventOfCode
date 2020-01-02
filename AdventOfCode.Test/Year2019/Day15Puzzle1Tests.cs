using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day15Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 262
            const int expectedResult = 262;
            long actualResult = Day15Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
