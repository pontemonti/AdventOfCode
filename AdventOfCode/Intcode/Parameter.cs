using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode
{
    public struct Parameter
    {
        public Parameter(ParameterMode parameterMode, int value)
        {
            this.ParameterMode = parameterMode;
            this.Value = value;
        }

        public readonly ParameterMode ParameterMode { get; }
        public readonly int Value { get; }

        public static ParameterMode GetParameterMode(int parameterMode)
        {
            return (ParameterMode)parameterMode;
        }
    }
}
