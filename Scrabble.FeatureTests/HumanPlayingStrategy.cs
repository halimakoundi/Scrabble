using System;

namespace Scrabble
{
    public class HumanPlayingStrategy : PlayingStrategy
    {
        private TurnReader _turnReader;
        private readonly Board _board;

        public HumanPlayingStrategy(TurnReader turnReader, Board board)
        {
            _turnReader = turnReader;
            _board = board;
        }

        public int Play()
        {
            try
            {
                return _board.Place(_turnReader.Read());
            }
            catch (InvalidTurnException)
            {
                return _board.Place(_turnReader.Read());
            }
        }
    }
}