using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Othello_Game_CSharp
{
    public class Player
    {
        private const eCellState k_Black = eCellState.Black;
        private const eCellState k_White = eCellState.White;
        private int m_Score;
        private eCellState m_State;
        private string m_PlayerName;

        public Player(string i_Name, eCellState i_Sign)
        {
            m_PlayerName = i_Name;
            m_State = i_Sign;
        }

        public int Score
        {
            get { return m_Score; }
            set { m_Score = value; }
        }

        public eCellState State
        {
            get { return m_State; }
            set { m_State = value; }
        }

        public string PlayerName
        {
            get { return m_PlayerName; }
        }

        public eCellState GetOpponentState()
        {
            return State == k_Black ? k_White : k_Black;
        }
    }
}
