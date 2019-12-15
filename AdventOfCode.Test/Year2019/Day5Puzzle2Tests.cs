using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day5Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 9217546
            int expectedResult = 9217546;
            long actualResult = Day5Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
