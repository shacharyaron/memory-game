using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using B20_Ex02_Shir_315396283_Shachar_207642091;
using B20_Ex02_Shir_315396283_Shachar_207642091.GameLogic;

namespace GameUI
{
    public partial class FormGameBoard : Form
    {
        private const int k_Space = 8;
        private const int k_Second = 1000;
        private const int k_Size = 80;
        private const string k_Replay = "Do you want to replay?";
        private const string k_GameOverTitle = "Game Over";
        private const string k_TieMessage = "It's A Tie!";
        private readonly GameSettings r_Settings;
        private readonly List<Image> r_DeckOfCards;
        private UserInterfacePlayer<Image> m_Player1;
        private UserInterfacePlayer<Image> m_Player2;
        private Board<Image> m_Board;
        private UserInterfacePlayer<Image> m_PlayingUserInterfacePlayer;
        private Card<Image> m_PlayingCard1;
        private Card<Image> m_PlayingCard2;
        private List<ButtonCard<Image>> m_CardButtons;
        private eTurns m_Turn;
        private bool m_IsFirstCardSelected;

        public FormGameBoard(GameSettings i_Settings, List<Image> i_DeckOfCards)
        {
            InitializeComponent();
            r_DeckOfCards = i_DeckOfCards;
            r_Settings = i_Settings;
            gameInit();
        }

        private void gameInit()
        {
            m_CardButtons = new List<ButtonCard<Image>>();
            playersInit();
            boardInit();
        }

        private void boardInit()
        {
            m_Board = new Board<Image>(r_DeckOfCards, r_Settings.BoardHeight, r_Settings.BoardWidth);
            generateUserInterfaceBoard();
        }

        private void generateUserInterfaceBoard()
        {
            generateCards();
            labelsInit();
        }

        private void labelsInit()
        {
            PlayingPlayerName.Text = $@"Current Player: {m_Player1.Name}";
            PlayingPlayerName.BackColor = m_PlayingUserInterfacePlayer.Color;
            m_Player1.Label.Location = new Point(PlayingPlayerName.Location.X, PlayingPlayerName.Location.Y + 30);
            m_Player1.Label.Anchor = AnchorStyles.Bottom;
            m_Player1.Label.Anchor = AnchorStyles.Left;
            m_Player2.Label.Location = new Point(PlayingPlayerName.Location.X, PlayingPlayerName.Location.Y + 60);
            m_Player2.Label.Anchor = AnchorStyles.Bottom;
            m_Player2.Label.Anchor = AnchorStyles.Left;
            Controls.Add(m_Player1.Label);
            Controls.Add(m_Player2.Label);
        }

        private void generateCards()
        {
            int height = m_Board.Cards.GetLength(0);
            int width = m_Board.Cards.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    ButtonCard<Image> buttonCard = new ButtonCard<Image>(i, j, m_Board.Cards[i, j]);
                    buttonCard.Location = new Point(i * (buttonCard.Width + k_Space), j * (buttonCard.Height + k_Space));
                    buttonCard.Click += cardButton_Click;
                    Controls.Add(buttonCard);
                    buttonCard.CardSelection += paintCard;
                    m_CardButtons.Add(buttonCard);
                }
            }

            ClientSize = new Size(m_Board.Cards.GetLength(0) * (k_Size + k_Space),
                (m_Board.Cards.GetLength(1) * (k_Size + k_Space)) + 100);
        }

        private void paintCard(ButtonCard<Image> buttonCard)
        {
            buttonCard.BackColor = m_PlayingUserInterfacePlayer.Color;
        }

        private void playersInit()
        {
            m_Turn = eTurns.Player1;
            m_Player1 = r_Settings.Player1;
            m_Player2 = r_Settings.Player2;
            m_PlayingUserInterfacePlayer = m_Player1;
            m_Player1.InitializePlayer();
            m_Player2.InitializePlayer();
        }

        private void cardButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            Card<Image> selectedCard = ((ButtonCard<Image>)i_Sender).Card;
            m_Board.FlipCardUpWards(selectedCard);

            if (m_IsFirstCardSelected)
            {
                m_PlayingCard2 = selectedCard;
                bool isSuccessful = isSuccessfulMove();
                waitOneSecond();

                if (isSuccessful)
                {
                    m_PlayingUserInterfacePlayer.AddScore();
                    isGameOver();
                }
                else
                {
                    undoMove();
                    switchTurn();
                    if (m_PlayingUserInterfacePlayer.PlayerType == Player<Image>.ePlayerType.Computer)
                    {
                        doAutomaticMove();
                    }
                }
            }
            else
            {
                m_PlayingCard1 = selectedCard;
            }

            m_IsFirstCardSelected = !m_IsFirstCardSelected;
        }

        private void doAutomaticMove()
        {
            bool isSuccessful;
            do
            {
                isSuccessful = doMove();
                if (!isSuccessful)
                {
                    continue;
                }

                m_PlayingUserInterfacePlayer.AddScore();
                bool isGameDone = isGameOver();
                if (isGameDone)
                {
                    break;
                }
            }
            while (isSuccessful);

            switchTurn();
        }

        private bool isGameOver()
        {
            bool isGameOver = m_Board.IsGameOver();
            if (isGameOver)
            {
                DialogResult = MessageBox.Show(setWinner(), k_GameOverTitle, MessageBoxButtons.YesNo);
                if (DialogResult == DialogResult.Yes)
                {
                    replay();
                }
            }

            return isGameOver;
        }

        private void replay()
        {
            foreach (ButtonCard<Image> button in m_CardButtons)
            {
                Controls.Remove(button);
            }

            gameInit();
            Close();
        }

        private bool doMove()
        {
            m_PlayingCard1 = null;
            m_PlayingCard2 = null;

            waitOneSecond();
            m_PlayingCard1 = m_Player2.PickCard(m_Board);
            waitOneSecond();
            m_PlayingCard2 = m_Player2.PickCard(m_Board);
            waitOneSecond();

            bool isSuccessful = isSuccessfulMove();
            if (!isSuccessful)
            {
                undoMove();
            }

            return isSuccessful;
        }

        private void undoMove()
        {
            m_Board.FlipCardDownWards(m_PlayingCard1);
            m_Board.FlipCardDownWards(m_PlayingCard2);
        }

        private void waitOneSecond()
        {
            Update();
            Thread.Sleep(k_Second);
        }

        private bool isSuccessfulMove()
        {
            bool isSuccessfulMove = m_PlayingCard1.CompareTo(m_PlayingCard2);

            return isSuccessfulMove;
        }

        private void switchTurn()
        {
            m_Turn = (m_Turn == eTurns.Player1) ? eTurns.Player2 : eTurns.Player1;
            m_PlayingUserInterfacePlayer = (m_Turn == eTurns.Player1) ? m_Player1 : m_Player2;
            PlayingPlayerName.Text = $@"Current Player: {m_PlayingUserInterfacePlayer.Name}";
            PlayingPlayerName.BackColor = m_PlayingUserInterfacePlayer.Color;
        }

        private string setWinner()
        {
            string winnerMessage;

            if (m_Player1.Score == m_Player2.Score)
            {
                winnerMessage = k_TieMessage;
            }
            else
            {
                string winnerName = m_Player1.Score > m_Player2.Score
                                       ? m_Player1.Name
                                       : m_Player2.Name;
                winnerMessage = $@"{winnerName} wins!";
            }

            string resultString = string.Format($@"{winnerMessage}
{m_Player1.Name}: {m_Player1.Score} Pairs     {m_Player2.Name}: {m_Player2.Score} Pairs
{k_Replay}");

            return resultString;
        }

        private enum eTurns
        {
            Player1,
            Player2
        }
    }
}
