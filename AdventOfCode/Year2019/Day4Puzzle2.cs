using Pontemonti.AdventOfCode.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Part Two ---
    /// An Elf just remembered one more important detail: the two adjacent matching digits are 
    /// not part of a larger group of matching digits.
    /// 
    /// Given this additional criterion, but still ignoring the range rule, the following are now true:
    /// * 112233 meets these criteria because the digits never decrease and all repeated digits 
    ///   are exactly two digits long.
    /// * 123444 no longer meets the criteria (the repeated 44 is part of a larger group of 444).
    /// * 111122 meets the criteria (even though 1 is repeated more than twice, it still contains a double 22).
    /// 
    /// How many different passwords within the range given in your puzzle input meet all of the criteria?
    /// 
    /// Your puzzle input is still 178416-676461.
    /// </summary>
    public class Day4Puzzle2 : IPuzzle
    {
        public void Solve()
        {
            int result = CalculateResult();
            Console.WriteLine($"{result} number of different passwords within the given range meet the criteria.");
        }

        public static int CalculateResult()
        {
            FuelDepotPasswordFinder fuelDepotPasswordFinder = new FuelDepotPasswordFinder(Day4Puzzle1.numberOfDigits, Day4Puzzle1.minimum, Day4Puzzle1.maximum);
            int[] validPasswords = fuelDepotPasswordFinder.FindAllValidPasswordsV2().ToArray();
            int numberOfValidPasswords = validPasswords.Length;
            return numberOfValidPasswords;
        }
    }
}
