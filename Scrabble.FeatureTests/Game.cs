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
            while (_rounds.HasNext())
            {
                _rounds.Play();
            }
        }

        private void PrintGameResult()
        {
            _rounds.Players().ForEach(
                p => _gameConsole.WriteLine($"{p.Name}: {p.Points()}"));

            _gameConsole.WriteLine("Game over");
        }
    }
}