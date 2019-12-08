using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode
{
    public class IntcodeComputer
    {
        private int[] integers;
        private int position;

        public IntcodeComputer(int[] integers)
        {
            this.integers = integers;
            this.position = 0;
        }

        public int[] GetCurrentState() => this.integers;

        public void Run()
        {
            Opcode opcode;
            do
            {
                opcode = this.GetOpcode();
                this.ExecuteCommand(opcode);
                this.GoToNextPosition();
            }
            while (opcode != Opcode.Exit);
        }

        private void ExecuteCommand(Opcode opcode)
        {
            switch(opcode)
            {
                case Opcode.Add:
                    this.ExecuteAdd();
                    break;
                case Opcode.Multiply:
                    this.ExecuteMultiply();
                    break;
            }
        }

        private void ExecuteMultiply()
        {
            this.ExecuteIntegerOperation((n1, n2) => n1 * n2);
        }

        private void ExecuteAdd()
        {
            this.ExecuteIntegerOperation((n1, n2) => n1 + n2);
        }

        private void ExecuteIntegerOperation(Func<int, int, int> integerOperation)
        {
            int n1Position = this.integers[this.position + 1];
            int n2Position = this.integers[this.position + 2];
            int n1 = this.integers[n1Position];
            int n2 = this.integers[n2Position];
            int result = integerOperation(n1, n2);
            int resultPosition = this.integers[this.position + 3];
            this.integers[resultPosition] = result;
        }

        private Opcode GetOpcode()
        {
            int opcodeNumber = this.integers[this.position];
            Opcode opcode = (Opcode)opcodeNumber;
            return opcode;
        }

        private void GoToNextPosition()
        {
            this.position += 4;
        }
    }
}
