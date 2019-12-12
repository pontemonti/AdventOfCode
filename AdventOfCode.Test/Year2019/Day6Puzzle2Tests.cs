using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day6Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 349
            int expectedResult = 349;
            int actualResult = Day6Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
