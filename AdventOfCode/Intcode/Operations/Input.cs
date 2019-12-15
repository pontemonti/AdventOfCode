using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode.Operations
{
    public class Input : OperationBase, IOperation
    {
        public Input(IntcodeComputer intcodeComputer, Parameter[] parameters)
            : base(intcodeComputer, parameters)
        {
        }

        public override int NumberOfParameters => 1;
        public override Opcode Opcode => Opcode.Input;

        public override void Execute()
        {
            // "Parameters that an instruction writes to will never be in immediate mode."
            // => Assume position mode
            long inputValue = this.intcodeComputer.ReadNextInput();
            this.Program[this.parameters[0].Value] = inputValue;
            Console.WriteLine($"{this.intcodeComputer.Name}: After input: {string.Join(",", this.intcodeComputer.Program.Select(n => n.ToString()))}");
        }
    }
}
