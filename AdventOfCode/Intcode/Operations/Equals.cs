using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    /// <summary>
    /// Opcode 8 is equals: if the first parameter is equal to the second 
    /// parameter, it stores 1 in the position given by the third parameter. 
    /// Otherwise, it stores 0.
    /// </summary>
    public class Equals : ConditionalOperationBase, IOperation
    {
        public Equals(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override Opcode Opcode => Opcode.Equals;

        public override void Execute()
        {
            this.ExecuteConditionalOperation((n1, n2) => n1 == n2);
        }
    }
}
