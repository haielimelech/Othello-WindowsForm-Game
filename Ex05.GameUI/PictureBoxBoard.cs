using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public class PictureBoxBoard : PictureBox
    {
        private int m_Col;
        private int m_Row;
        
        public int Col
        {
            get
            {
                return m_Col;
            }
            set
            {
                m_Col = value;
            }
        }

        public int Row
        {
            get
            {
                return m_Row;
            }
            set
            {
                { m_Row = value; }
            }
        }
    }
}
