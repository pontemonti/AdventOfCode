using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Utilities
{
    [TestClass]
    public class EnumerableHelperTests
    {
        [TestMethod]
        public void TestGetPermutationsFor1()
        {
            int[] input = new[] { 1 };
            const int expectedNumberOfPermutations = 1;
            this.TestGetPermutations(input, expectedNumberOfPermutations);
        }

        [TestMethod]
        public void TestGetPermutationsFor12()
        {
            int[] input = new[] { 1, 2 };
            const int expectedNumberOfPermutations = 2;
            this.TestGetPermutations(input, expectedNumberOfPermutations);
        }

        [TestMethod]
        public void TestGetPermutationsFor123()
        {
            int[] input = new[] { 1, 2, 3 };
            const int expectedNumberOfPermutations = 6;
            this.TestGetPermutations(input, expectedNumberOfPermutations);
        }

        [TestMethod]
        public void TestGetPermutationsFor1234()
        {
            int[] input = new[] { 1, 2, 3, 4 };
            const int expectedNumberOfPermutations = 24;
            this.TestGetPermutations(input, expectedNumberOfPermutations);
        }

        [TestMethod]
        public void TestGetPermutationsFor12345()
        {
            int[] input = new[] { 1, 2, 3, 4, 5 };
            const int expectedNumberOfPermutations = 120;
            this.TestGetPermutations(input, expectedNumberOfPermutations);
        }

        private void TestGetPermutations(int[] input, int expectedNumberOfPermutations)
        {
            IEnumerable<int>[] permutations = EnumerableHelper.GetPermutations(input).ToArray();
            int actualNumberOfPermutations = permutations.Length;
            Assert.AreEqual(expectedNumberOfPermutations, actualNumberOfPermutations);
        }
    }
}
