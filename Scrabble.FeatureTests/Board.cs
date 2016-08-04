namespace Scrabble
{
    public delegate void HasChangedEventHandler();

    public class Board
    {
        public virtual event HasChangedEventHandler HasChanged;
    }
}