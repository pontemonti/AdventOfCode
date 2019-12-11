using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    /// <summary>
    /// Opcode 7 is less than: if the first parameter is less than the second 
    /// parameter, it stores 1 in the position given by the third parameter. 
    /// Otherwise, it stores 0.
    /// </summary>
    public class LessThan : ConditionalOperationBase, IOperation
    {
        public LessThan(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override Opcode Opcode => Opcode.LessThan;

        public override void Execute()
        {
            this.ExecuteConditionalOperation((n1, n2) => n1 < n2);
        }
    }
}
