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
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=hotel_db;Integrated Security=True");
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
            cmd = new SqlCommand("INSERT into UserInfo VALUES(@Username,@Password,@Fullname,@Lastname)", con);
            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Fullname", txtFirstname.Text);
            cmd.Parameters.AddWithValue("@Lastname", txtLastname.Text);
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
    }
}
