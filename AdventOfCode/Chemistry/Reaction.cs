using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Chemistry
{
    public class Reaction
    {
        public Reaction(IEnumerable<Chemical> inputChemicals, Chemical outputChemical)
        {
            this.InputChemicals = inputChemicals.ToArray();
            this.OutputChemical = outputChemical;
        }

        public Chemical[] InputChemicals { get; }
        public Chemical OutputChemical { get; }
    }
}
