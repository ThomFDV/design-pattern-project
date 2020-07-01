using System;
using System.Collections.Generic;

namespace ESGI.DesignPattern.Projet
{
    class TennisGame1
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
    
    public interface Game
    { 
        public String GetScore();

        public void WonPoint(int position);
    }

    public class Tennis : Game
    {
        private readonly List<Player> players;

        public Tennis(Player player1, Player player2)
        {
            players = new List<Player>{player1, player2};
        }

        public void WonPoint(int position)
        {
            players[position].WonPoint();
        }
        
        public string GetScore()
        {
            string score  = "";

            if (players[0].score == players[1].score)
            {
                score = ScoreForEquality();
            }
            else if (players[0].score >= 4 || players[1].score >= 4)
            {
                score = ScoreOverFour();
            }
            else
            {
                score = ScoreUnderFour();
            }
            return score;
        }
        
        private string ScoreForEquality()
        {
            switch (players[0].score)
            {
                case 0:
                    return "Love-All";

                case 1:
                    return "Fifteen-All";

                case 2:
                    return "Thirty-All";

                default:
                    return "Deuce";
            }
        }
        
        private string ScoreOverFour()
        {
            var minusResult = players[0].score - players[1].score;
        
            if (minusResult == 1) 
                return "Advantage player1";
            if (minusResult == -1)
                return "Advantage player2";
            if (minusResult >= 2)
                return "Win for player1";

            return  "Win for player2";
        }
        
        private string ScoreUnderFour()
        {
            var tempScore = 0;
            var score = "";
        
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) {
                    tempScore = players[0].score;
                }
                else { 
                    score += "-"; tempScore = players[1].score; 
                }
            
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }
            return score;
        }
    }


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
