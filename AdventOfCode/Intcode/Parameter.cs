using System;
using System.Collections.Generic;
using System.Text;

namespace Pontemonti.AdventOfCode.Intcode
{
    public struct Parameter
    {
        public Parameter(ParameterMode parameterMode, long value)
        {
            this.ParameterMode = parameterMode;
            this.Value = value;
        }

        public readonly ParameterMode ParameterMode { get; }
        public readonly long Value { get; }

        public static ParameterMode GetParameterMode(long parameterMode)
        {
            return (ParameterMode)parameterMode;
        }
    }
}
