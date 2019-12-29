using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pontemonti.AdventOfCode.Chemistry;
using Pontemonti.AdventOfCode.Utilities;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Part Two ---
    /// 
    /// After collecting ORE for a while, you check your cargo hold: 1 trillion 
    /// (1000000000000) units of ORE.
    /// 
    /// With that much ore, given the examples above:
    /// * The 13312 ORE-per-FUEL example could produce 82892753 FUEL.
    /// * The 180697 ORE-per-FUEL example could produce 5586022 FUEL.
    /// * The 2210736 ORE-per-FUEL example could produce 460664 FUEL.
    /// 
    /// Given 1 trillion ORE, what is the maximum amount of FUEL you can produce?
    /// </summary>
    public class Day14Puzzle2 : IPuzzle
    {
        public void Solve()
        {
            long result = CalculateResult();
            Console.WriteLine($"Maximum amount of FUEL that can be produced with 1 trillion ORE: {result}");
        }

        public static long CalculateResult()
        {
            Reaction[] reactions = InputHelper.ReadReactionLines(Day14Puzzle1.input).ToArray();
            NanoFactory nanoFactory = new NanoFactory(reactions);
            const string sourceChemicalName = "ORE";
            const long sourceChemicalAmount = 1000000000000;
            const string targetChemicalName = "FUEL";
            Chemical sourceChemical = new Chemical(sourceChemicalName, sourceChemicalAmount);
            long result = nanoFactory.FindNumberOfUnitsThatCanBeMadeFromChemical(sourceChemical, targetChemicalName);
            return result;
        }
    }
}
