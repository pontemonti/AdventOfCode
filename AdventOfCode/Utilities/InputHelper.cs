using Pontemonti.AdventOfCode.Geometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Utilities
{
    public class InputHelper
    {
        public const char Comma = ',';

        public static IEnumerable<int> ReadIntegerLines(string input)
        {
            string[] inputLines = input.Split(Environment.NewLine);
            foreach (string inputLine in inputLines)
            {
                yield return int.Parse(inputLine);
            }
        }

        public static IEnumerable<int> ReadIntegerCommaList(string input)
        {
            string[] integerList = input.Split(Comma);
            foreach (string integer in integerList)
            {
                yield return int.Parse(integer);
            }
        }

        public static IEnumerable<(string, string)> ReadOrbitPairLines(string input)
        {
            string[] orbitPairList = input.Split(Environment.NewLine);
            foreach (string orbitPair in orbitPairList)
            {
                string[] orbits = orbitPair.Split(')');
                string to = orbits[0];
                string from = orbits[1];
                yield return (to, from);
            }
        }

        public static IEnumerable<WirePath> ReadWirePathCommaList(string input)
        {
            string[] wirePathList = input.Split(Comma);
            foreach (string wirePath in wirePathList)
            {
                yield return WirePath.Parse(wirePath);
            }
        }

        public static (IEnumerable<WirePath>, IEnumerable<WirePath>) ReadWirePathLines(string input)
        {
            // Currently assumes that there are always exactly two wires
            string[] inputLines = input.Split(Environment.NewLine);
            IEnumerable<WirePath> wire1Paths = ReadWirePathCommaList(inputLines[0]);
            IEnumerable<WirePath> wire2Paths = ReadWirePathCommaList(inputLines[1]);
            return (wire1Paths, wire2Paths);
        }
    }
}
