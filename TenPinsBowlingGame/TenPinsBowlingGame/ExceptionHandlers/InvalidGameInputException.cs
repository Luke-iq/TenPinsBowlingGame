using System;

namespace TenPinsBowlingGame.ExceptionHandlers
{
    public class InvalidGameInputException : Exception
    {
        public InvalidGameInputException(string message)
            : base(message)
        {
        }
    }
}
