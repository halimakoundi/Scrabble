using System.Collections.Generic;

namespace Scrabble
{
    public class Rounds
    {
        private readonly Players _players;

        public Rounds(Players players)
        {
            _players = players;
        }

        public virtual bool HasNext()
        {
            return _players.CanPlay();
        }

        public virtual void Play()
        {
            _players.Play();
        }

        public virtual List<Player> Players()
        {
            return _players.ToList();
        }
    }
}