using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day02Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 4112
            int expectedResult = 4112;
            int actualResult = Day2Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
