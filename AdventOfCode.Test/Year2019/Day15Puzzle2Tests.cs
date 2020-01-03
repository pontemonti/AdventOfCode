using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day15Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 314
            const int expectedResult = 314;
            long actualResult = Day15Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
