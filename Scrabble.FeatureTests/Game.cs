using System.Collections.Generic;
using Scrabble.FeatureTests;
using Scrabble.Infrastructure;

namespace Scrabble
{
    public class Game
    {
        private readonly GameConsole _gameConsole;
        private readonly Rounds _rounds;

        public Game(GameConsole gameConsole, Rounds rounds)
        {
            _gameConsole = gameConsole;
            _rounds = rounds;
        }

        public void Run()
        {
            _gameConsole.WriteLine("Welcome to scrabble");

            while (_rounds.HasNextRound())
            {
                _rounds.Play();
            }

            _rounds.Players().ForEach(
                p => _gameConsole.WriteLine($"{p.Name}: {p.Points()}"));

            _gameConsole.WriteLine("Game over");
        }
    }
}