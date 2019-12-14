using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class AmplifierSeries
    {
        private readonly Amplifier[] amplifiers;

        public AmplifierSeries(int[] program, int[] phaseSettings, bool useFeedback = false)
        {
            int amplifierNumber = 1;
            List<Amplifier> amplifiers = new List<Amplifier>();
            Amplifier previousAmplifier = null;
            foreach (int phaseSetting in phaseSettings)
            {
                // Create a copy of the program for each amplifier, so that we don't pass around
                // refereneces to the array.
                // We can also solve this by passing around the string instead and parsing the string
                // inside of IntcodeComputer.
                int[] programCopy = new List<int>(program).ToArray();
                Amplifier amplifier = new Amplifier($"Amplifier{amplifierNumber++}", programCopy, phaseSetting);
                if (previousAmplifier != null)
                {
                    previousAmplifier.SetNextAmplifier(amplifier);
                }

                amplifiers.Add(amplifier);
                previousAmplifier = amplifier;
            }

            if (useFeedback)
            {
                amplifiers.Last().SetNextAmplifier(amplifiers.First());
            }

            this.amplifiers = amplifiers.ToArray();
        }

        public int GetOutputSignal()
        {
            // For the first amplifier, the input should be 0.
            this.amplifiers.First().IntcodeComputer.ProvideInput(0);
            List<Task<int>> taskList = new List<Task<int>>();
            foreach (Amplifier amplifier in this.amplifiers)
            {
                Task<int> task = Task.Run<int>(() => amplifier.Run());
                taskList.Add(task);
            }

            Task.WaitAll(taskList.ToArray());
            int outputSignal = taskList.Last().Result;
            return outputSignal;
        }
    }
}
