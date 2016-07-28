using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Scrabble.FeatureTests;
using Scrabble.Infrastructure;

namespace Scrabble.FeatureTests
{
    [TestClass]
    public class GameFeature
    {
        private GameConsole _gameConsole;
        private Rounds _rounds;
        private Game _game;

        static readonly Player Player1 = new Player("Player 1");
        static readonly Player Player2 = new Player("Player 2");
        readonly List<Player> _players = new List<Player> { Player1, Player2 };

        [TestInitialize]
        public void Setup()
        {
            _gameConsole = Substitute.For<GameConsole>();
            _rounds = Substitute.For<Rounds>();
            _game = new Game(_gameConsole, _rounds);
            _rounds.Players().Returns(_players);
        }

        [TestMethod]
        public void DisplaysStartGameMessage()
        {
            _game.Run();

            _gameConsole.Received().WriteLine("Welcome to scrabble");
        }

        [TestMethod]
        public void GameFinishesWhenNoNextRound()
        {
            _rounds.HasNextRound().Returns(false);

            _game.Run();

            _gameConsole.Received().WriteLine("Game over");
        }

        [TestMethod]
        public void PlayRoundsUntilFinished()
        {
            _rounds.HasNextRound().Returns(true, true, false);

            _game.Run();

            _rounds.Received(2).Play();
        }

        [TestMethod]
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