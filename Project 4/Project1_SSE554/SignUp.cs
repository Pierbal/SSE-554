using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Data;

namespace Project1_SSE554
{
    public partial class SignUp : Form
    {
        string VerificationCode;

        public SignUp()
        {
            InitializeComponent();
            Random rnd1 = new Random();
            int holder = rnd1.Next(1000, 9999);
            VerificationCode = holder.ToString();
            dateTimePicker1.MaxDate = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login selection = new Login();
            selection.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool noErrors = check();
            if (!noErrors) { 
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
                conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=.\Db.mdb";

                try
                {
                    conn.Open();

                    String my_querry = "INSERT INTO Users (Username,Pass,Email,Birthday) VALUES('" + textBox1.Text + "','" + textBox2.Text +
                                    "','" + textBox4.Text + "','" + dateTimePicker1.Text + "')";
                    OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private bool check()
        {
            bool check = false;

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Some or all fields have not been inputted");
                check = true;
            }
            if (textBox2.Text != textBox3.Text)
            {
                label7.Visible = true;
                check = true;
            }
            if (textBox5.Text != VerificationCode)
            {
                label8.Visible = true;
                check = true;
            }
            bool usernameUsed = CheckUsername();
            if(CheckUsername())
            {
                label10.Visible = true;
                check = true;
            }
            return check;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (IsValidEmail(textBox4.Text))
            {
                MailMessage mail = new MailMessage();
                SmtpClient server = new SmtpClient("smtp.mail.yahoo.com");
                mail.From = new MailAddress("gameserver227@yahoo.com");
                mail.To.Add(textBox4.Text);
                mail.Subject = "Verification Code";
                mail.Body = "Your Code is: " + VerificationCode;
                server.Port = 587;
                server.Credentials = new System.Net.NetworkCredential("gameserver227", "Password#123");
                server.EnableSsl = true;
                server.Send(mail);
                MessageBox.Show("Message Sent");
            }
            else
                label9.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        public void download()
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source=.\Db.mdb";

            try
            {
                conn.Open();

                String my_querry = "INSERT INTO Users (Username,Pass,Email,Code,Birthday) VALUES('" + textBox1.Text + "','" + textBox2.Text +
                                "','" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "')";
                OleDbCommand cmd = new OleDbCommand(my_querry, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed due to" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool CheckUsername()
        {
            //bool checkName = true;

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
                return true;
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
                return true;
            }
            finally
            {
                myAccessConn.Close();
            }
            DataRowCollection dra = myDataSet.Tables["Users"].Rows;


            foreach (DataRow dr in dra)
            {
                string name = dr[0].ToString();
                
                if(name == textBox1.Text)
                {
                    return true;
                }

            }

            return false;
        }
    }
}
