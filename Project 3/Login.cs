using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Project1_SSE554
{
    public partial class Login: Form
    {
        List<user> roaster = new List<user>();
        public Login()
        {
            InitializeComponent();

            string strAccessConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Db.mdb";

            string strAccessSelect = "SELECT * FROM Users";

            // Create the dataset and add the Users table to it:
            DataSet myDataSet = new DataSet();
            OleDbConnection myAccessConn = null;
            try
            {
                myAccessConn = new OleDbConnection(strAccessConn);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                return;
            }

            try
            {

                OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
                OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);

                myAccessConn.Open();
                myDataAdapter.Fill(myDataSet, "Users");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve the required data from the DataBase.\n{0}", ex.Message);
                return;
            }
            finally
            {
                myAccessConn.Close();
            }
            DataRowCollection dra = myDataSet.Tables["Users"].Rows;


            foreach (DataRow dr in dra)
            {
                string name = dr[0].ToString();
                string pass = dr[1].ToString();
                string email = dr[2].ToString();
                int code = 00;// Convert.ToInt32(dr[3].ToString());

                DateTime date = DateTime.Today;
                user temp = new user(name, pass, email, code, date);
                roaster.Add(temp);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (user x in roaster)
            {
                if(LoginUsrName.Text == x.getUsrName() && textBox2.Text == x.getPass())
                {
                    ChooseGameType selection = new ChooseGameType();
                    selection.Show();
                    this.Hide();
                }
            }
            label7.Visible = true;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp selection = new SignUp();
            selection.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
