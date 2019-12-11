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

        public int NumberOfParameters => 1;
        public Opcode Opcode => Opcode.Input;

        public void Execute()
        {
            // "Parameters that an instruction writes to will never be in immediate mode."
            // => Assume position mode
            this.Integers[this.parameters[0].Value] = this.intcodeComputer.Input;
        }
    }
}
