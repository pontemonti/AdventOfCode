using System;
using System.Runtime.Serialization;

namespace Pontemonti.AdventOfCode.Intcode
{
    [Serializable]
    internal class TerminateIntcodeComputerException : Exception
    {
        public TerminateIntcodeComputerException()
        {
        }

        public TerminateIntcodeComputerException(string? message) : base(message)
        {
        }

        public TerminateIntcodeComputerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TerminateIntcodeComputerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}