namespace GameUI
{
    public partial class FormGameBoard
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
            this.PlayingPlayerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PlayingPlayerName
            // 
            this.PlayingPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PlayingPlayerName.AutoSize = true;
            this.PlayingPlayerName.Location = new System.Drawing.Point(13, 331);
            this.PlayingPlayerName.Name = "PlayingPlayerName";
            this.PlayingPlayerName.Size = new System.Drawing.Size(107, 17);
            this.PlayingPlayerName.TabIndex = 0;
            this.PlayingPlayerName.Text = "Current Player: ";
            // 
            // FormGameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlayingPlayerName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameBoard";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Memory Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PlayingPlayerName;
    }
}