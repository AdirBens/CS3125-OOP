using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGUI
{
    public partial class FormGameBoard : Form
    {
        private BoardEntry[,] m_GameBoard;

        public FormGameBoard(int i_BoardSize)
        {
            m_GameBoard = new BoardEntry[i_BoardSize, i_BoardSize];

            InitializeComponent();
            SetupGameBoard();
        }

        public int BoardSize
        {
            get { return m_GameBoard.GetLength(0) ;  }
        }

        public void SetupGameBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int col = 0; col < BoardSize; col++)
                {
                    m_GameBoard[row, col] = new BoardEntry(row, col);
                    GameBoardPanel.Controls.Add(m_GameBoard[row, col]);
                }
            }
        }

        private void setFormSize()
        {
            
        }
    }
}
