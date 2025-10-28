using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class MainMenuForm : Form
    {
        static CallDatabase callDatabase = new CallDatabase();
        SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath());
        SqlCommand cmd;

        string currentUser = "";
        public MainMenuForm()
        {
            InitializeComponent();
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
            BookingDetailsForm bd = new BookingDetailsForm();
            bd.Show();
            this.Hide();
        }
    }
}
