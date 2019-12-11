using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public class Output : OperationBase, IOperation
    {
        public Output(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override int NumberOfParameters => 1;
        public override Opcode Opcode => Opcode.Output;

        public override void Execute()
        {
            this.intcodeComputer.Output = this.GetParameter(0);
        }
    }
}
