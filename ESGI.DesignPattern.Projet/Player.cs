using System;

namespace ESGI.DesignPattern.Projet
{
    public class Player
    {
        private String name;
        public int score { get; private set; } = 0;

        public Player(String name)
        {
            this.name = name;
        }

        public void WonPoint()
        {
            score += 1;
        }
    }
}