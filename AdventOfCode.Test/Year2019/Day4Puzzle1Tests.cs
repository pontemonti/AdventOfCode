using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day4Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 1650
            const int expectedResult = 1650;
            int actualResult = Day4Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
