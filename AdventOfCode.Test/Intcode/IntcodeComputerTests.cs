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
        private List<long> outputs;

        public IntcodeComputerTests()
        {
            this.outputs = new List<long>();
        }

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
            long output = intcodeComputer.Output;
            Assert.AreEqual(input, output);
        }

        [TestMethod]
        public void TestCopyProgramToOutput()
        {
            const string programString = "109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99";
            long[] program = InputHelper.ReadInt64CommaList(programString).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer("CopyProgram", program);
            intcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            intcodeComputer.Run();
            CollectionAssert.AreEqual(program, this.outputs);
        }

        [TestMethod]
        public void TestOuput16DigitNumber()
        {
            const string programString = "1102,34915192,34915192,7,4,7,99,0";
            long[] program = InputHelper.ReadInt64CommaList(programString).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer("CopyProgram", program);
            intcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            intcodeComputer.Run();
            long expectedOutput = 1219070632396864;
            Assert.AreEqual(expectedOutput, this.outputs[0]);
        }

        [TestMethod]
        public void TestOutputInt64Number()
        {
            const string programString = "104,1125899906842624,99";
            long[] program = InputHelper.ReadInt64CommaList(programString).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer("CopyProgram", program);
            intcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            intcodeComputer.Run();
            long expectedOutput = 1125899906842624;
            Assert.AreEqual(expectedOutput, this.outputs[0]);
        }

        private void TestIntcodeComputer(string input, string expectedEndState)
        {
            int[] inputIntegers = InputHelper.ReadIntegerCommaList(input).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer(inputIntegers);
            intcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
            intcodeComputer.Run();
            long[] endState = intcodeComputer.GetCurrentState();
            string actualEndState = string.Join(",", endState);

            Assert.AreEqual(expectedEndState, actualEndState);
        }

        private void IntcodeComputerOutputSent(object sender, long e) => this.outputs.Add(e);
    }
}
