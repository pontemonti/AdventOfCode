using Pontemonti.AdventOfCode.Intcode.Operations;
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
        private long[] program;

        public IntcodeComputer(string name, long[] program, params long[] inputs)
        {
            this.Name = name;
            this.semaphore = new Semaphore(0, 100);
            this.program = program;
            this.CurrentPosition = 0;
            this.CurrentInputPosition = 0;
            this.RelativeBasePosition = 0;
            this.Inputs = new List<long>();
            foreach (long input in inputs)
            {
                this.ProvideInput(input);
            }

            this.Output = 0;
        }

        public IntcodeComputer(string name, int[] integers, params int[] inputs)
            : this(name, integers.Select(n => (long)n).ToArray(), inputs.Select(n => (long)n).ToArray())
        {
        }

        public IntcodeComputer(int[] integers, params int[] inputs)
            : this("IntcodeComputer", integers, inputs)
        {
        }

        public IntcodeComputer(int[] integers)
            : this(integers, -1)
        {
        }

        public long CurrentPosition { get; set; }
        public int CurrentInputPosition { get; set; }
        public List<long> Inputs { get; }
        public string Name { get; }
        public long Output { get; set; }
        public long RelativeBasePosition { get; set; }

        public event EventHandler<long> OutputSent;

        public event EventHandler WaitingForInput;

        public long[] GetCurrentState() => this.program;

        public void ProvideInput(long input)
        {
            this.Inputs.Add(input);
            int previousCount = this.semaphore.Release();
            
            Console.WriteLine($"{this.Name}: Input {input} added to position {this.Inputs.Count}; semaphore previous count: {previousCount}.");
        }

        public long ReadFromMemory(long position)
        {
            // The computer's available memory should be much larger than the initial 
            // program. Memory beyond the initial program starts with the value 0 and 
            // can be read or written like any other memory. (It is invalid to try to 
            // access memory at a negative address, though.)
            if (position < 0)
            {
                throw new ArgumentOutOfRangeException($"Tried to access memory at position {position}, which is less than 0 and therefore not allowed.");
            }

            if (position >= this.program.Length)
            {
                return 0;
            }

            return this.program[position];
        }

        public long ReadNextInput()
        {
            this.OnWaitingForInput();
            if (this.semaphore.WaitOne(60 * 1000))
            {
                long input = this.Inputs[this.CurrentInputPosition++];
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
                Console.WriteLine($"Executing operation {operation.Opcode}...");
                operation.Execute();

                // This is used for Jump operations, where we don't want to jump again if we've just jumped.
                if (operation.GoToNextOperation)
                {
                    this.GoToNextPosition(operation);
                }
            }
            while (operation.Opcode != Opcode.Exit);
        }

        public void WriteToMemory(long position, long value)
        {
            if (position >= this.program.Length)
            {
                long newLength = Math.Max(this.program.Length, position) * 2;
                long[] largerProgram = new long[newLength];
                for (int i = 0; i < this.program.Length; i++)
                {
                    largerProgram[i] = this.program[i];
                }

                this.program = largerProgram;
            }

            this.program[position] = value;
        }

        internal void OnOutputSent(long output)
        {
            // Store latest output in Output property
            Console.WriteLine($"{this.Name}: sent output {output}");
            this.Output = output;
            this.OutputSent?.Invoke(this, output);
        }

        internal void OnWaitingForInput()
        {
            Console.WriteLine($"{this.Name}: waiting for input");
            this.WaitingForInput?.Invoke(this, new EventArgs());
        }

        private Opcode GetOpcode()
        {
            long opcodeNumberWithParameterModes = this.program[this.CurrentPosition];
            long opcodeNumber = opcodeNumberWithParameterModes % 100;
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
                case Opcode.AdjustRelativeBase:
                    return new AdjustRelativeBase(this, this.GetParameters(1).ToArray());
                case Opcode.Exit:
                    return new Exit(this);
            }

            throw new InvalidOperationException();
        }

        private IEnumerable<Parameter> GetParameters(int numberOfParameters)
        {
            for (int i = 1; i <= numberOfParameters; i++)
            {
                long parameterValue = this.program[this.CurrentPosition + i];
                ParameterMode parameterMode = this.GetParameterMode(i);
                Parameter parameter = new Parameter(parameterMode, parameterValue);
                yield return parameter;
            }
        }

        private ParameterMode GetParameterMode(int parameterNumber)
        {
            int divideBy = (int)Math.Pow(10, parameterNumber + 1);
            int mod = divideBy * 10;

            long operationValue = this.program[this.CurrentPosition];
            long scopedToParameter = operationValue % mod;
            long parameterModeValue = scopedToParameter / divideBy;
            ParameterMode parameterMode = (ParameterMode)parameterModeValue;
            return parameterMode;
        }

        private void GoToNextPosition(IOperation operation)
        {
            this.CurrentPosition += operation.NumberOfParameters + 1;
        }
    }
}
