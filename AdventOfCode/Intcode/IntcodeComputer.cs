using Pontemonti.AdventOfCode.Intcode.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode
{
    public class IntcodeComputer
    {
        public IntcodeComputer(int[] integers, params int[] inputs)
        {
            this.Integers = integers;
            this.CurrentPosition = 0;
            this.CurrentInputPosition = 0;
            this.Inputs = inputs;
            this.Output = 0;
        }

        public IntcodeComputer(int[] integers)
            : this(integers, -1)
        {
        }

        public int[] Integers { get; }
        public int CurrentPosition { get; set; }
        public int CurrentInputPosition { get; set; }
        public int[] Inputs { get; }
        public int Output { get; set; }

        public int[] GetCurrentState() => this.Integers;

        public void Run()
        {
            IOperation operation;
            do
            {
                operation = this.GetOperation();
                operation.Execute();

                // This is used for Jump operations, where we don't want to jump again if we've just jumped.
                if (operation.GoToNextOperation)
                {
                    this.GoToNextPosition(operation);
                }
            }
            while (operation.Opcode != Opcode.Exit);
        }

        private Opcode GetOpcode()
        {
            int opcodeNumberWithParameterModes = this.Integers[this.CurrentPosition];
            int opcodeNumber = opcodeNumberWithParameterModes % 100;
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
                case Opcode.JumpIfTrue:
                    return new JumpIfTrue(this, this.GetParameters(2).ToArray());
                case Opcode.JumpIfFalse:
                    return new JumpIfFalse(this, this.GetParameters(2).ToArray());
                case Opcode.LessThan:
                    return new LessThan(this, this.GetParameters(3).ToArray());
                case Opcode.Equals:
                    return new Equals(this, this.GetParameters(3).ToArray());
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
                ParameterMode parameterMode = this.GetParameterMode(i);
                Parameter parameter = new Parameter(parameterMode, parameterValue);
                yield return parameter;
            }
        }

        private ParameterMode GetParameterMode(int parameterNumber)
        {
            int divideBy = (int)Math.Pow(10, parameterNumber + 1);
            int mod = divideBy * 10;

            int operationValue = this.Integers[this.CurrentPosition];
            int scopedToParameter = operationValue % mod;
            int parameterModeValue = scopedToParameter / divideBy;
            ParameterMode parameterMode = (ParameterMode)parameterModeValue;
            return parameterMode;
        }

        private void GoToNextPosition(IOperation operation)
        {
            this.CurrentPosition += operation.NumberOfParameters + 1;
        }
    }
}
