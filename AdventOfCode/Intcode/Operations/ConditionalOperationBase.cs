using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public abstract class ConditionalOperationBase : OperationBase, IOperation
    {
        public ConditionalOperationBase(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override int NumberOfParameters => 3;

        protected void ExecuteConditionalOperation(Func<long, long, bool> conditionalPredicate)
        {
            long n1 = this.GetParameter(0);
            long n2 = this.GetParameter(1);
            long result = conditionalPredicate(n1, n2) ? 1 : 0;
            long position = this.GetParameterToWriteTo(2);
            this.intcodeComputer.WriteToMemory(position, result);
        }
    }
}
