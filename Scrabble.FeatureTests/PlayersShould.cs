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
            _player1 = Substitute.For<Player>("", null);
            _player2 = Substitute.For<Player>("", null);
            _allPlayers = new List<Player> {_player1, _player2};
            _players = new Players(_allPlayers);
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
