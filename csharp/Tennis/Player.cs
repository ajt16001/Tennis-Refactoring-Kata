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

    }
}
