using System;

namespace GameLogic
{
    public class Player<T>
    {
        private int m_Score;
        public event Action ScoreAdded;

        public Player()
        {
            m_Score = 0;
        }

        public string Name { get; set; }

        public int Score
        {
            get => m_Score;

            set
            {
                m_Score = value;
                ScoreAdded?.Invoke();
            }
        }

        public ePlayerType PlayerType { get; set; }

        public virtual void AddScore()
        {
            Score++;
        }

        public virtual Card<T> PickCard(Board<T> i_Board)
        {
            Random random = new Random();
            int index = random.Next(0, i_Board.AvailableCards.Count);
            Card<T> card = i_Board.RemoveAvailableCardByIndex(index);

            return card;
        }

        public void InitializePlayer()
        {
            Score = 0;
        }

        public enum ePlayerType
        {
            Human,
            Computer
        }
    }
}
