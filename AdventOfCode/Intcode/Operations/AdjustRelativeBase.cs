using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public class AdjustRelativeBase : OperationBase, IOperation
    {
        public AdjustRelativeBase(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override int NumberOfParameters => 1;
        public override Opcode Opcode => Opcode.AdjustRelativeBase;

        public override void Execute()
        {
            long relativeBaseAdjustment = this.GetParameter(0);
            this.intcodeComputer.RelativeBasePosition += relativeBaseAdjustment;
        }
    }
}
