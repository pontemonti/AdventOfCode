using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day11Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 1709
            const long expectedResult = 1709;
            long actualResult = Day11Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
