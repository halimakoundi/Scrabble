using System;

namespace Scrabble
{
    public class HumanPlayingStrategy : PlayingStrategy
    {
        private readonly TurnReader _turnReader;
        private readonly Board _board;
        private readonly GameConsole _console;

        public HumanPlayingStrategy(TurnReader turnReader, Board board, GameConsole console)
        {
            _turnReader = turnReader;
            _board = board;
            _console = console;
        }

        public int Play()
        {
            while (true)
            {
                try
                {
                    return _board.Place(_turnReader.Read());
                }
                catch (InvalidTurnException e)
                {
                    _console.WriteLine(e.Message);
                }
            }
        }
    }
}