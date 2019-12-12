using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day6Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 249308
            int expectedResult = 249308;
            int actualResult = Day6Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
