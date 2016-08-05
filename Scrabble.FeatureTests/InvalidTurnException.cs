using System;

namespace Scrabble
{
    public class InvalidTurnException : Exception
    {

        public InvalidTurnException(string message) : base(message)
        {
        }
    }
}