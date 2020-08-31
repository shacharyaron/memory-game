using System;

namespace GameLogic
{
    public class Card<T>
    {
        public event Action CardStatusChanged;
        private bool m_IsSelected;

        public Card(T i_ValueFromUser)
        {
            m_IsSelected = false;
            Value = i_ValueFromUser;
        }

        public T Value { get; }

        public bool IsSelected
        {
            get => m_IsSelected;

            set
            {
                m_IsSelected = value;
                CardStatusChanged?.Invoke();
            }
        }

        public bool CompareTo(Card<T> i_Cell2)
        {
            bool isEqual = i_Cell2.Value.Equals(Value);

            return isEqual;
        }
    }
}
