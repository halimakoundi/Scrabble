using System;

namespace Scrabble
{
    public class Player
    {
        private readonly PlayingStrategy _playingStrategy;
        public string Name { get; }
        private int _points;

        public Player(string name, PlayingStrategy playingStrategy)
        {
            _playingStrategy = playingStrategy;
            Name = name;
        }

        public virtual void Play()
        {
            _playingStrategy.Play();
        }

        public int Points() => _points;

        public void AddPoints(int points) => _points += points;
    }
}