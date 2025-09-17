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
    public partial class signupCustomer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=dbHotelReserve;Integrated Security=True");
        SqlCommand cmd;

        login lg = new login();
        public signupCustomer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btnReg_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("INSERT into UserInfo VALUES(@Username,@Password,@Fullname)", con);
            cmd.Parameters.AddWithValue("@Username", txtFullname.Text);
            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@Fullname", txtUsername.Text);
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
