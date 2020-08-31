namespace GameUI
{
    public partial class FormSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerName = new System.Windows.Forms.Label();
            this.Player2Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BoardDimensionsButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.Player1NameTextBox = new System.Windows.Forms.TextBox();
            this.PlayModeButton = new System.Windows.Forms.Button();
            this.Player2NameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PlayerName
            // 
            this.PlayerName.AutoSize = true;
            this.PlayerName.Location = new System.Drawing.Point(25, 21);
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.Size = new System.Drawing.Size(124, 17);
            this.PlayerName.TabIndex = 0;
            this.PlayerName.Text = "Player First Name:";
            // 
            // Player2Name
            // 
            this.Player2Name.AutoSize = true;
            this.Player2Name.Location = new System.Drawing.Point(25, 49);
            this.Player2Name.Name = "Player2Name";
            this.Player2Name.Size = new System.Drawing.Size(145, 17);
            this.Player2Name.TabIndex = 1;
            this.Player2Name.Text = "Second Player Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Board Size:";
            // 
            // BoardDimensionsButton
            // 
            this.BoardDimensionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BoardDimensionsButton.Location = new System.Drawing.Point(28, 117);
            this.BoardDimensionsButton.Name = "BoardDimensionsButton";
            this.BoardDimensionsButton.Size = new System.Drawing.Size(142, 87);
            this.BoardDimensionsButton.TabIndex = 5;
            this.BoardDimensionsButton.Text = "button1";
            this.BoardDimensionsButton.UseVisualStyleBackColor = false;
            this.BoardDimensionsButton.Click += new System.EventHandler(this.BoardDimensionsButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.StartButton.Location = new System.Drawing.Point(362, 165);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 39);
            this.StartButton.TabIndex = 6;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Player1NameTextBox
            // 
            this.Player1NameTextBox.Location = new System.Drawing.Point(179, 18);
            this.Player1NameTextBox.Name = "Player1NameTextBox";
            this.Player1NameTextBox.Size = new System.Drawing.Size(135, 22);
            this.Player1NameTextBox.TabIndex = 1;
            // 
            // PlayModeButton
            // 
            this.PlayModeButton.Location = new System.Drawing.Point(325, 46);
            this.PlayModeButton.Name = "PlayModeButton";
            this.PlayModeButton.Size = new System.Drawing.Size(137, 29);
            this.PlayModeButton.TabIndex = 4;
            this.PlayModeButton.Text = "Against a Friend";
            this.PlayModeButton.UseVisualStyleBackColor = true;
            this.PlayModeButton.Click += new System.EventHandler(this.PlayModeButton_Click);
            // 
            // Player2NameTextBox
            // 
            this.Player2NameTextBox.Enabled = false;
            this.Player2NameTextBox.HideSelection = false;
            this.Player2NameTextBox.Location = new System.Drawing.Point(179, 49);
            this.Player2NameTextBox.Name = "Player2NameTextBox";
            this.Player2NameTextBox.ReadOnly = true;
            this.Player2NameTextBox.Size = new System.Drawing.Size(135, 22);
            this.Player2NameTextBox.TabIndex = 2;
            this.Player2NameTextBox.Text = "-computer-";
            // 
            // FormSetup
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 222);
            this.Controls.Add(this.Player2NameTextBox);
            this.Controls.Add(this.PlayModeButton);
            this.Controls.Add(this.Player1NameTextBox);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.BoardDimensionsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Player2Name);
            this.Controls.Add(this.PlayerName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Memory Game - Setttings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayerName;
        private System.Windows.Forms.Label Player2Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BoardDimensionsButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox Player1NameTextBox;
        private System.Windows.Forms.Button PlayModeButton;
        private System.Windows.Forms.TextBox Player2NameTextBox;
    }
}