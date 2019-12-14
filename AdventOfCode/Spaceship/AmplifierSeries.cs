using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class AmplifierSeries
    {
        private readonly Amplifier[] amplifiers;

        public AmplifierSeries(int[] program, int[] phaseSettings)
        {
            this.amplifiers = phaseSettings.Select(phaseSetting => new Amplifier(program, phaseSetting)).ToArray();
        }

        public int GetOutputSignal()
        {
            // "output signal" is the input to the next amplifier (and finally to the thruster)
            // For the first amplifier, the input should be 0.
            int outputSignal = 0;
            foreach (Amplifier amplifier in this.amplifiers)
            {
                outputSignal = amplifier.Run(outputSignal);
            }

            return outputSignal;
        }
    }
}
