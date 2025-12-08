using System;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class UserDashboard : Form
    {
        // References to child forms (Booking and Reservations)
        BookingDetailsForm bookingDetails;
        ViewReservationsForm viewReservations;

        // Track whether the side menu panel is expanded or collapsed
        bool menupnlExanded = true;

        // Step size for animation (pixels per tick)
        int StepSize = 10;

        public UserDashboard()
        {
            InitializeComponent(); // Initialize UI components
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            // Enable Multiple Document Interface (MDI) so child forms can open inside dashboard
            this.IsMdiContainer = true;
        }

        private void userMenu_Click(object sender, EventArgs e)
        {
            // Start animation when menu button is clicked
            menuTransition.Start();
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            // Animate menu panel expand/collapse
            if (menupnlExanded)
            {
                menupnl.Width -= StepSize; // Shrink panel
                if (menupnl.Width <= 74)   // Minimum width
                {
                    menupnlExanded = false;
                    menuTransition.Stop();
                }
            }
            else
            {
                menupnl.Width += StepSize; // Expand panel
                if (menupnl.Width >= 220)  // Maximum width
                {
                    menupnlExanded = true;
                    menuTransition.Stop();
                }
            }
        }

        private void btnBookNow_Click(object sender, EventArgs e)
        {
            // Open BookingDetailsForm if not already open
            if (bookingDetails == null || bookingDetails.IsDisposed)
            {
                bookingDetails = new BookingDetailsForm();
                bookingDetails.FormClosed += bookingDetails_Closed; // Reset reference when closed
                bookingDetails.MdiParent = this;                   // Open inside dashboard
                bookingDetails.Show();
            }
            else
            {
                // If already open, bring it to front
                bookingDetails.WindowState = FormWindowState.Normal;
                bookingDetails.BringToFront();
                bookingDetails.Activate();
            }
        }

        private void bookingDetails_Closed(object sender, FormClosedEventArgs e)
        {
            // Reset reference when booking form is closed
            bookingDetails = null;
        }

        private void btnMyReservation_Click(object sender, EventArgs e)
        {
            // Open ViewReservationsForm if not already open
            if (viewReservations == null || viewReservations.IsDisposed)
            {
                viewReservations = new ViewReservationsForm();
                viewReservations.FormClosed += viewReservations_Closed; // Reset reference when closed
                viewReservations.MdiParent = this;                      // Open inside dashboard
                viewReservations.Show();
            }
            else
            {
                // If already open, bring it to front
                viewReservations.WindowState = FormWindowState.Normal;
                viewReservations.BringToFront();
                viewReservations.Activate();
            }
        }

        private void viewReservations_Closed(object sender, FormClosedEventArgs e)
        {
            // Reset reference when reservations form is closed
            viewReservations = null;
        }

        private void btnUserLogout_Click(object sender, EventArgs e)
        {
            // Confirm logout
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Clear current session
                Session.CurrentUser = null;

                // Redirect back to login form
                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }
    }
}