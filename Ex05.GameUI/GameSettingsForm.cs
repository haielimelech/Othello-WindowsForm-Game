using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public partial class GameSettingsForm : Form
    {
        private int m_BoardSize = 6;
        private bool m_IsAgainstComputer = false;

        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public bool IsAgainstComputer
        {
            get { return m_IsAgainstComputer; }
            set { m_IsAgainstComputer = value; }
        }

        public int BoardSize
        {
            get { return m_BoardSize; }
            set { m_BoardSize = value; }
        }

        private void startNewGame()
        {
            this.Hide();
            GameForm newGameForm = new GameForm(BoardSize, IsAgainstComputer);
            newGameForm.ShowDialog();
            this.Close();
        }

        private void buttonBoardSize_Click(object sender, EventArgs e)
        {
            switch (BoardSize)
            {
                case 6:
                    BoardSize = 8;
                    buttonBoardSize.Text = "Board Size : 8x8 (click to increase)";
                    break;
                case 8:
                    BoardSize = 10;
                    buttonBoardSize.Text = "Board Size : 10x10 (click to increase)";
                    break;
                case 10:
                    BoardSize = 12;
                    buttonBoardSize.Text = "Board Size : 12x12 (click to increase)";
                    break;
                case 12:
                    BoardSize = 6;
                    buttonBoardSize.Text = "Board Size : 6x6 (click to increase)";
                    break;
            }
        }

        private void buttonPlayAgainsstTheComputer_Click(object sender, EventArgs e)
        {
            IsAgainstComputer = true;
            startNewGame();
        }

        private void buttonPlayAgainstYourFriend_Click(object sender, EventArgs e)
        {
            startNewGame();
        }
    }
}
