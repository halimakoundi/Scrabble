namespace Scrabble
{
    public delegate void HasChangedEventHandler();

    public class Board
    {
        public virtual event HasChangedEventHandler HasChanged;

        public virtual int Place(Turn turn)
        {
            throw new System.NotImplementedException();
        }
    }
}