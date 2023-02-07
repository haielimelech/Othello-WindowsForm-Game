using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ex05.GameUI
{
    public class PictureBoxGame : PictureBox
    {
        private int m_Column;
        private int m_Row;

        public int Column
        {
            get { return this.m_Column; }
            set { this.m_Column = value; }
        }

        public int Row
        {
            get { return this.m_Row; }
            set { this.m_Row = value; }
        }

    }
}
