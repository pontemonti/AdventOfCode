using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Password
{
    [TestClass]
    public class FuelDepotPasswordFinderTests
    {
        [TestMethod]
        public void TestIsPassword111111Valid()
        {
            this.TestIsPasswordValid(password: 111111, expectedIsValid: true);
        }

        [TestMethod]
        public void TestIsPassword123789Valid()
        {
            this.TestIsPasswordValid(password: 123789, expectedIsValid: false);
        }

        [TestMethod]
        public void TestIsPassword223450Valid()
        {
            this.TestIsPasswordValid(password: 223450, expectedIsValid: false);
        }

        private void TestIsPasswordValid(int password, bool expectedIsValid)
        {
            FuelDepotPasswordFinder fuelDepotPasswordFinder = new FuelDepotPasswordFinder(6, 0, 999999);
            int[] validPasswords = fuelDepotPasswordFinder.FindAllValidPasswords().ToArray();
            bool actualIsValid = validPasswords.Contains(password);
            Assert.AreEqual(expectedIsValid, actualIsValid);
        }
    }
}
