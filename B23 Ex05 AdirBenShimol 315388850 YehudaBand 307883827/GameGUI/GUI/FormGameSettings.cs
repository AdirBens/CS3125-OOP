using System;
using System.Windows.Forms;

namespace GameGUI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        public string Player1Name
        {
            get { return textBoxPlayer1.Text; }
        }

        public string Player2Name
        {
            get { return textBoxPlayer2.Text; }
        }

        public int BoardNumRows
        {
            get { return (int) numericBoxRows.Value; }
        }

        public int BoardNumCols
        {
            get { return (int) numericBoxCols.Value; }
        }

        private void player2CheckBox_Check(object sender, EventArgs e)
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
                // TODO: need to send data to LOGIC
                this.Close();
            }
        }


        // TODO: Change validation to Events (need to read officDocs)
        private bool isFormValid()
        {
            bool isFormValid = isBoardSizeValid();

            isFormValid &= isPlayersValid();
            
            return isFormValid;
        }

        private bool isBoardSizeValid()
        {
            bool isBoardSizeValid = numericBoxRows.Value == numericBoxCols.Value;
            
            isBoardSizeValid &=  numericBoxCols.Value >= 4 && numericBoxCols.Value <= 10;

            return isBoardSizeValid;
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

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }

        private void PlayersBox_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxPlayer2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
