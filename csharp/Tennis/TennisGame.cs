using System;

namespace Tennis
{
    internal class TennisGame: ITennisGame
    {
        public Player PlayerOne { get; set; }
        public Player PlayerTwo { get; set; }
        private string GameScore { get; set; }


        public TennisGame(string player1Name, string player2Name)
        {
            PlayerOne = new Player(player1Name);
            PlayerTwo = new Player(player2Name);
            GameScore = "Love-All";
        }

        public string PointScored(Player player)
        {
            player.UpdateScore();
            GameScore = SetGameScore();
            return GameScore;
        }

        public string GetGameScore()
        {
            return GameScore;
        }

        private string SetGameScore()
        {
            if (PlayerOne.GetScore() - PlayerTwo.GetScore() == 0) return Tie(PlayerOne.GetScore());
            if (GameWon()) return $"Win for {LeadPlayer()}";
            if (PlayerHasAdvantage()) return $"Advantage {LeadPlayer()}";
            return $"{PlayerOne.PlayerScoreString()}-{PlayerTwo.PlayerScoreString()}";
        }

        private bool PlayerHasAdvantage()
        {
            return PlayerOne.GetScore() >= 4 || PlayerTwo.GetScore() >= 4;
        }
        
        private bool GameWon()
        {
            return PlayerHasAdvantage() && Math.Abs(PlayerOne.GetScore() - PlayerTwo.GetScore()) >= 2;
        }

        private string Tie(int score)
        {
            return score switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce"
            };
        }

        private string LeadPlayer()
        {
            int current = PlayerOne.GetScore() - PlayerTwo.GetScore();
            return current > 0 ? PlayerOne.GetName() : PlayerTwo.GetName();
        }
    }  
}

