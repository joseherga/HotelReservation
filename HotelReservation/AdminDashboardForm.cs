using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class AdminDashboardForm : Form
    {
        static CallDatabase cd = new CallDatabase();
        SqlConnection con = new SqlConnection(cd.GetDatabasePath());
        SqlCommand cmd;

        BookingDetailsForm bookingDetails;
        ViewReservationsForm viewReservations;
        ManageRoomForm manageRoom;

        string currentUser = "";
        public AdminDashboardForm()
        {
            InitializeComponent();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void btnViewReservations_Click(object sender, EventArgs e)
        {
            if (viewReservations == null || viewReservations.IsDisposed)
            {
                viewReservations = new ViewReservationsForm();
                viewReservations.FormClosed += viewReservations_Closed;
                viewReservations.MdiParent = this;
                viewReservations.Show();
            }
            else
            {
                viewReservations.WindowState = FormWindowState.Normal;
                viewReservations.BringToFront();
                viewReservations.Activate();
            }
        }

        private void viewReservations_Closed(object sender, FormClosedEventArgs e)
        {
            viewReservations = null;
        }

        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            if (bookingDetails == null || bookingDetails.IsDisposed)
            {
                bookingDetails = new BookingDetailsForm();
                bookingDetails.FormClosed += bookingDetails_Closed;
                bookingDetails.MdiParent = this;
                bookingDetails.Show();
            }
            else
            {
                bookingDetails.WindowState = FormWindowState.Normal;
                bookingDetails.BringToFront();
                bookingDetails.Activate();
            }
        }

        private void bookingDetails_Closed(object sender, FormClosedEventArgs e)
        {
            bookingDetails = null;
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            if (manageRoom == null || manageRoom.IsDisposed)
            {
                manageRoom = new ManageRoomForm();
                manageRoom.FormClosed += manageRoom_Closed;
                manageRoom.MdiParent = this;
                manageRoom.Show();
            }
            else
            {
                manageRoom.WindowState = FormWindowState.Normal;
                manageRoom.BringToFront();
                manageRoom.Activate();
            }
        }

        private void manageRoom_Closed(object sender, FormClosedEventArgs e)
        {
            manageRoom = null;
        }
    }
}
