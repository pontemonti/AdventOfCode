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
            Dictionary<string, long> leftovers = new Dictionary<string, long>();
            long numberOfUnitsRequired = this.FindNumberOfUnitsRequiredToMakeChemical(sourceChemicalName, chemicalToMake, leftovers);
            return numberOfUnitsRequired;
        }

        public long FindNumberOfUnitsThatCanBeMadeFromChemical(Chemical sourceChemical, string targetChemicalName)
        {
            Dictionary<string, long> leftovers = new Dictionary<string, long>();
            string sourceChemicalName = sourceChemical.Name;
            long sourceChemicalAmount = sourceChemical.Quantity;
            long numberOfUnitsMade = 0;

            // Figure out how many units or "source" it takes to make 1 "target"
            // Use this number to adjust the initial search amount
            long numberOfUnitsRequiredToMakeOne = this.FindNumberOfUnitsRequiredToMakeChemical(sourceChemicalName, new Chemical(targetChemicalName, 1));
            long factor = numberOfUnitsRequiredToMakeOne / 10;
            long targetChemicalSearchAmount = sourceChemicalAmount/factor;
            bool shouldKeepGoing = true;

            // Binary search to find the correct target amount
            // TODO: This is pretty messy, consider cleaning it up
            while (true)
            {
                Chemical targetChemical = new Chemical(targetChemicalName, targetChemicalSearchAmount);
                long numberOfUnitsRequired = this.FindNumberOfUnitsRequiredToMakeChemical(sourceChemicalName, targetChemical, leftovers);
                if (sourceChemicalAmount >= numberOfUnitsRequired)
                {
                    numberOfUnitsMade += targetChemicalSearchAmount;
                    sourceChemicalAmount -= numberOfUnitsRequired;
                }

                // Search twice for amount 1, to account for leftovers
                if (targetChemicalSearchAmount == 1)
                {
                    if (!shouldKeepGoing)
                    {
                        break;
                    }

                    shouldKeepGoing = false;
                }
                else
                {
                    targetChemicalSearchAmount /= 2;
                }
            }

            return numberOfUnitsMade;
        }

        private long FindNumberOfUnitsRequiredToMakeChemical(string sourceChemicalName, Chemical chemicalToMake, Dictionary<string, long> leftovers)
        {
            // We found the source chemical, just return its quantity
            if (sourceChemicalName == chemicalToMake.Name)
            {
                return chemicalToMake.Quantity;
            }

            Reaction targetReaction = this.FindReactionForTargetChemical(chemicalToMake);

            // Figure out how many times we need to execute the reaction, and how many leftovers it yields
            long numberOfReactionsRequired = (long)Math.Ceiling(chemicalToMake.Quantity / (double)targetReaction.OutputChemical.Quantity);
            long numberOfLeftovers = numberOfReactionsRequired * targetReaction.OutputChemical.Quantity - chemicalToMake.Quantity;
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
                long inputChemicalLeftovers = 0;
                if (leftovers.ContainsKey(inputChemical.Name))
                {
                    inputChemicalLeftovers = leftovers[inputChemical.Name];
                    leftovers[inputChemical.Name] = 0;
                }

                long inputChemicalToMake = numberOfReactionsRequired * inputChemical.Quantity - inputChemicalLeftovers;
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
