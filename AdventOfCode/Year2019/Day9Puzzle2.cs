using Pontemonti.AdventOfCode.Intcode;
using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Part Two ---
    /// 
    /// You now have a complete Intcode computer.
    /// 
    /// Finally, you can lock on to the Ceres distress signal! You just need to 
    /// boost your sensors using the BOOST program.
    /// 
    /// The program runs in sensor boost mode by providing the input instruction 
    /// the value 2. Once run, it will boost the sensors automatically, but it 
    /// might take a few seconds to complete the operation on slower hardware. In 
    /// sensor boost mode, the program will output a single value: the coordinates 
    /// of the distress signal.
    /// 
    /// Run the BOOST program in sensor boost mode. What are the coordinates of the 
    /// distress signal?
    /// </summary>
    public class Day9Puzzle2 : IPuzzle
    {
        public const int input1 = 2;

        public void Solve()
        {
            long result = CalculateResult();
            Console.Write($"Coordinates of the distress signal: {result}");
        }

        public static long CalculateResult()
        {
            long[] integers = InputHelper.ReadInt64CommaList(Day9Puzzle1.programString).ToArray();
            IntcodeComputer intcodeComputer = new IntcodeComputer("BOOST", integers, input1);
            intcodeComputer.Run();
            long output = intcodeComputer.Output;
            return output;
        }
    }
}
