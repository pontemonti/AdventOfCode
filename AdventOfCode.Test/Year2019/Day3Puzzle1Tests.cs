using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day3Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 721
            const int expectedResult = 721;
            int actualResult = Day3Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
