using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Scrabble
{
    [TestFixture]
    class BoardShould
    {
        private Rules _rules;
        private Board _board;
        private Grid _grid;

        [SetUp]
        public void setUp()
        {
            _grid = Substitute.For<Grid>();
            _rules = Substitute.For<Rules>();
            _board = new Board(_rules, _grid);
        }

        [Test]
        public void check_whether_turn_is_valid_and_if_so_place_tiles_in_grid()
        {
            var turn = new Turn();
            HasChangedEventHandler handler = Substitute.For<HasChangedEventHandler>();
            _board.HasChanged += handler;
            _board.Place(turn);

            Received.InOrder(() =>
            {
                _rules.Check(turn);
                _grid.place(turn);
                handler.Invoke();
            });
        }
    }

    public class Grid
    {
        public virtual void place(Turn turn)
        {
            throw new NotImplementedException();
        }
    }

    public class Rules
    {
        public virtual void Check(Turn turn)
        {
            throw new NotImplementedException();
        }
    }
}
