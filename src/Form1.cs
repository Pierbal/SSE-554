using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtBox.Text += "7";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtBox.Text += "-";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtBox.Text += "6";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtBox.Text += "2";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtBox.Text += "8";

        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtBox.Text += "9";

        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            txtBox.Text += "/";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtBox.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtBox.Text += "5";
        }

        private void btnMul_Click(object sender, EventArgs e)
        {
            txtBox.Text += "x";
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtBox.Text += "1";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtBox.Text += "3";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtBox.Text += "0";
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtBox.Text += ".";
        }

        private void btnEq_Click(object sender, EventArgs e)
        {
            txtBox.Text += "=";
            double ans = compute();
            txtBox.Text = ans.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtBox.Text += "+";
        }

        public double compute()
        {
            string calc = txtBox.Text;         
            char[] delimiterChars = { 'x', '+', '-', '=', '/' };
            string[] numbers = calc.Split(delimiterChars);
            double num1 = Convert.ToDouble(numbers[0]);
            double num2 = Convert.ToDouble(numbers[1]);
            if (calc.Contains('+'))
                return num1 + num2;
            else if (calc.Contains('-'))
                return num1 - num2;
            else if (calc.Contains('x'))
                return num1 * num2;
            else
                return num1 / num2;

        }
        public int findSign(string calc)
        {
            int index=0;
        
           return index;
        }
    }
}
