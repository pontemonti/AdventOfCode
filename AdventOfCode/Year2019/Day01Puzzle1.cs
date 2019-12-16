using Pontemonti.AdventOfCode.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Year2019
{
    public class Day01Puzzle1 : IPuzzle
    {
        public const string input = @"83281
110963
137849
105456
112819
60817
72085
61440
71799
87704
106917
60141
98846
101962
119935
105419
148806
59017
106495
63871
70045
74235
148702
60455
77694
140310
86284
84659
123898
69894
139427
94767
79377
66250
84478
135686
67196
52581
110081
54347
84698
130634
127325
92776
126100
56838
86543
113360
72062
111919
74682
103605
147243
141504
59943
72751
98896
81071
89513
83074
113120
70692
76552
111705
137550
61939
74620
60464
104956
121073
91999
81857
68973
115985
50815
68344
146640
117467
122904
122521
70758
53028
147377
140588
54506
80064
145885
66725
60104
127545
137801
117472
99427
126069
126418
102451
116782
66106
81694
139492";

        public void Solve()
        {
            int totalFuelRequirements = CalculateTotalFuelRequirements();
            Console.WriteLine($"Total fuel requirements: {totalFuelRequirements}");
        }

        public static int CalculateTotalFuelRequirements()
        {
            int[] masses = InputHelper.ReadIntegerLines(input).ToArray();
            int[] fuelRequirements = masses.Select(mass => CalculateFuelRequirements(mass)).ToArray();
            int totalFuelRequirement = fuelRequirements.Sum();
            return totalFuelRequirement;
        }

        /// <summary>
        /// Fuel required to launch a given module is based on its mass.
        /// Specifically, to find the fuel required for a module, take its mass, divide by three, 
        /// round down, and subtract 2.
        /// 
        /// For example:
        /// For a mass of 12, divide by 3 and round down to get 4, then subtract 2 to get 2.
        /// For a mass of 14, dividing by 3 and rounding down still yields 4, so the fuel required is also 2.
        /// For a mass of 1969, the fuel required is 654.
        /// For a mass of 100756, the fuel required is 33583.
        /// </summary>
        /// <param name="mass">The mass</param>
        /// <returns>
        /// Fuel requirement
        /// </returns>
        public static int CalculateFuelRequirements(int mass)
        {
            double divideByThree = mass / 3d;
            int floor = (int)Math.Floor(divideByThree);
            int fuelRequirement = floor - 2;
            return fuelRequirement;
        }
    }
}
