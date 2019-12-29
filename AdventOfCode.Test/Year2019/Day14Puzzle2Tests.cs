using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Chemistry;
using Pontemonti.AdventOfCode.Utilities;
using Pontemonti.AdventOfCode.Year2019;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day14Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 2144702
            const long expectedResult = 2144702;
            long actualResult = Day14Puzzle2.CalculateResult();
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// The 13312 ORE-per-FUEL example could produce 82892753 FUEL.
        /// </summary>
        [TestMethod]
        public void TestExample3CanProduce82892753Fuel()
        {
            const long expectedTargetChemicalAmount = 82892753;
            this.Test(Day14Puzzle1Tests.example3, expectedTargetChemicalAmount);
        }

        /// <summary>
        /// * The 180697 ORE-per-FUEL example could produce 5586022 FUEL.
        /// </summary>
        [TestMethod]
        public void TestExample4CanProduce5586022Fuel()
        {
            const long expectedTargetChemicalAmount = 5586022;
            this.Test(Day14Puzzle1Tests.example4, expectedTargetChemicalAmount);
        }

        /// <summary>
        /// * The 2210736 ORE-per-FUEL example could produce 460664 FUEL.
        /// </summary>
        [TestMethod]
        public void TestExample5CanProduce460664Fuel()
        {
            const long expectedTargetChemicalAmount = 460664;
            this.Test(Day14Puzzle1Tests.example5, expectedTargetChemicalAmount);
        }

        private void Test(string input, long expectedTargetChemicalAmount)
        {
            const string sourceChemicalName = Day14Puzzle1Tests.Ore;
            const long sourceChemicalAmount = 1000000000000;
            const string targetChemicalName = Day14Puzzle1Tests.Fuel;
            Reaction[] reactions = InputHelper.ReadReactionLines(input).ToArray();
            NanoFactory nanoFactory = new NanoFactory(reactions);
            Chemical sourceChemical = new Chemical(sourceChemicalName, sourceChemicalAmount);
            long actualTargetChemicalAmount = nanoFactory.FindNumberOfUnitsThatCanBeMadeFromChemical(sourceChemical, targetChemicalName);
            Assert.AreEqual(expectedTargetChemicalAmount, actualTargetChemicalAmount);
        }
    }
}
