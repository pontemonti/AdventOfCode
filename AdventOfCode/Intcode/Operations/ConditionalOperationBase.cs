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

        protected void ExecuteConditionalOperation(Func<int, int, bool> conditionalPredicate)
        {
            int n1 = this.GetParameter(0);
            int n2 = this.GetParameter(1);
            int result = conditionalPredicate(n1, n2) ? 1 : 0;
            this.Integers[this.parameters[2].Value] = result;
        }
    }
}
