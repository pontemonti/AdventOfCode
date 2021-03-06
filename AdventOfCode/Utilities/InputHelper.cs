﻿using Pontemonti.AdventOfCode.Chemistry;
using Pontemonti.AdventOfCode.Geometry;
using Pontemonti.AdventOfCode.Spaceship;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Utilities
{
    public class InputHelper
    {
        public const char Comma = ',';

        public static AsciiMap ReadAsciiMap(string mapString)
        {
            List<Point> scaffoldPositions = new List<Point>();

            string[] mapLines = mapString.Split(Environment.NewLine);
            for (int y = 0; y < mapLines.Length; y++)
            {
                string mapLine = mapLines[y];
                for (int x = 0; x < mapLine.Length; x++)
                {
                    if (mapLine[x] == '#')
                    {
                        Point point = new Point(x, y);
                        scaffoldPositions.Add(point);
                    }
                }
            }

            AsciiMap asciiMap = new AsciiMap(scaffoldPositions);
            return asciiMap;
        }

        public static AsteroidMap ReadAsteroidMap(string input)
        {
            List<Point> asteroidPositions = new List<Point>();
            string[] inputLines = input.Split(Environment.NewLine);
            for (int y = 0; y < inputLines.Length; y++)
            {
                string line = inputLines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        Point asteroidPosition = new Point(x, y);
                        asteroidPositions.Add(asteroidPosition);
                    }
                }
            }

            AsteroidMap asteroidMap = new AsteroidMap(asteroidPositions.ToArray());
            return asteroidMap;
        }

        public static IEnumerable<int> ReadDigitList(string input)
        {
            int[] digits = new int[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                string digitString = input.Substring(i, 1);
                int digit = int.Parse(digitString);
                digits[i] = digit;
            }

            return digits;
        }

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

        public static IEnumerable<long> ReadInt64CommaList(string input)
        {
            string[] integerList = input.Split(Comma);
            foreach (string integer in integerList)
            {
                yield return long.Parse(integer);
            }
        }

        public static JupiterMoons ReadJupiterMoons(string input)
        {
            List<Moon> moons = new List<Moon>();
            string[] lines = input.Split(Environment.NewLine);
            foreach (string line in lines)
            {
                string trimmedLine = line.Replace("<", string.Empty);
                trimmedLine = trimmedLine.Replace(">", string.Empty);
                string[] split = trimmedLine.Split(",");
                string strx = split[0].Trim().Substring(2);
                int x = int.Parse(strx);
                int y = int.Parse(split[1].Trim().Substring(2));
                int z = int.Parse(split[2].Trim().Substring(2));
                Moon moon = new Moon(x, y, z);
                moons.Add(moon);
            }

            JupiterMoons jupiterMoons = new JupiterMoons(moons);
            return jupiterMoons;
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

        public static IEnumerable<Reaction> ReadReactionLines(string inputLines)
        {
            string[] lines = inputLines.Split(Environment.NewLine);
            foreach (string line in lines)
            {
                string[] split = line.Split("=>");
                string inputChemicalsString = split[0];
                string[] inputChemicalsSplit = inputChemicalsString.Split(",");
                List<Chemical> inputChemicalsList = new List<Chemical>();
                foreach (string inputChemical in inputChemicalsSplit)
                {
                    string[] inputChemicalSplit = inputChemical.Trim().Split(" ");
                    int inputChemicalQuantity = int.Parse(inputChemicalSplit[0]);
                    string inputChemicalName = inputChemicalSplit[1];
                    inputChemicalsList.Add(new Chemical(inputChemicalName, inputChemicalQuantity));
                }

                string outputChemicalString = split[1];
                string[] outputChemicalSplit = outputChemicalString.Trim().Split(" ");
                int outputChemicalQuantity = int.Parse(outputChemicalSplit[0]);
                string outputChemicalName = outputChemicalSplit[1];
                Chemical outputChemical = new Chemical(outputChemicalName, outputChemicalQuantity);
                Reaction reaction = new Reaction(inputChemicalsList, outputChemical);
                yield return reaction;
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
