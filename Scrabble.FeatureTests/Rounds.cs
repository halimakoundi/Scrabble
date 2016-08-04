using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace Scrabble
{
    public class Rounds
    {
        private readonly Players _players;
        private bool _boardHasChanged;

        public Rounds(Players players, Board board)
        {
            _players = players;
            board.HasChanged += () => { _boardHasChanged = true; };
        }

        public virtual void Play()
        {
            NewRound();
            _players.Play();
        }

        public virtual IList<Player> Players()
        {
            return _players.All();
        }

        public virtual bool HasNext()
        {
            return _boardHasChanged;
        }

        private void NewRound()
        {
            _boardHasChanged = false;
        }
    }
}