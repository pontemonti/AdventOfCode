using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public class Input : OperationBase, IOperation
    {
        public Input(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override int NumberOfParameters => 1;
        public override Opcode Opcode => Opcode.Input;

        public override void Execute()
        {
            // "Parameters that an instruction writes to will never be in immediate mode."
            // => Assume position mode
            this.Integers[this.parameters[0].Value] = this.intcodeComputer.Inputs[this.intcodeComputer.CurrentInputPosition++];
        }
    }
}
