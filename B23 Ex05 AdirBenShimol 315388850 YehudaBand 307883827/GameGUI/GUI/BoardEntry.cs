using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameGUI.GUI
{
    internal class BoardEntry : Button
    {
        private const int k_Size = 64;
        private const int k_Margin = 10;

        public BoardEntry(int i_Row, int i_Col)
        {
            Width = k_Size;
            Height = k_Size;
            setEntryLocation(i_Row, i_Col);
            setEntryStyle();
        }

        private void setEntryLocation(int i_Row, int i_Col)
        {
            int entryTop = i_Row * (k_Size + k_Margin) + k_Margin;
            int entryStart = i_Col * (k_Size + k_Margin) + k_Margin;

            Location = new Point(entryTop, entryStart); ;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (Text == string.Empty)
            {
                Text = "X";
            }
        }

        private void setEntryStyle()
        {
            Color textColor = Color.RoyalBlue;

            Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TextAlign = ContentAlignment.MiddleCenter;
            ForeColor = textColor;
        }
    }
}
