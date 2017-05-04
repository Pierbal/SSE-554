using System;
using System.Windows.Forms;

namespace Project1_SSE554
{
    public partial class ChooseGameType : Form
    {
        string value;
        GameType chosen = new GameType();

        public ChooseGameType()
        {
            InitializeComponent();
            comboBox2.SelectedItem = "1-10";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (value != null)
            {
                value = value.Replace(" ", "");
                int gameType = chosen.setGameType(value);
                if (gameType == 10)
                    MessageBox.Show("Please Select a Game");
                else if (gameType == 0 || gameType == 1)
                {
                    GameResults selection = new GameResults(gameType);
                    selection.Show();
                    this.Hide();
                }
                else if (gameType == 3)
                {
                    GuessTheTvShow selection = new GuessTheTvShow();
                    selection.Show();
                    this.Hide();
                }
                else if (gameType == 4)
                {
                    Yahtzee selection = new Yahtzee();
                    selection.Show();
                    this.Hide();
                }
                else
                {
                    GuessTheNumber selection = new GuessTheNumber(chosen.numberRangeChosen(comboBox2.Text));
                    selection.Show();
                    this.Hide();
                }
            }
            else
                MessageBox.Show("Please Select a Game");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = true;
            label2.Visible = true;
            value = radioButton3.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label2.Visible = false;
            value = radioButton2.Text;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label2.Visible = false;
            value = radioButton1.Text;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label2.Visible = false;
            value = radioButton4.Text;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            comboBox2.Visible = false;
            label2.Visible = false;
            value = radioButton5.Text;
        }

        private void ChooseGameType_Load(object sender, EventArgs e)
        {

        }
    }
}
