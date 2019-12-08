using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Utilities
{
    public class InputHelper
    {
        public static IEnumerable<int> ReadIntegerLines(string input)
        {
            string[] inputLines = input.Split(Environment.NewLine);
            foreach (string inputLine in inputLines)
            {
                yield return int.Parse(inputLine);
            }
        }
    }
}
