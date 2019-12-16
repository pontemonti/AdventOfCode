using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Intcode;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day09Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 4080871669
            long expectedResult = 4080871669;
            long actualResult = Day09Puzzle1.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
