using NSubstitute;
using NUnit.Framework;

namespace Scrabble
{
    [TestFixture]
    public class PlayerShould
    {
        private PlayingStrategy _playingStrategy;
        private Player _player;

        [SetUp]
        public void SetUp()
        {
            _playingStrategy = Substitute.For<PlayingStrategy>();
            _player = new Player("", _playingStrategy);

        }

        [Test]
        public void play_using_a_strategy()
        {
            _player.Play();

            _playingStrategy.Received().Play();
        }
    }
}
