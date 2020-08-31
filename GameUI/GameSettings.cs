using System.Drawing;

namespace GameUI
{
    public class GameSettings
    {
        private const int k_MinDimension = 4;
        private const int k_MaxDimension = 6;

        public GameSettings()
        {
            Player1 = new UserInterfacePlayer<Image>(Color.SpringGreen);
            Player2 = new UserInterfacePlayer<Image>(Color.CornflowerBlue);
            BoardHeight = k_MinDimension;
            BoardWidth = k_MinDimension;
        }

        public UserInterfacePlayer<Image> Player1 { get; }

        public UserInterfacePlayer<Image> Player2 { get; }

        public int BoardHeight { get; set; }

        public int BoardWidth { get; set; }

        public void UpdateDimensions()
        {
            do
            {
                BoardWidth++;
                if (BoardWidth <= k_MaxDimension)
                {
                    continue;
                }

                BoardWidth = k_MinDimension;
                BoardHeight++;
                if (BoardHeight > k_MaxDimension)
                {
                    BoardHeight = k_MinDimension;
                }
            }
            while ((BoardWidth * BoardHeight) % 2 == 1);
        }
    }
}
