﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day03Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 7388
            const int expectedResult = 7388;
            int actualResult = Day03Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
