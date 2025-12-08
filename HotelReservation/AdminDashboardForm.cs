using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class AdminDashboardForm : Form
    {
        // Static reference to CallDatabase class for connection string
        static CallDatabase cd = new CallDatabase();

        // SQL connection object using the database path
        SqlConnection con = new SqlConnection(cd.GetDatabasePath());

        // Command object placeholder for executing SQL queries
        SqlCommand cmd;

        // References to child forms so we can reuse them instead of opening duplicates
        BookingDetailsForm bookingDetails;
        ViewReservationsForm viewReservations;
        ManageRoomForm manageRoom;

        // Track the current user (not yet used, but ready for role-based logic)
        string currentUser = "";

        public AdminDashboardForm()
        {
            InitializeComponent(); // Initialize all UI components
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            // Marks this form as an MDI container so multiple child forms can open inside it
            this.IsMdiContainer = true;
        }

        private void btnViewReservations_Click(object sender, EventArgs e)
        {
            // Open the ViewReservationsForm only if it’s not already open
            if (viewReservations == null || viewReservations.IsDisposed)
            {
                viewReservations = new ViewReservationsForm();
                viewReservations.FormClosed += viewReservations_Closed; // Reset reference when closed
                viewReservations.MdiParent = this; // Attach as child form
                viewReservations.Show();
            }
            else
            {
                // If already open, bring it to front and restore if minimized
                viewReservations.WindowState = FormWindowState.Normal;
                viewReservations.BringToFront();
                viewReservations.Activate();
            }
        }

        private void viewReservations_Closed(object sender, FormClosedEventArgs e)
        {
            // Clear reference when the form is closed so it can be reopened later
            viewReservations = null;
        }

        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            // Open the BookingDetailsForm only if it’s not already open
            if (bookingDetails == null || bookingDetails.IsDisposed)
            {
                bookingDetails = new BookingDetailsForm();
                bookingDetails.FormClosed += bookingDetails_Closed; // Reset reference when closed
                bookingDetails.MdiParent = this; // Attach as child form
                bookingDetails.Show();
            }
            else
            {
                // If already open, bring it to front and restore if minimized
                bookingDetails.WindowState = FormWindowState.Normal;
                bookingDetails.BringToFront();
                bookingDetails.Activate();
            }
        }

        private void bookingDetails_Closed(object sender, FormClosedEventArgs e)
        {
            // Clear reference when the form is closed so it can be reopened later
            bookingDetails = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Confirm logout with a Yes/No message box
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // If confirmed, show the LoginForm and hide the current dashboard
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            // Open the ManageRoomForm only if it’s not already open
            if (manageRoom == null || manageRoom.IsDisposed)
            {
                manageRoom = new ManageRoomForm();
                manageRoom.FormClosed += manageRoom_Closed; // Reset reference when closed
                manageRoom.MdiParent = this; // Attach as child form
                manageRoom.Show();
            }
            else
            {
                // If already open, bring it to front and restore if minimized
                manageRoom.WindowState = FormWindowState.Normal;
                manageRoom.BringToFront();
                manageRoom.Activate();
            }
        }

        private void manageRoom_Closed(object sender, FormClosedEventArgs e)
        {
            // Clears reference when the form is closed so it can be reopened later
            manageRoom = null;
        }
    }
}