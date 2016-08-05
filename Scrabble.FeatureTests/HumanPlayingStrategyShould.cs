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
        private GameConsole _console;
        private InvalidTurnException _invalidTurnException;

        [SetUp]
        public void SetUp()
        {
            _console = Substitute.For<GameConsole>();
            _turnReader = Substitute.For<TurnReader>();
            _board = Substitute.For<Board>(new Rules(), new Grid());
            _humanPlayingSrategy = new HumanPlayingStrategy(_turnReader, _board, _console);
            _invalidTurnException = new InvalidTurnException("message");
        }

        [Test]
        public void place_a_new_turn_until_placed_turn_is_valid()
        {
            Turn invalidTurn = new Turn();
            Turn validTurn = new Turn();

            _turnReader.Read().Returns(invalidTurn, invalidTurn, validTurn);
            _board.Place(invalidTurn)
                .Returns(x => { throw _invalidTurnException; });

            _humanPlayingSrategy.Play();

            Received.InOrder(() =>
            {
                _turnReader.Read();
                Assert.Throws<InvalidTurnException>(() => _board.Received().Place(invalidTurn));
                _turnReader.Read();
                Assert.Throws<InvalidTurnException>(() => _board.Received().Place(invalidTurn));
                _turnReader.Read();
                _board.Place(validTurn);
            });
        }


        [Test]
        public void print_invalid_turn_message_to_console_if_place_invalid_turn()
        {
            Turn invalidTurn = new Turn();
            Turn validTurn = new Turn();

            _turnReader.Read().Returns(invalidTurn, validTurn);
            _board.Place(invalidTurn)
                .Returns(x =>
                {
                    throw _invalidTurnException;
                });

            _humanPlayingSrategy.Play();

            _console.Received().WriteLine(_invalidTurnException.Message);
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
