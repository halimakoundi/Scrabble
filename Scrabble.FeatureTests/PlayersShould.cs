using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace Scrabble
{
    [TestFixture]
    class PlayersShould
    {
        private Players _players;
        private Player _player1;
        private Player _player2;

        [SetUp]
        public void SetUp()
        {
            _player1 = Substitute.For<Player>("");
            _player2 = Substitute.For<Player>("");
            _players = new Players(new List<Player>() {_player1, _player2});
        }

        [Test]
        public void be_able_to_play_when_any_player_can_play()
        {
            _player1.CanPlay().Returns(true);
            _players = new Players(new List<Player>() {_player2, _player1});
            _player2.CanPlay().Returns(false);

            Assert.That(_players.CanPlay(), Is.EqualTo(true));
        }

        [Test]
        public void not_be_able_to_play_when_no_player_can_play()
        {
            _player1.CanPlay().Returns(false);
            _player2.CanPlay().Returns(false);

            Assert.That(_players.CanPlay(), Is.EqualTo(false));
        }

        [Test]
        public void tell_each_player_to_play_in_turn()
        {
            _players.Play();

            Received.InOrder(()=>
            {
                _player1.Play();
                _player2.Play();
            }
        );
        }
    }
}
