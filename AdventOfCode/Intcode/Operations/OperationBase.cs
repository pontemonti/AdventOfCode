using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public abstract class OperationBase
    {
        protected readonly IntcodeComputer intcodeComputer;
        protected readonly Parameter[] parameters;

        protected OperationBase(IntcodeComputer intcodeComputer, Parameter[] parameters)
        {
            this.intcodeComputer = intcodeComputer;
            this.parameters = parameters;
        }

        protected int[] Integers => this.intcodeComputer.Integers;

        protected void ExecuteIntegerOperation(Func<int, int, int> integerOperation)
        {
            int n1 = this.Integers[this.parameters[0].Value];
            int n2 = this.Integers[this.parameters[1].Value];
            int result = integerOperation(n1, n2);
            this.Integers[this.parameters[2].Value] = result;
        }
    }
}
