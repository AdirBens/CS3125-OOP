﻿using static GameLogic.GameUtils.Player;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameGUI.GUI
{
    internal class BoardEntryBtn : Button
    {
        private const int k_Size = 64;
        private const int k_Margin = 10;
        internal int RowIndex
        {
            get; private set;
        }
        
        internal int ColumnIndex
        {
            get; private set;
        }

        public BoardEntryBtn(int i_Row, int i_Col)
        {
            Width = k_Size;
            Height = k_Size;
            RowIndex = i_Row;
            ColumnIndex = i_Col;
            setEntryLocation(i_Row, i_Col);
            setEntryStyle();
        }

        private void setEntryLocation(int i_Row, int i_Col)
        {
            int entryTop = i_Row * (k_Size + k_Margin) + k_Margin;
            int entryStart = i_Col * (k_Size + k_Margin) + k_Margin;

            Location = new Point(entryTop, entryStart); ;
        }

        private void setEntryStyle()
        {
            Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TextAlign = ContentAlignment.MiddleCenter;
            BackColor = Color.GhostWhite;
        }

        internal void HighlightEntry()
        {
            BackColor = Color.LightYellow;
        }

        internal void ResetEntry()
        {
            Text = string.Empty;
            setEntryStyle();
        }

        internal void UpdateEntry(ePlayerSymbol i_PlayerSymbol)
        {
            switch (i_PlayerSymbol)
            {
                case ePlayerSymbol.PlayerOne:
                    ForeColor = Color.RoyalBlue;
                    Text = "X";
                    break;
                case ePlayerSymbol.PlayerTwo:
                    ForeColor = Color.Crimson;
                    Text = "O";
                    break;
                case ePlayerSymbol.Empty: 
                    break;
            }
        }
    }
}
