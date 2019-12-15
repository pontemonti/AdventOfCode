using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pontemonti.AdventOfCode.Spaceship;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Test.Spaceship
{
    [TestClass]
    public class AmplifierSeriesTests
    {
        [TestMethod]
        public void TestOutputSignalShouldBe42310()
        {
            /// * Max thruster signal 43210 (from phase setting sequence 4,3,2,1,0):
            ///   3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0
            const string programString = "3,15,3,16,1002,16,10,16,1,16,15,15,4,15,99,0,0";
            const string phaseSettingsString = "4,3,2,1,0";
            const int expectedOutputSignal = 43210;
            this.TestAmplifierSeries(programString, phaseSettingsString, expectedOutputSignal);
        }

        [TestMethod]
        public void TestOutputSignalShouldBe54321()
        {
            /// * Max thruster signal 54321 (from phase setting sequence 0,1,2,3,4):
            ///   3,23,3,24,1002,24,10,24,1002,23,-1,23,
            ///   101,5,23,23,1,24,23,23,4,23,99,0,0
            const string programString = "3,23,3,24,1002,24,10,24,1002,23,-1,23,101,5,23,23,1,24,23,23,4,23,99,0,0";
            const string phaseSettingsString = "0,1,2,3,4";
            const int expectedOutputSignal = 54321;
            this.TestAmplifierSeries(programString, phaseSettingsString, expectedOutputSignal);
        }

        [TestMethod]
        public void TestOutputSignalShouldBe65210()
        {
            /// * Max thruster signal 65210 (from phase setting sequence 1,0,4,3,2):
            ///   3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,
            ///   1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0
            const string programString = "3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0";
            const string phaseSettingsString = "1,0,4,3,2";
            const int expectedOutputSignal = 65210;
            this.TestAmplifierSeries(programString, phaseSettingsString, expectedOutputSignal);
        }

        public void TestAmplifierSeries(string programString, string phaseSettingsString, int expectedOutputSignal)
        {
            int[] program = InputHelper.ReadIntegerCommaList(programString).ToArray();
            int[] phaseSettings = InputHelper.ReadIntegerCommaList(phaseSettingsString).ToArray();
            AmplifierSeries amplifierSeries = new AmplifierSeries(program, phaseSettings);
            long actualOutputSignal = amplifierSeries.GetOutputSignal();
            Assert.AreEqual(expectedOutputSignal, actualOutputSignal);
        }
    }
}
