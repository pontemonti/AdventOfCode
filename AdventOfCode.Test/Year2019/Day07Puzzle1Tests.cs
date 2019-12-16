using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Year2019;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Pontemonti.AdventOfCode.Test.Year2019
{
    [TestClass]
    public class Day07Puzzle1Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 75228
            int expectedResult = 75228;
            (long actualResult, _) = Day07Puzzle1.GetResult(InputHelper.ReadIntegerCommaList(Day07Puzzle1.input).ToArray());
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestMaxThrusterSignalIs43210FromPhaseSettings42310()
        {
            /// * Max thruster signal 43210 (from phase setting sequence 4,3,2,1,0):
            ///   3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0
            const string programString = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0";
            const int expectedOutputSignal = 43210;
            this.TestGetResult(programString, expectedOutputSignal);
        }

        [TestMethod]
        public void TestMaxThrusterSignalIs54321FromPhaseSettings01234()
        {
            /// * Max thruster signal 54321 (from phase setting sequence 0,1,2,3,4):
            ///   3,23,3,24,1002,24,10,24,1002,23,-1,23,
            ///   101,5,23,23,1,24,23,23,4,23,99,0,0
            const string programString = "3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0";
            const int expectedOutputSignal = 54321;
            this.TestGetResult(programString, expectedOutputSignal);
        }

        [TestMethod]
        public void TestMaxThrusterSignalIs65210FromPhaseSettings10432()
        {
            /// * Max thruster signal 65210 (from phase setting sequence 1,0,4,3,2):
            ///   3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,
            ///   1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0
            const string programString = "3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0";
            const int expectedOutputSignal = 65210;
            this.TestGetResult(programString, expectedOutputSignal);
        }

        private void TestGetResult(string programString, int expectedOutputSignal)
        {
            int[] program = InputHelper.ReadIntegerCommaList(programString).ToArray();
            (long actualOutputSignal, int[] actualPhaseSettings) = Day07Puzzle1.GetResult(program);
            Assert.AreEqual(expectedOutputSignal, actualOutputSignal);
        }
    }
}
