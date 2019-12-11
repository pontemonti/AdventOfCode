using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    /// <summary>
    /// Opcode 5 is jump-if-true: if the first parameter is non-zero, it sets 
    /// the instruction pointer to the value from the second parameter. 
    /// Otherwise, it does nothing.
    /// </summary>
    public class JumpIfTrue : JumpOperationBase, IOperation
    {
        public JumpIfTrue(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override Opcode Opcode => Opcode.JumpIfTrue;

        public override void Execute()
        {
            this.ExecuteJumpOperation(n1 => n1 != 0);
        }
    }
}
