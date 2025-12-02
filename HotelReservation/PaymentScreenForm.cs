using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class PaymentScreenForm : Form
    {
        public string FullName;
        public int Guest;
        public string RoomType;
        public DateTime checkIn;
        public DateTime checkOut;
        public decimal Rate;
        public int RoomID;

        private ViewReservationsForm _viewReservationsForm;
        private Timer autoCloseTimer;
        private int countdownSeconds = 10;

        public PaymentScreenForm(ViewReservationsForm viewReservationsForm = null)
        {
            InitializeComponent();
            _viewReservationsForm = viewReservationsForm;

            // Initialize timer
            autoCloseTimer = new Timer();
            autoCloseTimer.Interval = 1000; // tick every second
            autoCloseTimer.Tick += AutoCloseTimer_Tick;

            // Countdown label is hidden initially
            lblCountdown.Visible = false; // Add lblCountdown to your form in designer
        }

        private void PaymentScreenForm_Resize(object sender, EventArgs e)
        {
            lblCountdown.Location = new System.Drawing.Point(this.ClientSize.Width - lblCountdown.Width - 10, 10);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BookingDetailsForm bd = new BookingDetailsForm();
            bd.Show();
            this.Hide();
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbxCardName.Text) ||
                string.IsNullOrWhiteSpace(txtbxCardNumber.Text) ||
                string.IsNullOrWhiteSpace(masktbExpiryDate.Text) ||
                string.IsNullOrWhiteSpace(txtboxCVV.Text))
            {
                MessageBox.Show("Please fill in all payment details.", "Incomplete Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Payment Successful! Thank you for your reservation.",
                "Payment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);

            InsertReservation();

            // Show countdown label only after paying
            countdownSeconds = 10;
            lblCountdown.Text = $"Returning to dashboard in {countdownSeconds} seconds...";
            lblCountdown.Visible = true;
            autoCloseTimer.Start();
        }

        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--;
            lblCountdown.Text = $"Returning to dashboard in {countdownSeconds} seconds...";

            if (countdownSeconds <= 0)
            {
                autoCloseTimer.Stop();
                CloseAndOpenDashboard();
            }
        }

        private void InsertReservation()
        {
            try
            {
                var callDatabase = new CallDatabase();
                using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
                {
                    con.Open();

                    string checkQuery = @"SELECT COUNT(*) FROM Reservations
                                          WHERE RoomID = @RoomID
                                          AND CheckOut > @CheckIn
                                          AND CheckIn < @CheckOut";

                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@RoomID", RoomID);
                        checkCmd.Parameters.AddWithValue("@CheckIn", checkIn);
                        checkCmd.Parameters.AddWithValue("@CheckOut", checkOut);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("This room is already booked for the selected dates.", "Room Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insert = @"INSERT INTO Reservations 
                                      (FullName, Guest, RoomType, CheckIn, CheckOut, Rate, RoomID, UserID)
                                      VALUES (@FullName, @Guest, @RoomType, @CheckIn, @CheckOut, @Rate, @RoomID, @UserID)";

                    using (SqlCommand cmd = new SqlCommand(insert, con))
                    {
                        cmd.Parameters.AddWithValue("@FullName", FullName);
                        cmd.Parameters.AddWithValue("@Guest", Guest);
                        cmd.Parameters.AddWithValue("@RoomType", RoomType);
                        cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                        cmd.Parameters.AddWithValue("@CheckOut", checkOut);
                        cmd.Parameters.AddWithValue("@Rate", Rate);
                        cmd.Parameters.AddWithValue("@RoomID", RoomID);
                        cmd.Parameters.AddWithValue("@UserID", Session.CurrentUser?.UserID ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving reservation: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void prntReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    $"Receipt_{FullName}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

                ReceiptGenerator.CreateReceipt(FullName, RoomType, Guest, checkIn, checkOut, Rate, filePath);

                MessageBox.Show($"Receipt saved to {filePath}", "Receipt Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Stop timer and go back immediately
                autoCloseTimer.Stop();
                CloseAndOpenDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to print receipt: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseAndOpenDashboard()
        {
            _viewReservationsForm?.LoadReservations();

            if (Session.CurrentUser.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                new AdminDashboardForm().Show();
            else
                new UserDashboard().Show();

            this.Close();
        }
    }
}
