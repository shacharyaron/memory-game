using System.Windows.Forms;

namespace GameUI
{
    internal class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            GameLauncher game = new GameLauncher();
            game.Start();
        }
    }
}
