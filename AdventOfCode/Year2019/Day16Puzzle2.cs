using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pontemonti.AdventOfCode.Utilities;

namespace Pontemonti.AdventOfCode.Year2019
{
    /// <summary>
    /// --- Part Two ---
    /// 
    /// Now that your FFT is working, you can decode the real signal.
    /// 
    /// The real signal is your puzzle input repeated 10000 times. Treat this new 
    /// signal as a single input list. Patterns are still calculated as before, and 
    /// 100 phases of FFT are still applied.
    /// 
    /// The first seven digits of your initial input signal also represent the 
    /// message offset. The message offset is the location of the eight-digit 
    /// message in the final output list. Specifically, the message offset 
    /// indicates the number of digits to skip before reading the eight-digit 
    /// message. For example, if the first seven digits of your initial input 
    /// signal were 1234567, the eight-digit message would be the eight digits 
    /// after skipping 1,234,567 digits of the final output list. Or, if the 
    /// message offset were 7 and your final output list were 98765432109876543210, 
    /// the eight-digit message would be 21098765. (Of course, your real message 
    /// offset will be a seven-digit number, not a one-digit number like 7.)
    /// 
    /// Here is the eight-digit message in the final output list after 100 phases. 
    /// The message offset given in each input has been highlighted. (Note that the 
    /// inputs given below are repeated 10000 times to find the actual starting 
    /// input lists.)
    /// * 03036732577212944063491565474664 becomes 84462026.
    /// * 02935109699940807407585447034323 becomes 78725270.
    /// * 03081770884921959731165446850517 becomes 53553731.
    /// 
    /// After repeating your input signal 10000 times and running 100 phases of 
    /// FFT, what is the eight-digit message embedded in the final output list?
    /// </summary>
    public class Day16Puzzle2 : IPuzzle
    {
        public void Solve()
        {
            string result = CalculateResult(Day16Puzzle1.input);
            Console.WriteLine($"The eight-digit message embedded in the final output list {result}");
        }

        public static string CalculateResult(string inputString)
        {
            //string repeatedInputSignal = string.Join(string.Empty, Enumerable.Repeat(inputString, 10000).ToArray());
            StringBuilder repeatedInputStringBuilder = new StringBuilder(inputString.Length * 10000);
            for (int i = 0; i < 10000; i++)
            {
                repeatedInputStringBuilder.Append(inputString);
            }

            string messageOffsetString = inputString.Substring(0, 7);
            int messageOffset = int.Parse(messageOffsetString);
            string repeatedInputString = repeatedInputStringBuilder.ToString();
            if (messageOffset < repeatedInputString.Length / 2)
            {
                throw new InvalidOperationException($"Can't handle message offset {messageOffset} for string length {repeatedInputString.Length}");
            }

            // The offset also means that those first X digits are useless
            // Let's just chop off the input
            string relevantInputString = repeatedInputString.Substring(messageOffset);
            string result = CalculateMessage(relevantInputString);
            //string result = Day16Puzzle1.CalculateResult(relevantInputString);
            //string result = Day16Puzzle1.CalculateResult(repeatedInputSignal, messageOffset);
            //string result = Day16Puzzle1.CalculateResult(repeatedInputStringBuilder.ToString(), messageOffset);
            return result;
        }

        private static string CalculateMessage(string inputString)
        {
            int[] digits = InputHelper.ReadDigitList(inputString).ToArray();
            for (int i = 0; i < 100; i++)
            {
                digits = CalculatePhase(digits);
            }

            int[] first8Digits = digits.Take(8).ToArray();
            string first8DigitsString = string.Join(string.Empty, first8Digits);
            return first8DigitsString;
        }

        private static int[] CalculatePhase(int[] digits)
        {
            int previousResult = 0;
            for (int i = 0; i < digits.Length; i++)
            {
                previousResult += digits[i];
            }

            int[] newDigits = new int[digits.Length];
            newDigits[0] = previousResult % 10;
            for (int i = 1; i < digits.Length; i++)
            {
                int result = previousResult - digits[i-1];
                previousResult = result;
                newDigits[i] = result % 10;
            }

            return newDigits;
        }
    }
}
