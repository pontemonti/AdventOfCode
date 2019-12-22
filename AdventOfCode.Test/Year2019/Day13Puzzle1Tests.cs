using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day13Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 306
            const int expectedResult = 306;
            int actualResult = Day13Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
