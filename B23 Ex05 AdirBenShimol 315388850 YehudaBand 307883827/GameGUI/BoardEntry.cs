using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameGUI
{
    internal class BoardEntry : Button
    {
        private const int k_Size = 64;
        private const int k_Margin = 10;

        public BoardEntry(int i_Row, int i_Col)
        {
            this.Width = k_Size;
            this.Height = k_Size;
            setEntryLocation(i_Row, i_Col);
            setEntryStyle();
        }

        private void setEntryLocation(int i_Row, int i_Col)
        {
            int entryTop = i_Row * (k_Size + k_Margin) + k_Margin;
            int entryStart = i_Col * (k_Size + k_Margin) + k_Margin;
            
            this.Location = new System.Drawing.Point(entryTop, entryStart); ;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.Text == string.Empty)
            {
                this.Text = "X";
            }
        }

        private void setEntryStyle()
        {
            Color textColor = Color.CadetBlue;
            
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ForeColor = textColor;
        }
    }
}
