using System.Collections.Generic;
using System.Linq;

namespace Scrabble
{
    public class Players
    {
        private readonly List<Player> _players;

        public Players(List<Player> players)
        {
            _players = players;
        }

        public virtual bool CanPlay()
        {
            return _players.Any(p => p.CanPlay());
        }

        public virtual void Play()
        {
            _players.ForEach(p => p.Play());
        }

        public virtual List<Player> ToList()
        {
            throw new System.NotImplementedException();
        }
    }
}