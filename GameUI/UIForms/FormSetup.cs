using System;
using System.Drawing;
using System.Windows.Forms;
using B20_Ex02_Shir_315396283_Shachar_207642091.GameLogic;

namespace GameUI
{
    public partial class FormSetup : Form
    {
        private const string k_MissingFieldsMessage = "Some fields are missing!";
        private const string k_ErrorTitle = "Error";
        private const string k_ComputerName = "-computer-";
        private const string k_AgainstComputerMessage = "Against Computer";
        private const string k_AgainstFriendMessage = "Against a Friend";
        private bool m_IsComputerMode = true;

        public FormSetup()
        {
            InitializeComponent();
            Settings = new GameSettings();
        }

        public GameSettings Settings { get; }

        protected override void OnLoad(EventArgs i_EventArgs)
        {
            base.OnLoad(i_EventArgs);
            BoardDimensionsButton.Text = BoardDimensionsButton.Text = $@"{Settings.BoardHeight} X {Settings.BoardWidth}";
        }

        private void PlayModeButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            Player2NameTextBox.ReadOnly = !Player2NameTextBox.ReadOnly;
            Player2NameTextBox.Text = Player2NameTextBox.ReadOnly ? k_ComputerName : string.Empty;
            Player2NameTextBox.Enabled = !Player2NameTextBox.Enabled;
            m_IsComputerMode = !m_IsComputerMode;
            ((Button)i_Sender).Text = m_IsComputerMode ? k_AgainstFriendMessage : k_AgainstComputerMessage;
        }

        private void BoardDimensionsButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            Settings.UpdateDimensions();
            BoardDimensionsButton.Text = $@"{Settings.BoardHeight} X {Settings.BoardWidth}";
        }

        private void StartButton_Click(object i_Sender, EventArgs i_EventArgs)
        {
            bool isFieldsNotEmpty = !string.IsNullOrEmpty(Player1NameTextBox.Text)
                                    && !string.IsNullOrWhiteSpace(Player1NameTextBox.Text)
                                    && !string.IsNullOrEmpty(Player2NameTextBox.Text)
                                    && !string.IsNullOrWhiteSpace(Player2NameTextBox.Text);
            if (isFieldsNotEmpty)
            {
                Settings.Player1.Name = Player1NameTextBox.Text;
                Settings.Player1.PlayerType = Player<Image>.ePlayerType.Human;
                Settings.Player2.Name = Player2NameTextBox.Text;
                Settings.Player2.PlayerType = m_IsComputerMode ? Player<Image>.ePlayerType.Computer : Player<Image>.ePlayerType.Human;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(k_MissingFieldsMessage, k_ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
