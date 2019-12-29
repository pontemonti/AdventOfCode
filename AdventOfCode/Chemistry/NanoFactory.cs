using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Chemistry
{
    public class NanoFactory
    {
        public NanoFactory(IEnumerable<Reaction> reactions)
        {
            this.Reactions = reactions.ToArray();
        }

        public Reaction[] Reactions { get; }

        public long FindNumberOfUnitsRequiredToMakeChemical(string sourceChemicalName, Chemical chemicalToMake)
        {
            Dictionary<string, int> leftovers = new Dictionary<string, int>();
            return this.FindNumberOfUnitsRequiredToMakeChemical(sourceChemicalName, chemicalToMake, leftovers);
        }

        private long FindNumberOfUnitsRequiredToMakeChemical(string sourceChemicalName, Chemical chemicalToMake, Dictionary<string, int> leftovers)
        {
            // We found the source chemical, just return its quantity
            if (sourceChemicalName == chemicalToMake.Name)
            {
                return chemicalToMake.Quantity;
            }

            Reaction targetReaction = this.FindReactionForTargetChemical(chemicalToMake);

            // Figure out how many times we need to execute the reaction, and how many leftovers it yields
            int numberOfReactionsRequired = (int)Math.Ceiling(chemicalToMake.Quantity / (double)targetReaction.OutputChemical.Quantity);
            int numberOfLeftovers = numberOfReactionsRequired * targetReaction.OutputChemical.Quantity - chemicalToMake.Quantity;
            if (leftovers.ContainsKey(targetReaction.OutputChemical.Name))
            {
                leftovers[targetReaction.OutputChemical.Name] += numberOfLeftovers;
            }
            else
            {
                leftovers.Add(targetReaction.OutputChemical.Name, numberOfLeftovers);
            }

            long numberOfUnitsRequired = 0;
            foreach (Chemical inputChemical in targetReaction.InputChemicals)
            {
                int inputChemicalLeftovers = 0;
                if (leftovers.ContainsKey(inputChemical.Name))
                {
                    inputChemicalLeftovers = leftovers[inputChemical.Name];
                    leftovers[inputChemical.Name] = 0;
                }

                int inputChemicalToMake = numberOfReactionsRequired * inputChemical.Quantity - inputChemicalLeftovers;
                Chemical adjustedInputChemical = new Chemical(inputChemical.Name, inputChemicalToMake);
                numberOfUnitsRequired += this.FindNumberOfUnitsRequiredToMakeChemical(sourceChemicalName, adjustedInputChemical, leftovers);
            }

            return numberOfUnitsRequired;
        }

        private Reaction FindReactionForTargetChemical(Chemical chemicalToMake)
            => this.Reactions.First(reaction => reaction.OutputChemical.Name == chemicalToMake.Name);

        private IEnumerable<Reaction> FindReactionsForSourceChemicalName(string sourceChemicalName)
            => this.Reactions.Where(reaction => reaction.InputChemicals.Length == 1 && reaction.InputChemicals[0].Name == sourceChemicalName);
    }
}
