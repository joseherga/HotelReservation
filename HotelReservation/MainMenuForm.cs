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
    public partial class MainMenuForm : Form
    {
        private int _userId;
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        SqlCommand cmd;
        public MainMenuForm(int userId = 0)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginForm lg = new LoginForm();
            lg.Show();
            this.Hide();
        }

        private void btnViewReservations_Click(object sender, EventArgs e)
        {
            string currentUser = "";
            ViewReservationsForm vr = new ViewReservationsForm(currentUser);
            vr.Show();
            this.Hide();
        }

        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            BookingDetailsForm bd = new BookingDetailsForm(_userId);
            bd.Show();
            this.Hide();
        }
    }
}
