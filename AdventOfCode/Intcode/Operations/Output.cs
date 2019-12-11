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

        public int NumberOfParameters => 1;
        public Opcode Opcode => Opcode.Output;

        public void Execute()
        {
            this.intcodeComputer.Output = this.GetParameter(0);
        }
    }
}
