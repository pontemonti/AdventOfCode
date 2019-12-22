using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day13Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 15328
            const int expectedResult = 15328;
            int actualResult = Day13Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
