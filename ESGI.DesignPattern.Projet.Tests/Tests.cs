using System;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        [Fact]
        public void Game()
        {
            var rand = new Random();
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            game.WonPoint(rand.Next(0, 2));
            
            Console.WriteLine(game.GetScore());
        }

    }
}

