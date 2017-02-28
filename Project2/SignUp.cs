using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Net.Mail;

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login selection = new Login();
            selection.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label7.Text = "";
            if (textBox2.Text != textBox3.Text)
            {
                label7.Text = "Password do not match";
            }
            else
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
                Login login = new Login();
                login.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
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
    }
}
