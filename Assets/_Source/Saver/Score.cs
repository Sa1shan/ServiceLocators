namespace _Source.Saver
{
    public class Score
    {
        public int CurrentScore { get; private set; }

        public Score(int start = 0)
        {
            CurrentScore = start;
        }

        public void Add(int amount = 1)
        {
            CurrentScore += amount;
        }

        public void Reset()
        {
            CurrentScore = 0;
        }
    }

}