using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    /// <summary>
    /// Opcode 6 is jump-if-false: if the first parameter is zero, it sets the 
    /// instruction pointer to the value from the second parameter. Otherwise, 
    /// it does nothing.
    /// </summary>
    public class JumpIfFalse : JumpOperationBase, IOperation
    {
        public JumpIfFalse(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override Opcode Opcode => Opcode.JumpIfFalse;

        public override void Execute()
        {
            this.ExecuteJumpOperation(n1 => n1 == 0);
        }
    }
}
