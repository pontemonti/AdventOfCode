using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day02Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 6327510
            int expectedResult = 6327510;
            long actualResult = Day02Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
