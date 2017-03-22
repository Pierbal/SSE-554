using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Project1_SSE554
{
    public partial class Yahtzee : Form
    {
        int Min = 1, Max = 7, singleBonus = 0, grandTotal = 0, timesRolled = 1, firstRoll = 0, rollNumber = 0, bonusCount = 0;
        int[] diceNumbers = new int[5];
        string keep = "";
        Random randNum = new Random();
        List<int> numbersLocked = new List<int>();
        int[] scoresSelected  = new int[13];

        public Yahtzee()
        {
            InitializeComponent();
        }

        private void Dice1_Click(object sender, EventArgs e)
        {
            if(label1.Visible == true)
            {
                label1.Visible = false;
                keep = keep.Replace("1,", "");
            }
            else
            {
                label1.Visible = true;
                keep += "1,";
            }
        }

        private void Dice2_Click(object sender, EventArgs e)
        {
            if (label2.Visible == true)
            {
                label2.Visible = false;
                keep = keep.Replace("2,", "");
            }
            else
            {
                label2.Visible = true;
                keep += "2,";
            }
        }

        private void Dice3_Click(object sender, EventArgs e)
        {
            if (label3.Visible == true)
            {
                label3.Visible = false;
                keep = keep.Replace("3,", "");
            }
            else
            {
                label3.Visible = true;
                keep += "3,";
            }
        }

        private void Dice4_Click(object sender, EventArgs e)
        {
            if (label4.Visible == true)
            {
                label4.Visible = false;
                keep = keep.Replace("4,", "");
            }
            else
            {
                label4.Visible = true;
                keep += "4,";
            }
        }

        private void Dice5_Click(object sender, EventArgs e)
        {
            if (label5.Visible == true)
            {
                label5.Visible = false;
                keep = keep.Replace("5,", "");
            }
            else
            {
                label5.Visible = true;
                keep += "5,";
            }
        }

        private void Role_Click(object sender, EventArgs e)
        {
            rollNumber++;
            if(firstRoll == 0)
            {
                RollDice.Text = "Roll";
                firstRoll++;
                toggleLockUnlock(LockUnlock1, 0);
                toggleLockUnlock(LockUnlock2, 0);
                toggleLockUnlock(LockUnlock3, 0);
                toggleLockUnlock(LockUnlock4, 0);
                toggleLockUnlock(LockUnlock5, 0);
                toggleLockUnlock(LockUnlock6, 0);
                toggleLockUnlock(LockUnlock7, 0);
                toggleLockUnlock(LockUnlock8, 0);
                toggleLockUnlock(LockUnlock9, 0);
                toggleLockUnlock(LockUnlock10, 0);
                toggleLockUnlock(LockUnlock11, 0);
                toggleLockUnlock(LockUnlock12, 0);
                toggleLockUnlock(LockUnlock13, 0);
            }

            roll();

            if(rollNumber==3)
            {
                rollNumber = 1;
                RollDice.Enabled = false;
            }
        }

        public void roll()
        {
            while (wait()) ;
            for (int i = 0; i < diceNumbers.Length; i++)
            {
                if (!(keep.Contains((i + 1).ToString())))
                {
                    diceNumbers[i] = randNum.Next(Min, Max);
                }
            }
            showPictureBox(Dice1, diceNum(diceNumbers[0]));
            showPictureBox(Dice2, diceNum(diceNumbers[1]));
            showPictureBox(Dice3, diceNum(diceNumbers[2]));
            showPictureBox(Dice4, diceNum(diceNumbers[3]));
            showPictureBox(Dice5, diceNum(diceNumbers[4]));
            scoring();
        }

        public void showPictureBox(PictureBox thePicture, string pic)
        {
            thePicture.ImageLocation = pic;
            thePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            thePicture.Refresh();
            thePicture.Visible = true;
        }

        private string diceNum(int num)
        {
            if (num == 1)
                return @"..\..\Images\One.jpg";
            else if (num == 2)
                return @"..\..\Images\Two.jpg";
            else if (num == 3)
                return @"..\..\Images\Three.jpg";
            else if (num == 4)
                return @"..\..\Images\Four.jpg";
            else if (num == 5)
                return @"..\..\Images\Five.jpg";
            else if (num == 6)
                return @"..\..\Images\Six.jpg";
            else
                return "";
        }

        private void scoring()
        {
            int acesS = 0,
                twosS = 0,
                threesS = 0,
                foursS = 0,
                fivesS = 0,
                sixesS = 0,
                threeOfAKindS = 0,
                fourOfAKindS = 0,
                fullHouseS = 0,
                smStraightS = 0,
                lgStraightS = 0,
                yahtzeeS = 0,
                chanceS = 0,
                bonusYahtzeeS = 100;

            for (int i = 0; i < diceNumbers.Length; i++)
            {
                switch (diceNumbers[i])
                {
                    case 1:
                        acesS += diceNumbers[i];
                        break;
                    case 2:
                        twosS += diceNumbers[i];
                        break;
                    case 3:
                        threesS += diceNumbers[i];
                        break;
                    case 4:
                        foursS += diceNumbers[i];
                        break;
                    case 5:
                        fivesS += diceNumbers[i];
                        break;
                    case 6:
                        sixesS += diceNumbers[i];
                        break;
                }

                if (scoresSelected[0] != 1)
                    Aces.Text = acesS.ToString();

                if (scoresSelected[1] != 1)
                    Twos.Text = twosS.ToString();

                if (scoresSelected[2] != 1)
                    Threes.Text = threesS.ToString();

                if (scoresSelected[3] != 1)
                    Fours.Text = foursS.ToString();

                if (scoresSelected[4] != 1)
                    Fives.Text = fivesS.ToString();

                if (scoresSelected[5] != 1)
                    Sixes.Text = sixesS.ToString();

                var dict = new Dictionary<int, int>();

                foreach (var value in diceNumbers)
                {
                    if (dict.ContainsKey(value))
                        dict[value]++;
                    else
                        dict[value] = 1;
                }

                int total = 0;

                foreach (var pair in dict)
                {
                    total += pair.Key * pair.Value;
                }

                int[] threeDice = new int[2];
                int[] twoDice = new int[2];

                foreach (var pair in dict)
                {
                    if (pair.Value >= 3 && twoDice[0] == 1 && twoDice[1] != pair.Key)
                    {
                        fullHouseS = 25;
                    }
                    else if (pair.Value >= 3)
                    {
                        threeOfAKindS = total;
                        threeDice[0] = 1;
                        threeDice[1] = pair.Key;
                    }

                    if (pair.Value >= 4)
                        fourOfAKindS = total;

                    if (pair.Value == 5)
                    {
                        if (bonusCount == 0)
                        {
                            yahtzeeS = 50;
                            bonusCount++;
                        }
                        else
                        {
                            int temp = bonusYahtzeeS * bonusCount;
                            bonusCount++;
                            Bonus2.Text = bonusCount.ToString();
                        }
                    }

                    if (pair.Value >= 2 && threeDice[0] == 1 && threeDice[1] != pair.Key)
                        fullHouseS = 25;
                    else if (pair.Value >= 2)
                    {
                        twoDice[0] = 1;
                        twoDice[1] = pair.Key;
                    }
                }

                int[] sortedCopy = (from element in diceNumbers orderby element ascending select element).ToArray();

                if (sortedCopy[0] == 1)
                    if (sortedCopy[1] == 2)
                        if (sortedCopy[2] == 3)
                            if (sortedCopy[3] == 4)
                            {
                                smStraightS = 30;
                                if (sortedCopy[4] == 5)
                                    lgStraightS = 40;
                            }

                if (sortedCopy[0] == 2)
                    if (sortedCopy[1] == 3)
                        if (sortedCopy[2] == 4)
                            if (sortedCopy[3] == 5)
                            {
                                smStraightS = 30;

                                if (sortedCopy[4] == 6)
                                    lgStraightS = 40;
                            }

                if (sortedCopy[1] == 3)
                    if (sortedCopy[2] == 4)
                        if (sortedCopy[3] == 5)
                            if (sortedCopy[4] == 6)
                                smStraightS = 30;

                chanceS += diceNumbers[i];

                if (scoresSelected[6] != 1)
                    ThreeOfAKind.Text = threeOfAKindS.ToString();

                if (scoresSelected[7] != 1)
                    FourOfAKind.Text = fourOfAKindS.ToString();

                if (scoresSelected[8] != 1)
                    FullHouse.Text = fullHouseS.ToString();

                if (scoresSelected[9] != 1)
                    SmStraight.Text = smStraightS.ToString();

                if (scoresSelected[10] != 1)
                    LgStraight.Text = lgStraightS.ToString();

                if (scoresSelected[11] != 1)
                    Yaht.Text = yahtzeeS.ToString();

                if (scoresSelected[12] != 1)
                    Chance.Text = chanceS.ToString();

            }
        }

        private void Yahtzee_Load(object sender, EventArgs e)
        {

        }

        private void toggleLockUnlock(PictureBox thePicture, int scoreType)
        {
            if (thePicture.ImageLocation == @"..\..\Images\unlock.png")
            {
                thePicture.ImageLocation = @"..\..\Images\lock.png";
                numbersLocked.Add(scoreType);
            }
            else if (scoreType == 0)
            {
                thePicture.ImageLocation = @"..\..\Images\unlock.png";
            }
            else
            {
                thePicture.ImageLocation = @"..\..\Images\unlock.png";
                numbersLocked.Remove(scoreType);
            }

            thePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            thePicture.Refresh();
            thePicture.Visible = true;

        }
 
        private void Submit_Click(object sender, EventArgs e)
        {
            if (numbersLocked.Count == timesRolled)
            {
                if (scoresSelected[0] != 1 && LockUnlock1.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock1.Enabled = false;
                    scoresSelected[0] = 1;
                    singleBonus += Convert.ToInt32(Aces.Text);
                    grandTotal += Convert.ToInt32(Aces.Text);
                }

                if (scoresSelected[1] != 1 && LockUnlock2.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock2.Enabled = false;
                    scoresSelected[1] = 1;
                    singleBonus += Convert.ToInt32(Twos.Text);
                    grandTotal += Convert.ToInt32(Twos.Text);
                }

                if (scoresSelected[2] != 1 && LockUnlock3.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock3.Enabled = false;
                    scoresSelected[2] = 1;
                    singleBonus += Convert.ToInt32(Threes.Text);
                    grandTotal += Convert.ToInt32(Threes.Text);
                }

                if (scoresSelected[3] != 1 && LockUnlock4.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock4.Enabled = false;
                    scoresSelected[3] = 1;
                    singleBonus += Convert.ToInt32(Fours.Text);
                    grandTotal += Convert.ToInt32(Fours.Text);
                }

                if (scoresSelected[4] != 1 && LockUnlock5.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock5.Enabled = false;
                    scoresSelected[4] = 1;
                    singleBonus += Convert.ToInt32(Fives.Text);
                    grandTotal += Convert.ToInt32(Fives.Text);
                }

                if (scoresSelected[5] != 1 && LockUnlock6.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock6.Enabled = false;
                    scoresSelected[5] = 1;
                    singleBonus += Convert.ToInt32(Sixes.Text);
                    grandTotal += Convert.ToInt32(Sixes.Text);
                }

                if (scoresSelected[6] != 1 && LockUnlock7.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock7.Enabled = false;
                    scoresSelected[6] = 1;
                    grandTotal += Convert.ToInt32(ThreeOfAKind.Text);
                }

                if (scoresSelected[7] != 1 && LockUnlock8.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock8.Enabled = false;
                    scoresSelected[7] = 1;
                    grandTotal += Convert.ToInt32(FourOfAKind.Text);
                }

                if (scoresSelected[8] != 1 && LockUnlock9.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock9.Enabled = false;
                    scoresSelected[8] = 1;
                    grandTotal += Convert.ToInt32(FullHouse.Text);
                }

                if (scoresSelected[9] != 1 && LockUnlock10.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock10.Enabled = false;
                    scoresSelected[9] = 1;
                    grandTotal += Convert.ToInt32(SmStraight.Text);
                }

                if (scoresSelected[10] != 1 && LockUnlock11.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock11.Enabled = false;
                    scoresSelected[10] = 1;
                    grandTotal += Convert.ToInt32(LgStraight.Text);
                }

                if (scoresSelected[11] != 1 && LockUnlock12.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock12.Enabled = false;
                    scoresSelected[11] = 1;
                    grandTotal += Convert.ToInt32(Yaht.Text);
                }

                if (scoresSelected[12] != 1 && LockUnlock12.ImageLocation == @"..\..\Images\lock.png")
                {
                    LockUnlock13.Enabled = false;
                    scoresSelected[12] = 1;
                    grandTotal += Convert.ToInt32(Chance.Text);
                }

                if (singleBonus >= 63)
                    Bonus1.Text = "35";

                timesRolled++;
                RollDice.Enabled = true;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                keep = "";
                finish();
                label18.Text = "Pre";
                while (wait())
                    label18.Text = "Waiting";
                label18.Text = "Done";
                roll();


            }
            else if (numbersLocked.Count == 13)
            {
                if (Bonus1.Text != "")
                    grandTotal += Convert.ToInt32(Bonus1.Text);

                if (Bonus2.Text != "")
                    grandTotal += Convert.ToInt32(Bonus2.Text);
            }
            else
            {
                MessageBox.Show("Please select ONE score to write down", "Play Again", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock1, 1);
        }

        private void LockUnlock2_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock2, 2);
        }

        private void LockUnlock3_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock3, 3);
        }

        private void LockUnlock4_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock4, 4);
        }

        private void LockUnlock5_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock5, 5);
        }

        private void LockUnlock6_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock6, 6);
        }

        private void LockUnlock7_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock7, 7);
        }

        private void LockUnlock8_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock8, 8);
        }

        private void LockUnlock9_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock9, 69);
        }

        private void LockUnlock10_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock10, 10);
        }

        private void LockUnlock11_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock11, 11);
        }

        private void LockUnlock12_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock12, 12);
        }

        private void LockUnlock13_Click(object sender, EventArgs e)
        {
            toggleLockUnlock(LockUnlock13, 13);
        }
        private void finish()
        {
            using (StreamWriter file = new StreamWriter(@"Z:\sse554-17s\Project3\Balinda\WriteLines2.txt", true))
            {
                file.WriteLine("1");
            }
        }
        private bool wait()
        {
            using (StreamReader file = new StreamReader(@"Z:\sse554-17s\Project3\Balinda\WriteLines2.txt", true))
            {
                string ans = file.ReadLine();
                label17.Text = "Wait Method";
                return ans == "0";

            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

    }
}
