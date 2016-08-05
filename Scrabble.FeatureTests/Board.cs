namespace Scrabble
{
    public delegate void HasChangedEventHandler();

    public class Board
    {
        private readonly Rules _rules;
        private readonly Grid _grid;

        public Board(Rules rules, Grid grid)
        {
            _rules = rules;
            _grid = grid;
        }

        public virtual event HasChangedEventHandler HasChanged;

        public virtual int Place(Turn turn)
        {
            _rules.Check(turn);
            accept(turn);
            return 0;
        }

        private void accept(Turn turn)
        {
            _grid.place(turn);
            HasChanged.Invoke();
        }
    }
}