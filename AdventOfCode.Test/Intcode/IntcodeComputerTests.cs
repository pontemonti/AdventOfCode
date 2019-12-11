using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Intcode;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Intcode
{
    [TestClass]
    public class IntcodeComputerTests
    {
        [TestMethod]
        public void Test1Plus1ShouldResultIn2()
        {
            // 1,0,0,0,99 becomes 2,0,0,0,99 (1 + 1 = 2)
            string input = "1,0,0,0,99";
            string expectedEndState = "2,0,0,0,99";
            this.TestIntcodeComputer(input, expectedEndState);
        }

        [TestMethod]
        public void Test3Times2ShouldResultIn6()
        {
            // 2,3,0,3,99 becomes 2,3,0,6,99 (3 * 2 = 6)
            string input = "2,3,0,3,99";
            string expectedEndState = "2,3,0,6,99";
            this.TestIntcodeComputer(input, expectedEndState);
        }

        [TestMethod]
        public void Test99Times99ShouldResultIn9801()
        {
            // 2,4,4,5,99,0 becomes 2,4,4,5,99,9801 (99 * 99 = 9801)
            string input = "2,4,4,5,99,0";
            string expectedEndState = "2,4,4,5,99,9801";
            this.TestIntcodeComputer(input, expectedEndState);
        }

        [TestMethod]
        public void TestAdditionAndMultiplication()
        {
            // 1,1,1,4,99,5,6,0,99 becomes 30,1,1,4,2,5,6,0,99
            string input = "1,1,1,4,99,5,6,0,99";
            string expectedEndState = "30,1,1,4,2,5,6,0,99";
            this.TestIntcodeComputer(input, expectedEndState);
        }

        [TestMethod]
        public void TestDay2Puzzle1ExampleProgram()
        {
            // 1,9,10,3,2,3,11,0,99,30,40,50 becomes 3500,9,10,70,2,3,11,0,99,30,40,50
            string input = "1,9,10,3,2,3,11,0,99,30,40,50";
            string expectedEndState = "3500,9,10,70,2,3,11,0,99,30,40,50";
            this.TestIntcodeComputer(input, expectedEndState);
        }

        [TestMethod]
        public void TestInputAndOutputOperations()
        {
            // The program 3,0,4,0,99 outputs whatever it gets as input, then halts.
            string operations = "3,0,4,0,99";
            int input = 12345;
            int[] inputIntegers = InputHelper.ReadIntegerCommaList(operations).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer(inputIntegers, input);
            intcodeComputer.Run();
            int output = intcodeComputer.Output;
            Assert.AreEqual(input, output);
        }

        private void TestIntcodeComputer(string input, string expectedEndState)
        {
            int[] inputIntegers = InputHelper.ReadIntegerCommaList(input).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer(inputIntegers);
            intcodeComputer.Run();
            int[] endState = intcodeComputer.GetCurrentState();
            string actualEndState = string.Join(",", endState);

            Assert.AreEqual(expectedEndState, actualEndState);
        }
    }
}
