using System;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class UserDashboard : Form
    {
        BookingDetailsForm bookingDetails;
        ViewReservationsForm viewReservations;

        bool menupnlExanded = true;
        int StepSize = 10;

        public UserDashboard()
        {
            InitializeComponent();
        }

        private void UserDashboard_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
        }

        private void userMenu_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menupnlExanded)
            {
                menupnl.Width -= StepSize;
                if (menupnl.Width <= 74)
                {
                    menupnlExanded = false;
                    menuTransition.Stop();
                }
            }
            else
            {
                menupnl.Width += StepSize;
                if (menupnl.Width >= 220)
                {
                    menupnlExanded = true;
                    menuTransition.Stop();
                }
            }
        }

        private void btnBookNow_Click(object sender, EventArgs e)
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

        private void btnMyReservation_Click(object sender, EventArgs e)
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


        private void btnUserLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Session.CurrentUser = null;

                LoginForm login = new LoginForm();
                login.Show();
                this.Close();
            }
        }
    }
}
