using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace Scrabble
{
    [TestFixture]
    public class GameShould
    {
        private GameConsole _gameConsole;
        private Rounds _rounds;
        private Game _game;

        static readonly Player Player1 = new Player("Player 1", null);
        static readonly Player Player2 = new Player("Player 2", null);
        readonly List<Player> _players = new List<Player> { Player1, Player2 };

        [SetUp]
        public void Setup()
        {
            _gameConsole = Substitute.For<GameConsole>();
            _rounds = Substitute.For<Rounds>(
                Substitute.For<Players>(new List<Player>()), 
                Substitute.For<Board>(new Rules(), new Grid()));
            _game = new Game(_gameConsole, _rounds);
            _rounds.Players().Returns(_players);
        }

        [Test]
        public void DisplaysStartGameMessage()
        {
            _game.Run();

            _gameConsole.Received().WriteLine("Welcome to scrabble");
        }

        [Test]
        public void PlayAtLeastOneRound()
        {
            _rounds.HasNext().Returns(false);
            _game.Run();

            _rounds.Received().Play();
        }

        [Test]
        public void GameFinishesWhenNoNextRound()
        {
            _rounds.HasNext().Returns(false);

            _game.Run();

            _gameConsole.Received().WriteLine("Game over");
        }

        [Test]
        public void PlayRoundsUntilFinished()
        {
            _rounds.HasNext().Returns(true, true, false);

            _game.Run();

            _rounds.Received(3).Play();
        }

        [Test]
        public void DisplayPointsAtEndOfGame()
        {
            Player1.AddPoints(80);
            Player2.AddPoints(120);

            _game.Run();

            _gameConsole.Received().WriteLine("Player 1: 80");
            _gameConsole.Received().WriteLine("Player 2: 120");
        }
    }
}