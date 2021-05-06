
namespace Tennis
{
    public class Player
    {
        private string Name;
        private int Score;

        public Player(string name)
        {
            Name = name;
        }

        public void UpdateScore ()
        {
            Score++;
        }

        public int GetScore()
        {
            return Score;
        }

        public string GetName()
        {
            return Name;
        }


        public string PlayerScoreString()
        {
            return Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }
    }
}
