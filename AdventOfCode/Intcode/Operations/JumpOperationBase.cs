using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public abstract class JumpOperationBase : OperationBase, IOperation
    {
        private bool goToNextOperation = true;

        public JumpOperationBase(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override bool GoToNextOperation => this.goToNextOperation;

        public override int NumberOfParameters => 2;

        protected void ExecuteJumpOperation(Func<long, bool> jumpPredicate)
        {
            long n1 = this.GetParameter(0);
            if (jumpPredicate(n1))
            {
                long n2 = this.GetParameter(1);
                this.intcodeComputer.CurrentPosition = n2;

                // We have jumped to a new position, so signal to the computer that we don't want to jump again
                this.goToNextOperation = false;
            }
        }
    }
}
