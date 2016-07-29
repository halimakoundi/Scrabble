using System;

namespace Scrabble
{
    public class Player
    {
        public string Name { get; }
        private int _points;

        public Player(string name)
        {
            Name = name;
        }

        public virtual void Play()
        {
            throw new NotImplementedException();
        }

        public int Points() => _points;

        public void AddPoints(int points) => _points += points;

        public virtual bool HasPassed()
        {
            throw new NotImplementedException();
        }
    }
}