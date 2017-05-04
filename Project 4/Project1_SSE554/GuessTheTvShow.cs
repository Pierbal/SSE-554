using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Project1_SSE554
{
    public partial class GuessTheTvShow : Form
    {
        int correct = 0;
        int counter =0;
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        string guess;
        string[] mp3s = { "Avatar The Last Airbender","Batman", "Code Lyoko", "Codename Kids Next Door", "Danny Phantom", "Dexter's Laboratory","Drake and Josh",
            "Fairly Odd Parents", "Foster's Home for Imaginary Friends","Jimmy Neutron", "Kim Possible","Lilo and Stitch", "Pokemon", "Powerpuff Girls", "Recess",
            "Rocket Power", "Samurai Jack", "Scooby Doo", "SpongeBob SquarePants", "Teen Titans", "The Fresh Prince Of Bel Air","The Magic School Bus" };
        public GuessTheTvShow()
        {
            InitializeComponent();
            randomNumberGenerator();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           player.controls.stop();
            timer1.Enabled = false;

            player.URL = @"C:\Users\Pierre\Documents\School\Spring 2017\SSE 554\Project 4\Project1_SSE554\Project1_SSE554\MP3\" + mp3s[counter] + ".mp3";
            
            player.controls.play();
            timer1.Enabled = true;
            /*string path = "..\test.txt";
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\..\MP3\test.txt");
            file.WriteLine("");

            file.Close();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            double stopTime = 15;
            if (stopTime <= player.controls.currentPosition)
            {
                player.controls.stop();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            player.controls.stop();
            button1.Enabled = false;
            button2.Enabled = false;
            if (radioButton1.Checked)
                guess = radioButton1.Text;
            else if (radioButton2.Checked)
                guess = radioButton2.Text;
            else if (radioButton3.Checked)
                guess = radioButton3.Text;
            else
                guess = radioButton4.Text;

            guess = (guess).ToLower();
            string answer = (mp3s[counter]).ToLower();
            if (guess == answer)
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
                button2.Enabled = true;
                button3.Visible = false;
                textBox2.Text = "";
                randomNumberGenerator();
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
        
        public void randomNumberGenerator()
        {
            var rnd = new Random();
            int temp = 0;
            int[] answers = new int[4];
            Random rnd1 = new Random();
            int correctAnswer = rnd1.Next(1, 5);
            List<int> randomNumbers = Enumerable.Range(0, mp3s.Length-1).OrderBy(x => rnd.Next()).Take(4).ToList();

            foreach (int length in randomNumbers)
            {
                if(temp+1 == correctAnswer)
                {
                    answers[temp] = counter;
                }
                else if(counter == length)
                {
                    answers[temp] = length + correctAnswer;
                }
                else
                {
                    answers[temp] = length;
                }
                temp++;
                //MessageBox.Show(length.ToString());
            }

            radioButton1.Text = mp3s[answers[0]];
            radioButton2.Text = mp3s[answers[1]];
            radioButton3.Text = mp3s[answers[2]];
            radioButton4.Text = mp3s[answers[3]];
        }
    }
}
