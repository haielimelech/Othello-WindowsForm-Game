namespace Ex05.GameUI
{
    partial class GameSettingsForm
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
            this.buttonBoardSize = new System.Windows.Forms.Button();
            this.buttonPlayAgainsstTheComputer = new System.Windows.Forms.Button();
            this.buttonPlayAgainstYourFriend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonBoardSize
            // 
            this.buttonBoardSize.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonBoardSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonBoardSize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBoardSize.Location = new System.Drawing.Point(33, 11);
            this.buttonBoardSize.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBoardSize.Name = "buttonBoardSize";
            this.buttonBoardSize.Size = new System.Drawing.Size(416, 80);
            this.buttonBoardSize.TabIndex = 20;
            this.buttonBoardSize.Text = "Board Size : 6x6 (click to increase)";
            this.buttonBoardSize.UseVisualStyleBackColor = true;
            this.buttonBoardSize.Click += new System.EventHandler(this.buttonBoardSize_Click);
            // 
            // buttonPlayAgainsstTheComputer
            // 
            this.buttonPlayAgainsstTheComputer.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonPlayAgainsstTheComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayAgainsstTheComputer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonPlayAgainsstTheComputer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlayAgainsstTheComputer.Location = new System.Drawing.Point(33, 109);
            this.buttonPlayAgainsstTheComputer.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlayAgainsstTheComputer.Name = "buttonPlayAgainsstTheComputer";
            this.buttonPlayAgainsstTheComputer.Size = new System.Drawing.Size(200, 80);
            this.buttonPlayAgainsstTheComputer.TabIndex = 21;
            this.buttonPlayAgainsstTheComputer.Text = "Play Against The Computer";
            this.buttonPlayAgainsstTheComputer.UseVisualStyleBackColor = true;
            this.buttonPlayAgainsstTheComputer.Click += new System.EventHandler(this.buttonPlayAgainsstTheComputer_Click);
            // 
            // buttonPlayAgainstYourFriend
            // 
            this.buttonPlayAgainstYourFriend.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.buttonPlayAgainstYourFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlayAgainstYourFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.buttonPlayAgainstYourFriend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlayAgainstYourFriend.Location = new System.Drawing.Point(247, 109);
            this.buttonPlayAgainstYourFriend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlayAgainstYourFriend.Name = "buttonPlayAgainstYourFriend";
            this.buttonPlayAgainstYourFriend.Size = new System.Drawing.Size(202, 80);
            this.buttonPlayAgainstYourFriend.TabIndex = 22;
            this.buttonPlayAgainstYourFriend.Text = "Play Against Your Friend";
            this.buttonPlayAgainstYourFriend.UseVisualStyleBackColor = true;
            this.buttonPlayAgainstYourFriend.Click += new System.EventHandler(this.buttonPlayAgainstYourFriend_Click);
            // 
            // GameSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 211);
            this.Controls.Add(this.buttonPlayAgainstYourFriend);
            this.Controls.Add(this.buttonPlayAgainsstTheComputer);
            this.Controls.Add(this.buttonBoardSize);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsForm";
            this.Text = "Othello - Game Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBoardSize;
        private System.Windows.Forms.Button buttonPlayAgainsstTheComputer;
        private System.Windows.Forms.Button buttonPlayAgainstYourFriend;
    }
}