using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day01Puzzle1Tests
    {
        [TestMethod]
        public void CalculateFuelRequirementsWithMass12ShouldReturn2()
        {
            /// For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
            this.TestCalculateFuelRequirement(mass: 12, expectedFuelRequirement: 2);
        }

        [TestMethod]
        public void CalculateFuelRequirementsWithMass14ShouldReturn2()
        {
            /// For a mass of 14, dividing by 3 and rounding down still yields 4, so the fuel required is also 2.
            this.TestCalculateFuelRequirement(mass: 14, expectedFuelRequirement: 2);
        }

        [TestMethod]
        public void CalculateFuelRequirementsWithMass1969ShouldReturn654()
        {
            /// For a mass of 1969, the fuel required is 654.
            this.TestCalculateFuelRequirement(mass: 1969, expectedFuelRequirement: 654);
        }

        [TestMethod]
        public void CalculateFuelRequirementsWithMass100756ShouldReturn33583()
        {
            /// For a mass of 100756, the fuel required is 33583.
            this.TestCalculateFuelRequirement(mass: 100756, expectedFuelRequirement: 33583);
        }

        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 3210097
            int expectedResult = 3210097;
            int actualResult = Day01Puzzle1.CalculateTotalFuelRequirements();
            Assert.AreEqual(expectedResult, actualResult);
        }

        private void TestCalculateFuelRequirement(int mass, int expectedFuelRequirement)
        {
            int actualFuelRequirement = Day01Puzzle1.CalculateFuelRequirements(mass);
            Assert.AreEqual(expectedFuelRequirement, actualFuelRequirement);
        }
    }
}
