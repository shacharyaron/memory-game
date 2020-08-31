using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GameUI
{
    internal class GameLauncher
    {
        private const string k_ImagesUrl = "https://picsum.photos/80";
        private const int k_NumOfCards = 18;
        private readonly FormSetup r_Setup;
        private FormGameBoard m_GameBoard;

        public GameLauncher()
        {
            r_Setup = new FormSetup();
        }

        public void Start()
        {
            r_Setup.ShowDialog();
            List<Image> deckOfCards = generateDeckOfCards();
            m_GameBoard = new FormGameBoard(r_Setup.Settings, deckOfCards);
            r_Setup.DialogResult = DialogResult.OK;

            do
            {
                m_GameBoard.ShowDialog();
            }
            while (m_GameBoard.DialogResult == DialogResult.Yes);
        }

        private Image loadImageFromUrl(string i_Url)
        {
            System.Net.WebRequest imageRequest = System.Net.WebRequest.Create(i_Url);
            System.Net.WebResponse imageResponse = imageRequest.GetResponse();
            Stream imageStream = imageResponse.GetResponseStream();
            Bitmap image = new Bitmap(new Bitmap(imageStream ?? throw new InvalidOperationException()), new Size(65, 65));

            return image;
        }

        private List<Image> generateDeckOfCards()
        {
            List<Image> deckOfCards = new List<Image>();

            for (int i = 0; i < k_NumOfCards; i++)
            {
                Image image = loadImageFromUrl(k_ImagesUrl);
                deckOfCards.Add(image);
            }

            return deckOfCards;
        }
    }
}
