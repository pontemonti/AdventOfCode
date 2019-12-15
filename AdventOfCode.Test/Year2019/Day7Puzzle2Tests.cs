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
    public class Day7Puzzle2Tests
    {
        [TestMethod]
        public void TestSolve()
        {
            // Correct answer is 79846026
            int expectedResult = 79846026;
            (long actualResult, _) = Day7Puzzle2.GetResult(InputHelper.ReadIntegerCommaList(Day7Puzzle1.input).ToArray());
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void TestMaxThrusterSignalIs139629729FromPhaseSettings98765()
        {
            /// * Max thruster signal 139629729 (from phase setting sequence 9,8,7,6,5):
            ///   3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,
            ///   27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5
            const string programString = "3,26,1001,26,-4,26,3,27,1002,27,2,27,1,27,26,27,4,27,1001,28,-1,28,1005,28,6,99,0,0,5";
            const int expectedOutputSignal = 139629729;
            this.TestGetResult(programString, expectedOutputSignal);
        }

        [TestMethod]
        public void TestMaxThrusterSignalIs18216FromPhaseSettings97856()
        {
            /// * Max thruster signal 18216 (from phase setting sequence 9,7,8,5,6):
            ///   3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,
            ///   -5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,
            ///   53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10
            const string programString = "3,52,1001,52,-5,52,3,53,1,52,56,54,1007,54,5,55,1005,55,26,1001,54,-5,54,1105,1,12,1,53,54,53,1008,54,0,55,1001,55,1,55,2,53,55,53,4,53,1001,56,-1,56,1005,56,6,99,0,0,0,0,10";
            const int expectedOutputSignal = 18216;
            this.TestGetResult(programString, expectedOutputSignal);
        }

        private void TestGetResult(string programString, int expectedOutputSignal)
        {
            int[] program = InputHelper.ReadIntegerCommaList(programString).ToArray();
            (long actualOutputSignal, int[] actualPhaseSettings) = Day7Puzzle2.GetResult(program);
            Assert.AreEqual(expectedOutputSignal, actualOutputSignal);
        }
    }
}
