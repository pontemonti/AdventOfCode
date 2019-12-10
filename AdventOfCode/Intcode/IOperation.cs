using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode
{
    public interface IOperation
    {
        int NumberOfParameters { get; }
        Opcode Opcode { get; }
        void Execute();
    }
}
