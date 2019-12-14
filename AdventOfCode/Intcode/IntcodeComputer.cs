﻿using Pontemonti.AdventOfCode.Intcode.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pontemonti.AdventOfCode.Intcode
{
    public class IntcodeComputer
    {
        private Semaphore semaphore;

        public IntcodeComputer(string name, int[] integers, params int[] inputs)
        {
            this.Name = name;
            this.semaphore = new Semaphore(0, 100);
            this.Integers = integers;
            this.CurrentPosition = 0;
            this.CurrentInputPosition = 0;
            this.Inputs = new List<int>();
            foreach (int input in inputs)
            {
                this.ProvideInput(input);
            }

            this.Output = 0;
        }

        public IntcodeComputer(int[] integers, params int[] inputs)
            : this("IntcodeComputer", integers, inputs)
        {
        }

        public IntcodeComputer(int[] integers)
            : this(integers, -1)
        {
        }

        public int[] Integers { get; }
        public int CurrentPosition { get; set; }
        public int CurrentInputPosition { get; set; }
        public List<int> Inputs { get; }
        public string Name { get; }
        public int Output { get; set; }

        public event EventHandler<int> OutputSent;

        public int[] GetCurrentState() => this.Integers;

        public void ProvideInput(int input)
        {
            this.Inputs.Add(input);
            int previousCount = this.semaphore.Release();
            
            Console.WriteLine($"{this.Name}: Input {input} added to position {this.Inputs.Count}; semaphore previous count: {previousCount}.");
        }

        public int ReadNextInput()
        {
            if (this.semaphore.WaitOne(60 * 1000))
            {
                int input = this.Inputs[this.CurrentInputPosition++];
                Console.WriteLine($"{this.Name}: Input read: {input}; next input position: {this.CurrentInputPosition}");
                return input;
            }
            else
            {
                throw new TimeoutException($"While waiting for input, failed to enter semaphore within 60 seconds. CurrentInputPosition: {this.CurrentInputPosition}; Inputs: {string.Join(", ", this.Inputs.Select(x => x.ToString()))}");
            }
        }

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

        internal void OnOutputSent(int output)
        {
            // Store latest output in Output property
            Console.WriteLine($"{this.Name}: sent output {output}");
            this.Output = output;
            this.OutputSent?.Invoke(this, output);
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
