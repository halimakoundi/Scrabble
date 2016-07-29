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
        private List<Player> _allPlayers;

        [SetUp]
        public void SetUp()
        {
            _player1 = Substitute.For<Player>("");
            _player2 = Substitute.For<Player>("");
            _allPlayers = new List<Player> {_player1, _player2};
            _players = new Players(_allPlayers);
        }

        [Test]
        public void be_able_to_play_when_at_least_one_player_didnt_pass()
        {
            _player1.HasPassed().Returns(true);
            _players = new Players(new List<Player>() {_player2, _player1});
            _player2.HasPassed().Returns(false);

            Assert.That(_players.HasEveryonePassed(), Is.EqualTo(true));
        }

        [Test]
        public void not_be_able_to_play_when_all_players_passed()
        {
            _player1.HasPassed().Returns(false);
            _player2.HasPassed().Returns(false);

            Assert.That(_players.HasEveryonePassed(), Is.EqualTo(false));
        }

        [Test]
        public void tell_each_player_to_play_in_turn()
        {
            _players.Play();

            Received.InOrder(()=>
            {
                _player1.Play();
                _player2.Play();
            });
        }

        [Test]
        public void return_all_players()
        {
            Assert.That(_players.All(), Is.EqualTo(_allPlayers));
        }
    }
}
