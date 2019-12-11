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

        public override int NumberOfParameters => 0;
        public override Opcode Opcode => Opcode.Exit;

        public override void Execute()
        {
            // Do nothing
        }
    }
}
