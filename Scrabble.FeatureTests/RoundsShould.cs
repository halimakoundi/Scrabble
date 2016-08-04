using System;
using System.Collections.Generic;
using NSubstitute;
using NSubstitute.Core.Events;
using NUnit.Framework;

namespace Scrabble
{
    [TestFixture]
    class RoundsShould
    {
        private Players _players;
        private Rounds _rounds;
        private Board _board;

        [SetUp]
        public void SetUp()
        {
            _board = Substitute.For<Board>();
            _players = Substitute.For<Players>(new List<Player>());
            _rounds = new Rounds(_players, _board);
        }

        [Test]
        public void tell_players_to_play()
        {
            _rounds.Play();

            _players.Received().Play();
        }

        [Test]
        public void return_players_list()
        {
            var expectedPlayers = new List<Player>();
            _players.All().Returns(expectedPlayers);

            var players = _rounds.Players();

            Assert.That(players, Is.EqualTo(expectedPlayers));

        }

        [Test]
        public void have_next_round_when_board_has_changed_during_a_round()
        {
            _board.HasChanged += Raise.Event<HasChangedEventHandler>();

            Assert.That(_rounds.HasNext(), Is.EqualTo(true));
        }

        [Test]
        public void have_no_next_round_when_board_has_not_changed_during_a_round()
        {
            _board.HasChanged += Raise.Event<HasChangedEventHandler>();

            _rounds.Play();

            Assert.That(_rounds.HasNext(), Is.EqualTo(false));
        }
    }

}
