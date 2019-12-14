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

        public Amplifier(int[] program, int phaseSetting)
        {
            this.program = program;
            this.phaseSetting = phaseSetting;
        }

        public int Run(int inputSignal)
        {
            IntcodeComputer intcodeComputer = new IntcodeComputer(this.program, this.phaseSetting, inputSignal);
            intcodeComputer.Run();
            return intcodeComputer.Output;
        }
    }
}
