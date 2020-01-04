using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Utilities;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day16Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 22122816
            const string expectedResult = "22122816";
            string actualResult = Day16Puzzle1.CalculateResult(Day16Puzzle1.input);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestExample1Phase1()
        {
            const string inputString = "12345678";
            const string expectedOutputString = "48226158";
            this.TestCalculatePhase(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample1Phase2()
        {
            const string inputString = "48226158";
            const string expectedOutputString = "34040438";
            this.TestCalculatePhase(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample1Phase3()
        {
            const string inputString = "34040438";
            const string expectedOutputString = "03415518";
            this.TestCalculatePhase(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample1Phase4()
        {
            const string inputString = "03415518";
            const string expectedOutputString = "01029498";
            this.TestCalculatePhase(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample2()
        {
            const string inputString = "80871224585914546619083218645595";
            const string expectedOutputString = "24176176";
            this.TestCalculateResult(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample3()
        {
            const string inputString = "19617804207202209144916044189917";
            const string expectedOutputString = "73745418";
            this.TestCalculateResult(inputString, expectedOutputString);
        }

        [TestMethod]
        public void TestExample4()
        {
            const string inputString = "69317163492948606335995924319873";
            const string expectedOutputString = "52432133";
            this.TestCalculateResult(inputString, expectedOutputString);
        }

        private void TestCalculatePhase(string inputString, string expectedOutputString)
        {
            int[] inputDigits = InputHelper.ReadDigitList(inputString).ToArray();
            int[] expectedOutputDigits = InputHelper.ReadDigitList(expectedOutputString).ToArray();
            int[] actualOutputDigits = Day16Puzzle1.CalculatePhase(inputDigits);
            string actualOutputString = string.Join(string.Empty, actualOutputDigits);
            CollectionAssert.AreEqual(expectedOutputDigits, actualOutputDigits, $"Expected: {expectedOutputString}; Actual: {actualOutputString}");
        }

        private void TestCalculateResult(string inputString, string expectedOutputString)
        {
            int[] inputDigits = InputHelper.ReadDigitList(inputString).ToArray();
            string actualOutputString = Day16Puzzle1.CalculateResult(inputString);
            Assert.AreEqual(expectedOutputString, actualOutputString);
        }
    }
}
