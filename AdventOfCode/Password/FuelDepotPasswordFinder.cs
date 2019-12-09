using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Password
{
    public class FuelDepotPasswordFinder
    {
        private readonly int minimum;
        private readonly int maximum;
        private readonly int numberOfDigits;

        public FuelDepotPasswordFinder(int numberOfDigits, int minimum, int maximum)
        {
            this.minimum = minimum;
            this.maximum = maximum;
            this.numberOfDigits = numberOfDigits;
        }

        public IEnumerable<int> FindAllValidPasswordsV1()
        {
            int count = this.maximum - this.minimum;
            int[] passwords = Enumerable.Range(this.minimum, count).ToArray();
            passwords = FilterByNumberOfDigits(passwords, this.numberOfDigits).ToArray();
            passwords = FilterByDigitsNeverDecrease(passwords).ToArray();
            passwords = FilterByDigitsWithTwoAdjacentDigits(passwords).ToArray();
            return passwords;
        }

        public IEnumerable<int> FindAllValidPasswordsV2()
        {
            int[] passwords = FindAllValidPasswordsV1().ToArray();
            passwords = FilterByDigitsWithExactlyTwoAdjacentDigits(passwords).ToArray();
            return passwords;
        }

        private IEnumerable<int> FilterByDigitsWithExactlyTwoAdjacentDigits(IEnumerable<int> passwords)
        {
            foreach (int password in passwords)
            {
                int[] passwordDigits = password.ToString().Select(c => int.Parse(c.ToString())).ToArray();
                int currentDigit = passwordDigits[0];
                int currentDigitCounter = 1;
                for (int i = 1; i < passwordDigits.Length; i++)
                {
                    if (passwordDigits[i] == currentDigit)
                    {
                        currentDigitCounter++;
                    }
                    else if (currentDigitCounter == 2)
                    {
                        break;
                    }
                    else
                    {
                        currentDigit = passwordDigits[i];
                        currentDigitCounter = 1;
                    }
                }

                if (currentDigitCounter == 2)
                {
                    yield return password;
                }
            }
        }

        private static IEnumerable<int> FilterByNumberOfDigits(IEnumerable<int> passwords, int numberOfDigits)
        {
            foreach (int password in passwords)
            {
                if (password.ToString().Length == numberOfDigits)
                {
                    yield return password;
                }
            }
        }

        private static IEnumerable<int> FilterByDigitsWithTwoAdjacentDigits(IEnumerable<int> passwords)
        {
            foreach (int password in passwords)
            {
                bool passwordIsValid = false;
                int[] passwordDigits = password.ToString().Select(c => int.Parse(c.ToString())).ToArray();
                for (int i = 0; i < passwordDigits.Length - 1; i++)
                {
                    if (passwordDigits[i] == passwordDigits[i + 1])
                    {
                        passwordIsValid = true;
                        break;
                    }
                }

                if (passwordIsValid)
                {
                    yield return password;
                }
            }
        }

        public static IEnumerable<int> FilterByDigitsNeverDecrease(IEnumerable<int> passwords)
        {
            foreach (int password in passwords)
            {
                bool passwordIsValid = true;
                int[] passwordDigits = password.ToString().Select(c => int.Parse(c.ToString())).ToArray();
                for (int i = 0; i < passwordDigits.Length - 1; i++)
                {
                    if (passwordDigits[i] > passwordDigits[i+1])
                    {
                        passwordIsValid = false;
                        break;
                    }
                }

                if (passwordIsValid)
                {
                    yield return password;
                }
            }
        }
    }
}
