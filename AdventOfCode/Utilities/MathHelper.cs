using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Utilities
{
    public class MathHelper
    {
        /// <summary>
        /// https://en.wikipedia.org/wiki/Greatest_common_divisor
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double GreatestCommonDivisor(double a, double b)
        {
            if (a % b == 0)
            {
                return b;
            }

            return GreatestCommonDivisor(b, a % b);
        }

        /// <summary>
        /// https://en.wikipedia.org/wiki/Least_common_multiple
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static double LeastCommonMultiple(double a, double b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }
    }
}
