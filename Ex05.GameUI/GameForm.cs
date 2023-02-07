using Othello_Game_CSharp;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Ex05.GameUI
{
    public partial class GameForm : Form
    {
        private const eCellState k_Black = eCellState.Black;
        private const eCellState k_White = eCellState.White;
        private const int k_PictureBoxSize = 50;
        private readonly int r_BoardSize;
        private readonly Image r_YellowCoin = Properties.Resources.CoinYellow;
        private readonly Image r_RedCoin = Properties.Resources.CoinRed;
        private int m_BlackNumOfWins;
        private int m_WhiteNumOfWins;
        private bool m_IsAgainstComputer;
        private OthelloGame m_OthelloGame;
        private PictureBoxBoard[,] m_PictureBoxBoard;
        private Player m_CurrentPlayer;
        private Random m_ComputerRandomMove;

        public GameForm(int i_GameBoardSize, bool i_IsAgainstComputer)
        {
            InitializeComponent();

            r_BoardSize = i_GameBoardSize;
            m_IsAgainstComputer = i_IsAgainstComputer;
            m_BlackNumOfWins = 0;
            m_WhiteNumOfWins = 0;
            m_ComputerRandomMove = new Random();

            buildPictureBoxBoard();

            this.Height = (r_BoardSize * k_PictureBoxSize) + 70;
            this.Width = (r_BoardSize * k_PictureBoxSize) + 50;

            startNewGame();
        }

        public Player CurrentPlayer
        {
            get { return m_CurrentPlayer; }
            set { m_CurrentPlayer = value; }
        }

        public int BlackNumOfWins
        {
            get { return m_BlackNumOfWins; }
            set { m_BlackNumOfWins = value; }
        }

        public int WhiteNumOfWins
        {
            get { return m_WhiteNumOfWins; }
            set { m_WhiteNumOfWins = value; }
        }

        public bool IsAgainstComputer
        {
            get { return m_IsAgainstComputer; }
            set { m_IsAgainstComputer = value; }
        }

        private void startNewGame()
        {
            Player[] playersArray = new Player[2];

            playersArray[0] = new Player("Red", k_Black);
            playersArray[1] = m_IsAgainstComputer ? new Player("Computer", k_White) : new Player("Yellow", k_White);

            CurrentPlayer = playersArray[0];
            m_OthelloGame = new OthelloGame(r_BoardSize, m_IsAgainstComputer, playersArray);

            displayBoard();
            playGame();
        }

        private void playGame()
        {
            setValidMoves();

            this.Text = $"Othello - {CurrentPlayer.PlayerName}'s turn";

            if (m_OthelloGame.HasValidMoves(m_OthelloGame.PlayersArray[0]) || m_OthelloGame.HasValidMoves(m_OthelloGame.PlayersArray[1]))
            {
                if (hasValidMoveForCurrentPlayer())
                {
                    if (CurrentPlayer.PlayerName == "Computer")
                    {
                        displayBoard();
                        makeComputerMove();
                    }
                }
                else
                {
                    setValidMoves();
                }
            }
            else
            {
                getWinner();
            }
        }

        private void buttonPictureBox_Click(object sender, EventArgs e)
        {
            PictureBoxBoard selectedMove = sender as PictureBoxBoard;
            makePlayerMove(selectedMove);
        }

        private void buildPictureBoxBoard()
        {
            int left = 15;
            int top = 15;
            m_PictureBoxBoard = new PictureBoxBoard[r_BoardSize, r_BoardSize];

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_PictureBoxBoard[i, j] = createPictureBox(i, j, left, top);
                    this.Controls.Add(m_PictureBoxBoard[i, j]);
                    left += k_PictureBoxSize;
                }

                top += k_PictureBoxSize;
                left = 15;
            }
        }

        private void makeComputerMove()
        {
            Update();
            Thread.Sleep(1000);
            m_OthelloGame.GetValidMoves(m_CurrentPlayer);

            int randomIndex = m_ComputerRandomMove.Next(0, m_OthelloGame.ValidMoves.Count);

            m_OthelloGame.MakeMove(m_OthelloGame.PlayersArray[1], m_OthelloGame.ValidMoves[randomIndex]);
            switchPlayer();
            playGame();
        }

        private void makePlayerMove(PictureBoxBoard i_PictureBoxSelected)
        {
            string move = string.Empty;
            move += Convert.ToChar(i_PictureBoxSelected.Col + 'A');
            move += (i_PictureBoxSelected.Row + 1).ToString();
            m_OthelloGame.MakeMove(m_CurrentPlayer, move);
            switchPlayer();
            playGame();
        }

        private void switchPlayer()
        {
            CurrentPlayer = CurrentPlayer.PlayerName == "Red" ? m_OthelloGame.PlayersArray[1] : m_OthelloGame.PlayersArray[0];
        }
        
        private PictureBoxBoard createPictureBox(int i_Row, int i_Col, int i_Left, int i_Top)
        {
            PictureBoxBoard pictureBoxButton = new PictureBoxBoard();
            pictureBoxButton.Height = k_PictureBoxSize;
            pictureBoxButton.Width = k_PictureBoxSize;
            pictureBoxButton.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxButton.BorderStyle = BorderStyle.Fixed3D;
            pictureBoxButton.Row = i_Row;
            pictureBoxButton.Col = i_Col;
            pictureBoxButton.Left = i_Left;
            pictureBoxButton.Top = i_Top;

            return pictureBoxButton;
        }

        private void displayBoard()
        {
            clearBoard();

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (m_OthelloGame.Board.Board[i, j] == k_White)
                    {
                        m_PictureBoxBoard[i, j].Image = r_YellowCoin;
                    }
                    else if (m_OthelloGame.Board.Board[i, j] == k_Black)
                    {
                        m_PictureBoxBoard[i, j].Image = r_RedCoin;
                    }
                    else
                    {
                        continue;
                    }

                    m_PictureBoxBoard[i, j].Enabled = true;
                }
            }
        }

        private void resetBoardClicks()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_PictureBoxBoard[i, j].Click -= new EventHandler(this.buttonPictureBox_Click);
                }
            }
        }

        private void setValidMoves()
        {
            m_OthelloGame.GetValidMoves(m_CurrentPlayer);
            resetBoardClicks();
            displayBoard();

            foreach (string move in m_OthelloGame.ValidMoves)
            {
                int row = int.Parse(move[1].ToString()) - 1;
                if (move.Length > 2)
                {
                    row = (row * 10) + int.Parse(move[2].ToString()) - 1;
                }

                int col = move[0] - 'A';

                m_PictureBoxBoard[row, col].Enabled = true;
                m_PictureBoxBoard[row, col].BackColor = Color.MediumSeaGreen;
                m_PictureBoxBoard[row, col].Click += new EventHandler(this.buttonPictureBox_Click);
            }
        }

        private void clearBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    m_PictureBoxBoard[i, j].Enabled = false;
                    m_PictureBoxBoard[i, j].BackColor = Color.LightGray;
                    m_PictureBoxBoard[i, j].Image = null;
                }
            }
        }

        private bool hasValidMoveForCurrentPlayer()
        {
            bool hasValidMove = true;

            if (!m_OthelloGame.HasValidMoves(CurrentPlayer))
            {
                MessageBox.Show($"No valid moves for {CurrentPlayer.PlayerName}! Switching turns...");
                switchPlayer();

                this.Text = $"Othello - {CurrentPlayer.PlayerName}'s turn";

                if (CurrentPlayer.PlayerName == "Computer")
                {
                    displayBoard();
                    makeComputerMove();
                }

                hasValidMove = false;
            }

            return hasValidMove;
        }

        private void getWinner()
        {
            if (m_OthelloGame.PlayersArray[0].Score > m_OthelloGame.PlayersArray[1].Score)
            {
                BlackNumOfWins++;
                getWinnerMessage(m_OthelloGame.PlayersArray[0]);
            }
            else if (m_OthelloGame.PlayersArray[0].Score < m_OthelloGame.PlayersArray[1].Score)
            {
                WhiteNumOfWins++;
                getWinnerMessage(m_OthelloGame.PlayersArray[1]);
            }
            else
            {
                getTieMessage();
            }
        }

        private void getWinnerMessage(Player i_Winner)
        {
            string message = string.Format(
@"{0} Won!!! ({1}/{2}) ({3}/{4})
Would you like another round?",
                i_Winner.PlayerName,
                m_OthelloGame.Board.BlackCells,
                m_OthelloGame.Board.WhiteCells,
                m_BlackNumOfWins,
                m_WhiteNumOfWins);

            endGame(message);
        }

        private void getTieMessage()
        {
            string message = string.Format(
@"The game ends in a tie!
Would you like to start another round?");

            endGame(message);
        }

        private void endGame(string i_Message)
        {
            DialogResult result = MessageBox.Show(i_Message, "Othello", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                startNewGame();
            }
            else if (result == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
