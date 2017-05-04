using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Project1_SSE554
{
    public partial class ChooseNumOfGames : Form
    {
        List<Thread> threads = new List<Thread>();
        public ChooseNumOfGames()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread1;
            int select = Convert.ToInt32(comboBox2.SelectedItem);
            for(int i=0; i<select; i++)
            {
                thread1 = new Thread(callChooseGameType);
                threads.Add(thread1);
            }
            this.Hide();
            
            for (int i = 0; i < select; i++)
            {
                threads.ElementAt(i).Start();
                Thread.Sleep(2);
            }

        }
        private void callChooseGameType()
        {
            ChooseGameType type = new ChooseGameType();
            type.Show();
        }
    }
}
