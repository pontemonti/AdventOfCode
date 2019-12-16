using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day01Puzzle2Tests
    {
        [TestMethod]
        public void CalculateFuelRequirementsWithMass12ShouldReturn2()
        {
            /// * A module of mass 14 requires 2 fuel. This fuel requires no further fuel 
            ///   (2 divided by 3 and rounded down is 0, which would call for a negative fuel), 
            ///   so the total fuel required is still just 2.
            this.TestCalculateFuelRequirement(mass: 12, expectedFuelRequirement: 2);
        }

        [TestMethod]
        public void CalculateFuelRequirementsWithMass1969ShouldReturn966()
        {
            /// * At first, a module of mass 1969 requires 654 fuel. Then, this fuel requires 
            ///   216 more fuel (654 / 3 - 2). 216 then requires 70 more fuel, which requires 21 fuel, 
            ///   which requires 5 fuel, which requires no further fuel. So, the total fuel required 
            ///   for a module of mass 1969 is 654 + 216 + 70 + 21 + 5 = 966.
            this.TestCalculateFuelRequirement(mass: 1969, expectedFuelRequirement: 966);
        }

        [TestMethod]
        public void CalculateFuelRequirementsWithMass100756ShouldReturn50346()
        {
            /// * The fuel required by a module of mass 100756 and its fuel is:
            ///   33583 + 11192 + 3728 + 1240 + 411 + 135 + 43 + 12 + 2 = 50346.
            this.TestCalculateFuelRequirement(mass: 100756, expectedFuelRequirement: 50346);
        }


        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 4812287
            int expectedResult = 4812287;
            int actualResult = Day01Puzzle2.CalculateTotalFuelRequirements();
            Assert.AreEqual(expectedResult, actualResult);
        }

        private void TestCalculateFuelRequirement(int mass, int expectedFuelRequirement)
        {
            int actualFuelRequirement = Day01Puzzle2.CalculateFuelRequirements(mass);
            Assert.AreEqual(expectedFuelRequirement, actualFuelRequirement);
        }

    }
}
