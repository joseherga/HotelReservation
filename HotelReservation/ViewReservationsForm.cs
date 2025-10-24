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
    public partial class ViewReservationsForm : Form
    {
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        SqlCommand cmd;
        public ViewReservationsForm(string currentUser )
        {
            InitializeComponent();
        }

        private void ViewReservationsForm_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainMenuForm mm = new MainMenuForm();
            mm.Show();
            this.Hide();
        }
    }
}
