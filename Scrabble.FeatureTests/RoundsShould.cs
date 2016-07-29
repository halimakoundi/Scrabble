using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace Scrabble
{
    [TestFixture]
    class RoundsShould
    {
        private Players _players;
        private Rounds _rounds;

        [SetUp]
        public void SetUp()
        {
            _players = Substitute.For<Players>(new List<Player>());
            _rounds = new Rounds(_players);
        }

        [Test]
        public void have_no_next_round_when_everyone_has_passed()
        {
            _players.HasEveryonePassed().Returns(false);

            Assert.That(_rounds.HasNext(), Is.EqualTo(true));
        }

        [Test]
        public void have_next_round_when_not_everyone_has_passed()
        {
            _players.HasEveryonePassed().Returns(true);

            Assert.That(_rounds.HasNext(), Is.EqualTo(false));

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
    }
}
