using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class SignupForm : Form
    {
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        SqlCommand cmd;

        LoginForm lg = new LoginForm();
        public SignupForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("INSERT into UserInfo VALUES(@FullName,@Email,@Username,@Password)", con);
            cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("@Username", txtUser.Text);
            cmd.Parameters.AddWithValue("@Password", txtPass.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            lg.Show();
            this.Hide();
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm LoginForm = new LoginForm();
            LoginForm.Show();
            this.Hide();

        }
    }
}
