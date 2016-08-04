using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace Scrabble
{
    [TestFixture]
    public class HumanPlayingStrategyShould
    {
        private HumanPlayingStrategy _humanPlayingSrategy;
        private TurnReader _turnReader;
        private Board _board;

        [SetUp]
        public void SetUp()
        {
            _turnReader = Substitute.For<TurnReader>();
            _board = Substitute.For<Board>();
            _humanPlayingSrategy = new HumanPlayingStrategy(_turnReader, _board);
        }

        [Test]
        public void place_a_new_turn_when_placed_turn_is_invalid()
        {
            Turn invalidTurn = new Turn();
            Turn validTurn = new Turn();

            _turnReader.Read().Returns(invalidTurn, validTurn);

            _board.Place(invalidTurn)
                .Returns(x => { throw new InvalidTurnException(); });
            _humanPlayingSrategy.Play();

            Received.InOrder(() =>
            {
                _turnReader.Read();
                Assert.Throws<InvalidTurnException>(() => _board.Received().Place(invalidTurn));
                _turnReader.Read();
                _board.Place(validTurn);
            });
        }


        [Test]
        public void return_turn_points()
        {
            var points = 5;

            var validTurn = new Turn();
            _turnReader.Read().Returns( validTurn);

            _board.Place(validTurn).Returns(points);

            Assert.That(_humanPlayingSrategy.Play(), Is.EqualTo(points));
        }
    }
}
