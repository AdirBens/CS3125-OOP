using GameLogic.GameUtils;
using System;
using System.Windows.Forms;
using static GameLogic.GameUtils.Player.eStrategy;


namespace GameGUI
{
    internal partial class FormGameSettings : Form
    {
        private bool isSettingsValid = false;
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

        internal Player.eStrategy OpponentType
        {
            get { return checkBoxPlayer2.Checked == true ? HumanPlayer : AIPlayer; }
        }

        internal bool IsSettingsValid
        {
            get { return isSettingsValid; }
        }

        internal FormGameSettings(int i_MinBoardSize, int i_MaxBoardSize)
        {
            InitializeComponent();
            setBoardSizeLimits(i_MinBoardSize, i_MaxBoardSize);
        }

        private void player2CheckBox_Checked(object sender, EventArgs e)
        {
            onPlayer2CheckBoxCheckChange(sender);
        }

        private void boardSizeBox_ValueChanged(object sender, EventArgs e)
        {
            onBoardSizeBoxChange(sender);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            onStartClicked();
        }

        private void onPlayer2CheckBoxCheckChange(object sender)
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

        private void onBoardSizeBoxChange(object sender)
        {
            NumericUpDown currentBox = (sender as NumericUpDown);

            NumericUpDown otherBox = currentBox.Name == "numericBoxRows"? 
                numericBoxCols : numericBoxRows;

            otherBox.Value = currentBox.Value;
        }

        private void onStartClicked()
        {
            if (isFormValid())
            {
                isSettingsValid = true;
                Close();
            }
        }

        // TODO: Change validation to Events (need to read officDocs)
        private bool isFormValid()
        {
            bool isFormValid = isPlayersValid();
            
            return isFormValid;
        }

        private bool isPlayersValid()
        {
            bool isPlayersValid = !string.IsNullOrWhiteSpace(textBoxPlayer1.Text);

            if ( checkBoxPlayer2.Checked )
            {
                isPlayersValid &= !string.IsNullOrWhiteSpace(textBoxPlayer2.Text);
                isPlayersValid &= !textBoxPlayer2.Text.Equals(textBoxPlayer1.Text);
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
    }
}
