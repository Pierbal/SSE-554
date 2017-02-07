using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project1_SSE554
{
    public partial class GuessTheNumber : Form
    {
        int computerChoice, tries, counter =1;
        GameType chosen = new GameType();

        public GuessTheNumber(int gameChoice, int[] range)
        {
            InitializeComponent();
            comboBox2.SelectedItem = "1-10";
            Random rnd1 = new Random();
            
            computerChoice = rnd1.Next(range[0], range[1]+1);
            
            if (range[1] == 10)
                tries = 3;
            else if (range[1] == 25)
                tries = 7;
            else if (range[1] == 50)
                tries = 15;
            else
                tries = 30;
            textBox3.Text = "Guesses Left - " + (tries).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userInput;

            if(Int32.TryParse(textBox1.Text, out userInput))
            {
                if (userInput < computerChoice && counter < tries)
                {
                    textBox2.Text = "Too Low";
                    counter++;
                    textBox3.Text = "Guesses Left - " + (tries+1-counter).ToString();
                }
                else if (userInput > computerChoice && counter < tries)
                {
                    textBox2.Text = "Too High";
                    counter++;
                    textBox3.Text = "Guesses Left - " + (tries + 1 - counter).ToString();
                }
                else if (counter >= tries)
                {
                    textBox3.Text = "Guesses Left - " + (tries - counter).ToString();
                    textBox2.Text = "Sorry, the number was " + (computerChoice).ToString();
                    button2.Visible = true;
                    comboBox2.Visible = true;
                }
                else
                {
                    textBox2.Text = "Correct!";
                    button1.Enabled = false;
                    button2.Visible = true;
                    comboBox2.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("Please input only numbers");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GuessTheNumber again = new GuessTheNumber(2, chosen.numberRangeChosen(comboBox2.Text));
            again.Show();
            this.Hide();
            counter =1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseGameType again = new ChooseGameType();
            again.Show();
            this.Hide();
        }
    }
}
