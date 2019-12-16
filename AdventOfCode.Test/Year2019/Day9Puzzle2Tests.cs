using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day9Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 75202
            long expectedResult = 75202;
            long actualResult = Day9Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
