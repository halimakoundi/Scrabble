using System.Collections.Generic;

namespace Scrabble.FeatureTests
{
    public class Rounds
    {
        public virtual bool HasNextRound()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Play()
        {
            throw new System.NotImplementedException();
        }

        public virtual List<Player> Players()
        {
            throw new System.NotImplementedException();
        }
    }
}