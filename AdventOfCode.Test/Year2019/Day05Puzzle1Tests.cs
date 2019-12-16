using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day05Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 6761139
            int expectedResult = 6761139;
            long actualResult = Day05Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
