﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public abstract class OperationBase : IOperation
    {
        protected readonly IntcodeComputer intcodeComputer;
        protected readonly Parameter[] parameters;

        protected OperationBase(IntcodeComputer intcodeComputer, Parameter[] parameters)
        {
            this.intcodeComputer = intcodeComputer;
            this.parameters = parameters;
        }

        public virtual bool GoToNextOperation => true;
        public abstract int NumberOfParameters { get; }
        public abstract Opcode Opcode { get; }

        public abstract void Execute();

        protected void ExecuteIntegerOperation(Func<long, long, long> integerOperation)
        {
            long n1 = this.GetParameter(0);
            long n2 = this.GetParameter(1);
            long result = integerOperation(n1, n2);

            // "Parameters that an instruction writes to will never be in immediate mode."
            // => Assume position mode
            long position = this.GetParameterToWriteTo(2);
            this.intcodeComputer.WriteToMemory(position, result);
        }

        protected long GetParameter(int parameterNumber)
        {
            Parameter parameter = this.parameters[parameterNumber];
            switch (parameter.ParameterMode)
            {
                case ParameterMode.PositionMode:
                    return this.intcodeComputer.ReadFromMemory(parameter.Value);
                case ParameterMode.ImmediateMode:
                    return parameter.Value;
                case ParameterMode.RelativeMode:
                    return this.intcodeComputer.ReadFromMemory(this.intcodeComputer.RelativeBasePosition + parameter.Value);
                default:
                    throw new InvalidOperationException();
            }
        }

        protected long GetParameterToWriteTo(int parameterNumber)
        {
            Parameter parameter = this.parameters[parameterNumber];
            switch (parameter.ParameterMode)
            {
                case ParameterMode.PositionMode:
                    return parameter.Value;
                case ParameterMode.RelativeMode:
                    return this.intcodeComputer.RelativeBasePosition + parameter.Value;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
