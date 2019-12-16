using Pontemonti.AdventOfCode.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Day 4: Secure Container ---
    /// You arrive at the Venus fuel depot only to discover it's protected by a password. 
    /// The Elves had written the password on a sticky note, but someone threw it out.
    /// 
    /// However, they do remember a few key facts about the password:
    /// * It is a six-digit number.
    /// * The value is within the range given in your puzzle input.
    /// * Two adjacent digits are the same (like 22 in 122345).
    /// * Going from left to right, the digits never decrease; they only ever increase or 
    ///   stay the same(like 111123 or 135679).
    /// 
    /// Other than the range rule, the following are true:
    /// * 111111 meets these criteria(double 11, never decreases).
    /// * 223450 does not meet these criteria(decreasing pair of digits 50).
    /// * 123789 does not meet these criteria(no double).
    /// 
    /// How many different passwords within the range given in your puzzle input meet these criteria?
    /// 
    /// Your puzzle input is 178416-676461.
    /// </summary>
    public class Day04Puzzle1 : IPuzzle
    {
        public const int minimum = 178416;
        public const int maximum = 676461;
        public const int numberOfDigits = 6;

        public void Solve()
        {
            int result = CalculateResult();
            Console.WriteLine($"{result} number of different passwords within the given range meet the criteria.");
        }

        public static int CalculateResult()
        {
            FuelDepotPasswordFinder fuelDepotPasswordFinder = new FuelDepotPasswordFinder(numberOfDigits, minimum, maximum);
            int[] validPasswords = fuelDepotPasswordFinder.FindAllValidPasswordsV1().ToArray();
            int numberOfValidPasswords = validPasswords.Length;
            return numberOfValidPasswords;
        }
    }
}
