using Pontemonti.AdventOfCode.Graph;
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
    /// Now, you just need to figure out how many orbital transfers you (YOU) need 
    /// to take to get to Santa (SAN).
    /// 
    /// You start at the object YOU are orbiting; your destination is the object 
    /// SAN is orbiting. An orbital transfer lets you move from any object to an 
    /// object orbiting or orbited by that object.
    /// 
    /// For example, suppose you have the following map:
    /// COM)B
    /// B)C
    /// C)D
    /// D)E
    /// E)F
    /// B)G
    /// G)H
    /// D)I
    /// E)J
    /// J)K
    /// K)L
    /// K)YOU
    /// I)SAN
    /// 
    /// Visually, the above map of orbits looks like this:
    ///                           YOU
    ///                          /
    ///         G - H       J - K - L
    ///        /           /
    /// COM - B - C - D - E - F
    ///                \
    ///                 I - SAN
    /// 
    /// In this example, YOU are in orbit around K, and SAN is in orbit around I. 
    /// To move from K to I, a minimum of 4 orbital transfers are required:
    /// * K to J
    /// * J to E
    /// * E to D
    /// * D to I
    /// 
    /// Afterward, the map of orbits looks like this:
    ///         G - H       J - K - L
    ///        /           /
    /// COM - B - C - D - E - F
    ///                \
    ///                 I - SAN
    ///                  \
    ///                   YOU
    /// 
    /// What is the minimum number of orbital transfers required to move from the 
    /// object YOU are orbiting to the object SAN is orbiting? (Between the 
    /// objects they are orbiting - not between YOU and SAN.)
    /// </summary>
    public class Day6Puzzle2 : IPuzzle
    {
        public void Solve()
        {
            int result = CalculateResult();
            Console.WriteLine($"Minimum number of orbital tranfers required: {result}");
        }

        public static int CalculateResult()
        {
            (string, string)[] orbitPairArray = InputHelper.ReadOrbitPairLines(Day6Puzzle1.input).ToArray();
            DirectedGraph<string> orbitGraph = DirectedGraph<string>.CreateFromInput(orbitPairArray);
            int minimumOrbitalTransfers = orbitGraph.FindMinimumNumberOfOrbitalTransfers("YOU", "SAN");
            return minimumOrbitalTransfers;
        }
    }
}
