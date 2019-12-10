using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public class Multiply : OperationBase, IOperation
    {
        public Multiply(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public int NumberOfParameters => 3;
        public Opcode Opcode => Opcode.Multiply;

        public void Execute()
        {
            this.ExecuteIntegerOperation((n1, n2) => n1 * n2);
        }
    }
}
