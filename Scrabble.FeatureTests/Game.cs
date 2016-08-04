using System.Linq;
using Scrabble;

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
            PrintGameStart();

            Play();

            PrintGameResult();
        }

        private void PrintGameStart()
        {
            _gameConsole.WriteLine("Welcome to scrabble");
        }

        private void Play()
        {
            do
            {
                _rounds.Play();
            } while (_rounds.HasNext());
        }

        private void PrintGameResult()
        {
            _rounds.Players().ToList().ForEach(
                p => _gameConsole.WriteLine($"{p.Name}: {p.Points()}"));

            _gameConsole.WriteLine("Game over");
        }
    }
}