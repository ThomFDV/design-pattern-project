using System;
using Xunit;

namespace ESGI.DesignPattern.Projet.Tests
{
    public class Tests
    {
        [Fact]
        public void Game()
        {
            IGame game = new Tennis(new Player("Maurice"), new Player("Norbert"));
            Assert.NotNull(game);
        }
        
        [Fact]
        public void Should_Return_LoveLove_When_Game_Start()
        {
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            Assert.Equal("Love-All", game.GetScore());
        }
        
        [Fact]
        public void Should_Return_Fifteen_When_Player_WonPoint()
        {
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            game.WonPoint(0);
            Assert.Equal("Fifteen-Love", game.GetScore());
        }
        
        [Fact]
        public void Should_Return_Thirty_When_Player_Won2Point()
        {
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            game.WonPoint(0);
            game.WonPoint(0);
            Assert.Equal("Thirty-Love", game.GetScore());
        }
        
        [Fact]
        public void Should_Return_Forty_When_Player_Won3Point()
        {
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            game.WonPoint(0);
            game.WonPoint(0);
            game.WonPoint(0);
            Assert.Equal("Forty-Love", game.GetScore());
        }
        
        [Fact]
        public void Should_Return_Deuce_When_Players_Won3Point_EachOther()
        {
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            game.WonPoint(0);
            game.WonPoint(0);
            game.WonPoint(0);
            game.WonPoint(1);
            game.WonPoint(1);
            game.WonPoint(1);
            Assert.Equal("Deuce", game.GetScore());
        }
        
        [Fact]
        public void Should_Return_Advantage_When_Player2_Have1Point_Over_Player1()
        {
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            game.WonPoint(0);
            game.WonPoint(0);
            game.WonPoint(0);
            game.WonPoint(1);
            game.WonPoint(1);
            game.WonPoint(1);
            game.WonPoint(1);
            Assert.Equal("Advantage player2", game.GetScore());
        }
        
        [Fact]
        public void Should_Return_WinPlayer2_When_Player2_Have2Points_Over_Player1()
        {
            var game = new Tennis(new Player("Morice"), new Player("Norbert"));
            game.WonPoint(0);
            game.WonPoint(0);
            game.WonPoint(0);
            game.WonPoint(1);
            game.WonPoint(1);
            game.WonPoint(1);
            game.WonPoint(1);
            game.WonPoint(1);
            Assert.Equal("Win for player2", game.GetScore());
        }

    }
}

