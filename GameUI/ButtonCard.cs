using System.Drawing;
using System.Windows.Forms;
using B20_Ex02_Shir_315396283_Shachar_207642091;

namespace GameUI
{
    public sealed class ButtonCard<T> : Button
    {
        private const int k_Size = 80;
        public delegate void CardSelectionEventHandler(ButtonCard<T> buttonCard);
        public event CardSelectionEventHandler CardSelection;

        public ButtonCard(int i_X, int i_Y, Card<T> i_Card)
        {
            X = i_X;
            Y = i_Y;
            Card = i_Card;
            Card.CardStatusChanged += OnCardSelection;
            Width = k_Size;
            Height = k_Size;
            Enabled = true;
            TabStop = false;
            ImageAlign = ContentAlignment.MiddleCenter;
            BackgroundImageLayout = ImageLayout.Center;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Card<T> Card { get; set; }

        private void OnCardSelection()
        {
            BackgroundImage = Card.IsSelected ? Card.Value as Image : default;
            if (Card.IsSelected)
            {
                CardSelection?.Invoke(this);
            }
            else
            {
                BackColor = Color.Transparent;
            }

            Enabled = !Card.IsSelected;
        }
    }
}