using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project1_SSE554
{
    public partial class GuessTheTvShow : Form
    {
        int correct = 0;
        int counter =0;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        string[] mp3s = { "Code Lyoko", "Danny Phantom",  "Fairly Odd Parents", "Kim Possible", "Pokemon"};
        public GuessTheTvShow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            timer1.Enabled = false;

            player.URL = @"C:\Users\Daniel\documents\visual studio 2015\Projects\Project1_SSE554\Project1_SSE554\MP3\" + mp3s[counter] + ".mp3";
            player.controls.play();
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double stopTime = 15;
            if (stopTime <= player.controls.currentPosition)
            {
                player.controls.stop();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            player.controls.stop();
            button1.Enabled = false;
            button2.Enabled = false;
            string guess = (textBox1.Text).ToLower();
            string answer = (mp3s[counter]).ToLower();
            if(guess == answer)
            {
                textBox2.Text = "CORRECT";
                correct++;
            }
            else
            {
                textBox2.Text = "INCORRECT - the correct answer was " + mp3s[counter];
            }
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (counter < mp3s.Length-1)
            {
                counter++;
                button1.Enabled = true;
                button3.Visible = false;
                button2.Enabled = true;
                textBox2.Text = "";
                textBox1.Text = "";
            }
            else
            {
                textBox2.Text = "Finished";
                textBox2.ForeColor = Color.Black;
                button3.Visible = false;
                textBox3.Visible = true;
                textBox3.Text = "You got " + correct.ToString() + " out of " + mp3s.Length.ToString() +" correct";
                button4.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GuessTheTvShow selection = new GuessTheTvShow();
            selection.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChooseGameType again = new ChooseGameType();
            again.Show();
            this.Hide();
        }
    }
}
