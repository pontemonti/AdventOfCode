using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public class Exit : OperationBase, IOperation
    {
        public Exit(IntcodeComputer intcodeComputer)
            : base(intcodeComputer, null)
        {
        }

        public int NumberOfParameters => 0;
        public Opcode Opcode => Opcode.Exit;

        public void Execute()
        {
            // Do nothing
        }
    }
}
