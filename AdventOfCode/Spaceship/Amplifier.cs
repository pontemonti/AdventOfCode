using Pontemonti.AdventOfCode.Intcode;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Spaceship
{
    public class Amplifier
    {
        private readonly int[] program;
        private readonly int phaseSetting;
        private Amplifier nextAmplifier;

        public Amplifier(string name, int[] program, int phaseSetting)
        {
            this.program = program;
            this.phaseSetting = phaseSetting;
            this.IntcodeComputer = new IntcodeComputer(name, this.program, this.phaseSetting);
        }

        public IntcodeComputer IntcodeComputer { get; }

        public long Run()
        {
            this.IntcodeComputer.Run();
            return this.IntcodeComputer.Output;
        }

        public void SetNextAmplifier(Amplifier nextAmplifier)
        {
            this.nextAmplifier = nextAmplifier;
            this.IntcodeComputer.OutputSent += this.IntcodeComputerOutputSent;
        }

        private void IntcodeComputerOutputSent(object? sender, long outputSignal)
        {
            this.nextAmplifier.IntcodeComputer.ProvideInput(outputSignal);
        }
    }
}
