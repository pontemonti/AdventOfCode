using Pontemonti.AdventOfCode.Intcode.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode
{
    public class IntcodeComputer
    {
        public IntcodeComputer(int[] integers)
        {
            this.Integers = integers;
            this.CurrentPosition = 0;
        }

        public int[] Integers { get; }
        public int CurrentPosition { get; set; }

        public int[] GetCurrentState() => this.Integers;

        public void Run()
        {
            IOperation operation;
            do
            {
                operation = this.GetOperation();
                operation.Execute();
                this.GoToNextPosition(operation);
            }
            while (operation.Opcode != Opcode.Exit);
        }

        private Opcode GetOpcode()
        {
            int opcodeNumber = this.Integers[this.CurrentPosition];
            Opcode opcode = (Opcode)opcodeNumber;
            return opcode;
        }

        private IOperation GetOperation()
        {
            Opcode opcode = this.GetOpcode();
            switch (opcode)
            {
                // TODO: Avoid harcoding number of parameters here
                case Opcode.Add:
                    return new Add(this, this.GetParameters(3).ToArray());
                case Opcode.Multiply:
                    return new Multiply(this, this.GetParameters(3).ToArray());
                case Opcode.Input:
                    return new Input(this, this.GetParameters(1).ToArray());
                case Opcode.Output:
                    return new Output(this, this.GetParameters(1).ToArray());
                case Opcode.Exit:
                    return new Exit(this);
            }

            throw new InvalidOperationException();
        }

        private IEnumerable<Parameter> GetParameters(int numberOfParameters)
        {
            for (int i = 1; i <= numberOfParameters; i++)
            {
                int parameterValue = this.Integers[this.CurrentPosition + i];
                ParameterMode parameterMode = ParameterMode.PositionMode;
                Parameter parameter = new Parameter(parameterMode, parameterValue);
                yield return parameter;
            }
        }

        private void GoToNextPosition(IOperation operation)
        {
            this.CurrentPosition += operation.NumberOfParameters + 1;
        }
    }
}
