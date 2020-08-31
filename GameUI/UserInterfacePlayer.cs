using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace GameUI
{
    public class UserInterfacePlayer<T> : Player<T>
    {
        public UserInterfacePlayer(Color i_Color)
        {
            Color = i_Color;
            Label.BackColor = Color;
            Label.AutoSize = true;
            ScoreAdded += OnAddScore;
        }

        public Color Color { get; set; }

        public Label Label { get; set; } = new Label();

        private void OnAddScore()
        {
            Label.Text = Score == 1 ? $@"{Name}: {Score} Pair(s)" : $@"{Name}: {Score} Pairs";
        }
    }
}
