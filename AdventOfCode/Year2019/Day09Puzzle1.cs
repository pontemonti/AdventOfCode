﻿using Pontemonti.AdventOfCode.Intcode;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Day 9: Sensor Boost ---
    /// 
    /// You've just said goodbye to the rebooted rover and left Mars when you 
    /// receive a faint distress signal coming from the asteroid belt. It must be 
    /// the Ceres monitoring station!
    /// 
    /// In order to lock on to the signal, you'll need to boost your sensors. The 
    /// Elves send up the latest BOOST program - Basic Operation Of System Test.
    /// 
    /// While BOOST (your puzzle input) is capable of boosting your sensors, for 
    /// tenuous safety reasons, it refuses to do so until the computer it runs on 
    /// passes some checks to demonstrate it is a complete Intcode computer
    /// 
    /// Your existing Intcode computer is missing one key feature: it needs support 
    /// for parameters in relative mode.
    /// 
    /// Parameters in mode 2, relative mode, behave very similarly to parameters 
    /// in position mode: the parameter is interpreted as a position. Like position 
    /// mode, parameters in relative mode can be read from or written to.
    /// 
    /// The important difference is that relative mode parameters don't count from 
    /// address 0. Instead, they count from a value called the relative base. The 
    /// relative base starts at 0.
    /// 
    /// The address a relative mode parameter refers to is itself plus the current 
    /// relative base. When the relative base is 0, relative mode parameters and 
    /// position mode parameters with the same value refer to the same address.
    /// 
    /// For example, given a relative base of 50, a relative mode parameter of -7 
    /// refers to memory address 50 + -7 = 43.
    /// 
    /// The relative base is modified with the relative base offset instruction:
    /// * Opcode 9 adjusts the relative base by the value of its only parameter. 
    ///   The relative base increases (or decreases, if the value is negative) 
    ///   by the value of the parameter.
    /// 
    /// For example, if the relative base is 2000, then after the instruction 
    /// 109,19, the relative base would be 2019. If the next instruction were 
    /// 204,-34, then the value at address 1985 would be output.
    /// 
    /// Your Intcode computer will also need a few other capabilities:
    /// * The computer's available memory should be much larger than the initial 
    ///   program. Memory beyond the initial program starts with the value 0 and 
    ///   can be read or written like any other memory. (It is invalid to try to 
    ///   access memory at a negative address, though.)
    /// * The computer should have support for large numbers. Some instructions 
    ///   near the beginning of the BOOST program will verify this capability.
    /// 
    /// Here are some example programs that use these features:
    /// * 109,1,204,-1,1001,100,1,100,1008,100,16,101,1006,101,0,99 takes no 
    ///   input and produces a copy of itself as output.
    /// * 1102,34915192,34915192,7,4,7,99,0 should output a 16-digit number.
    /// * 104,1125899906842624,99 should output the large number in the middle.
    /// 
    /// The BOOST program will ask for a single input; run it in test mode by 
    /// providing it the value 1. It will perform a series of checks on each 
    /// opcode, output any opcodes (and the associated parameter modes) that seem 
    /// to be functioning incorrectly, and finally output a BOOST keycode.
    /// 
    /// Once your Intcode computer is fully functional, the BOOST program should 
    /// report no malfunctioning opcodes when run in test mode; it should only 
    /// output a single value, the BOOST keycode. What BOOST keycode does it 
    /// produce?
    /// </summary>
    public class Day09Puzzle1 : IPuzzle
    {
        public const string programString = "1102,34463338,34463338,63,1007,63,34463338,63,1005,63,53,1101,3,0,1000,109,988,209,12,9,1000,209,6,209,3,203,0,1008,1000,1,63,1005,63,65,1008,1000,2,63,1005,63,904,1008,1000,0,63,1005,63,58,4,25,104,0,99,4,0,104,0,99,4,17,104,0,99,0,0,1102,1,344,1023,1101,0,0,1020,1101,0,481,1024,1102,1,1,1021,1101,0,24,1005,1101,0,29,1018,1102,39,1,1019,1102,313,1,1028,1102,1,35,1009,1101,28,0,1001,1101,26,0,1013,1101,0,351,1022,1101,564,0,1027,1102,1,32,1011,1101,23,0,1006,1102,1,25,1015,1101,21,0,1003,1101,0,31,1014,1101,33,0,1004,1102,37,1,1000,1102,476,1,1025,1101,22,0,1007,1102,30,1,1012,1102,1,27,1017,1102,1,34,1002,1101,38,0,1008,1102,1,36,1010,1102,1,20,1016,1102,567,1,1026,1102,1,304,1029,109,-6,2108,35,8,63,1005,63,201,1001,64,1,64,1106,0,203,4,187,1002,64,2,64,109,28,21101,40,0,-9,1008,1013,38,63,1005,63,227,1001,64,1,64,1105,1,229,4,209,1002,64,2,64,109,-2,1205,1,243,4,235,1105,1,247,1001,64,1,64,1002,64,2,64,109,-12,2102,1,-5,63,1008,63,24,63,1005,63,271,1001,64,1,64,1105,1,273,4,253,1002,64,2,64,109,8,2108,22,-9,63,1005,63,295,4,279,1001,64,1,64,1106,0,295,1002,64,2,64,109,17,2106,0,-5,4,301,1001,64,1,64,1106,0,313,1002,64,2,64,109,-21,21107,41,40,7,1005,1019,333,1001,64,1,64,1105,1,335,4,319,1002,64,2,64,109,1,2105,1,10,1001,64,1,64,1105,1,353,4,341,1002,64,2,64,109,10,1206,-3,371,4,359,1001,64,1,64,1105,1,371,1002,64,2,64,109,-5,21108,42,42,-7,1005,1011,393,4,377,1001,64,1,64,1105,1,393,1002,64,2,64,109,-8,2101,0,-4,63,1008,63,23,63,1005,63,415,4,399,1105,1,419,1001,64,1,64,1002,64,2,64,109,13,21102,43,1,-6,1008,1017,43,63,1005,63,441,4,425,1106,0,445,1001,64,1,64,1002,64,2,64,109,-21,1207,0,33,63,1005,63,465,1001,64,1,64,1106,0,467,4,451,1002,64,2,64,109,19,2105,1,3,4,473,1106,0,485,1001,64,1,64,1002,64,2,64,109,1,21101,44,0,-7,1008,1015,44,63,1005,63,511,4,491,1001,64,1,64,1106,0,511,1002,64,2,64,109,2,1206,-3,527,1001,64,1,64,1105,1,529,4,517,1002,64,2,64,109,-8,1201,-7,0,63,1008,63,35,63,1005,63,555,4,535,1001,64,1,64,1105,1,555,1002,64,2,64,109,1,2106,0,10,1105,1,573,4,561,1001,64,1,64,1002,64,2,64,109,4,21107,45,46,-7,1005,1014,591,4,579,1106,0,595,1001,64,1,64,1002,64,2,64,109,-12,1208,-6,21,63,1005,63,617,4,601,1001,64,1,64,1105,1,617,1002,64,2,64,109,-11,1208,6,31,63,1005,63,637,1001,64,1,64,1106,0,639,4,623,1002,64,2,64,109,16,2101,0,-7,63,1008,63,20,63,1005,63,659,1105,1,665,4,645,1001,64,1,64,1002,64,2,64,109,3,2102,1,-9,63,1008,63,38,63,1005,63,691,4,671,1001,64,1,64,1106,0,691,1002,64,2,64,109,4,1205,-1,703,1105,1,709,4,697,1001,64,1,64,1002,64,2,64,109,-14,21108,46,45,7,1005,1014,729,1001,64,1,64,1105,1,731,4,715,1002,64,2,64,109,7,21102,47,1,0,1008,1014,45,63,1005,63,755,1001,64,1,64,1106,0,757,4,737,1002,64,2,64,109,-12,2107,34,7,63,1005,63,775,4,763,1105,1,779,1001,64,1,64,1002,64,2,64,109,-5,1207,6,22,63,1005,63,797,4,785,1106,0,801,1001,64,1,64,1002,64,2,64,109,12,1202,0,1,63,1008,63,35,63,1005,63,827,4,807,1001,64,1,64,1105,1,827,1002,64,2,64,109,-5,1202,0,1,63,1008,63,36,63,1005,63,851,1001,64,1,64,1105,1,853,4,833,1002,64,2,64,109,-2,1201,4,0,63,1008,63,20,63,1005,63,873,1105,1,879,4,859,1001,64,1,64,1002,64,2,64,109,2,2107,22,-1,63,1005,63,899,1001,64,1,64,1106,0,901,4,885,4,64,99,21102,1,27,1,21101,0,915,0,1105,1,922,21201,1,53897,1,204,1,99,109,3,1207,-2,3,63,1005,63,964,21201,-2,-1,1,21101,0,942,0,1106,0,922,21202,1,1,-1,21201,-2,-3,1,21101,0,957,0,1105,1,922,22201,1,-1,-2,1105,1,968,22102,1,-2,-2,109,-3,2105,1,0";
        public const int input1 = 1;

        public void Solve()
        {
            long result = CalculateResult();
            Console.WriteLine($"BOOST keycode: {result}");
        }

        public static long CalculateResult()
        {
            long[] integers = InputHelper.ReadInt64CommaList(programString).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer("BOOST", integers, input1);
            intcodeComputer.Run();
            long output = intcodeComputer.Output;
            return output;
        }
    }
}
