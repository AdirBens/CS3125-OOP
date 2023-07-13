using System;
using System.Windows.Forms;
using static GameLogic.GameUtils.Player;

namespace GameGUI
{
    internal partial class FormGameSettings : Form
    {
        private bool m_isSettingsValid = false;
        internal string Player1Name
        {
            get { return textBoxPlayer1.Text; }
        }

        internal string Player2Name
        {
            get { return textBoxPlayer2.Text; }
        }

        internal int BoardSize
        {
            get { return (int) numericBoxCols.Value; }
        }

        internal eStrategy OpponentType
        {
            get { return checkBoxPlayer2.Checked == true ? eStrategy.HumanPlayer : eStrategy.AIPlayer; }
        }

        internal bool IsSettingsValid
        {
            get { return m_isSettingsValid; }
        }

        internal FormGameSettings(int i_MinBoardSize, int i_MaxBoardSize)
        {
            InitializeComponent();
            alignControlsAndLabels(i_MinBoardSize, i_MaxBoardSize);
        }

        private void player2CheckBox_Checked(object sender, EventArgs e)
        {
            OnPlayer2CheckBoxCheckChange(sender);
        }

        private void boardSizeBox_ValueChanged(object sender, EventArgs e)
        {
            OnBoardSizeBoxChange(sender);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            OnStartClicked();
        }

        private void OnPlayer2CheckBoxCheckChange(object sender)
        {
            CheckBox checkBox = (sender as CheckBox);
            
            if (checkBox.Checked == true)
            {
                textBoxPlayer2.Text = string.Empty;
                textBoxPlayer2.Enabled = true;
            }
            else
            {
                textBoxPlayer2.Text = "[ COMPUTER ]";
                textBoxPlayer2.Enabled = false;
            }
        }

        private void OnBoardSizeBoxChange(object sender)
        {
            NumericUpDown currentBox = (sender as NumericUpDown);
            NumericUpDown otherBox = currentBox.Name == "numericBoxRows"? 
                numericBoxCols : numericBoxRows;

            otherBox.Value = currentBox.Value;
        }

        private void OnStartClicked()
        {
            if (isPlayersValid())
            {
                m_isSettingsValid = true;
                Close();
            }
            else
            {
                string message = string.IsNullOrWhiteSpace(Player1Name) ? 
                    UIStrings.k_Player1EmptyNameMessage : UIStrings.k_Player2EmptyNameMessage;

               switch (GuiUtils.ShowErrorDialog(message, UIStrings.k_InvalidFormDialogCaption))
                {
                    case DialogResult.Retry:
                        break;
                    case DialogResult.Cancel:
                        Close();
                        break;
                }
            }
        }

        private bool isPlayersValid()
        {
            bool isPlayersValid = !string.IsNullOrWhiteSpace(textBoxPlayer1.Text);

            if ( checkBoxPlayer2.Checked )
            {
                isPlayersValid &= !string.IsNullOrWhiteSpace(textBoxPlayer2.Text);
            }

            return isPlayersValid;
        }

        private void setBoardSizeLimits(int i_MinBoardSize, int i_MaxBoardSize)
        {
            numericBoxCols.Minimum = i_MinBoardSize;
            numericBoxRows.Minimum = i_MinBoardSize;
            numericBoxCols.Maximum = i_MaxBoardSize;
            numericBoxRows.Maximum = i_MaxBoardSize;
            numericBoxCols.Value = i_MinBoardSize;
            numericBoxRows.Value = i_MinBoardSize;
        }

        private void alignToHorizontalCenter()
        {
            GuiUtils.HorizontalCentralizeObject(this, SettingsTitle);
            GuiUtils.HorizontalCentralizeObject(this, SettingsRules);
            GuiUtils.HorizontalCentralizeObject(this, StartGameButton);
        }

        private void alignControlsAndLabels(int i_MinBoardSize, int i_MaxBoardSize)
        {
            setBoardSizeLimits(i_MinBoardSize, i_MaxBoardSize);
            alignToHorizontalCenter();
        }
    }
}
