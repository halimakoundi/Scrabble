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

        public virtual void Play()
        {
            _players.ForEach(p => p.Play());
        }

        public virtual IList<Player> All()
        {
            return _players.AsReadOnly();
        }
    }
}