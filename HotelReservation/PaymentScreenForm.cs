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

        public PaymentScreenForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            BookingDetailsForm bd = new BookingDetailsForm();
            bd.Show();
            this.Hide();
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            string cardName = txtbxCardName.Text;
            string cardNumber = txtbxCardNumber.Text;
            string expiryDate = masktbExpiryDate.Text;
            string cvv = txtboxCVV.Text;

            if (string.IsNullOrWhiteSpace(cardName) ||
                string.IsNullOrWhiteSpace(cardNumber) ||
                string.IsNullOrWhiteSpace(expiryDate) ||
                string.IsNullOrWhiteSpace(cvv))
            {
                MessageBox.Show("Please fill in all payment details.", "Incomplete Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validates card number (must be 12 digits)
            if (!System.Text.RegularExpressions.Regex.IsMatch(cardNumber, @"^\d{12}$"))
            {
                MessageBox.Show("Card number must be exactly 12 digits and contain only numbers.",
                    "Invalid Card Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validates CVV (must be 3 digits)
            if (!System.Text.RegularExpressions.Regex.IsMatch(cvv, @"^\d{3}$"))
            {
                MessageBox.Show("CVV must be exactly 3 digits and contain only numbers.",
                    "Invalid CVV", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Validate expiry date
            // Accepts MM/YY or MM/YYYY
            DateTime expDate;

            if (!DateTime.TryParse("01/" + expiryDate, out expDate))
            {
                MessageBox.Show("Invalid expiry date. Format must be MM/YY or MM/YYYY.",
                    "Invalid Expiry Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if expired
            if (expDate < DateTime.Now.AddMonths(-1))
            {
                MessageBox.Show("Card has expired. Please use a valid card.",
                    "Expired Card", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            MessageBox.Show("Payment Successful! Thank you for your reservation.",
                "Payment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RoomDetails_Load(object sender, EventArgs e)
        {
            int totalNights = (checkOut - checkIn).Days;
            decimal totalCost = totalNights * Rate;
            decimal downPayment = totalCost * 0.20m;

            lblGuestName.Text = $"Guest: {FullName}";
            lblRoomType.Text = $"Room Type: {RoomType}";
            lblGuests.Text = $"Number of Guests: {Guest}";
            lblRate.Text = $"Rate per Night: {Rate:C}";
            lblCheckIn.Text = $"Check-In: {checkIn:MMMM dd, yyyy}";
            lblCheckOut.Text = $"Check-Out: {checkOut:MMMM dd, yyyy}";
            lblTotalNights.Text = $"Total Nights: {totalNights}";
            lblDownpayment.Text = $"Downpayment (20%): {downPayment:C}";
            lblRemainingBalance.Text = $"Remaining Balance (80%): {(totalCost - downPayment):C}";
            lblTotalCost.Text = $"Total Amount: {totalCost:C}";
        }

        private void prntReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                var callDatabase = new CallDatabase();
                using (SqlConnection con = new SqlConnection(callDatabase.GetDatabasePath()))
                {
                    string insert = @"INSERT INTO Reservations 
                                     (FullName, Guest, RoomType, CheckIn, CheckOut, Rate, BookingDate)
                                     VALUES (@FullName, @Guest, @RoomType, @CheckIn, @CheckOut, @Rate, @BookingDate)";


                    using (SqlCommand cmd = new SqlCommand(insert, con))
                    {
                        int totalNights = (checkOut - checkIn).Days;
                        decimal totalAmount = totalNights * Rate;

                        cmd.Parameters.AddWithValue("@FullName", FullName);
                        cmd.Parameters.AddWithValue("@Guest", Guest);
                        cmd.Parameters.AddWithValue("@RoomType", RoomType);
                        cmd.Parameters.AddWithValue("@CheckIn", checkIn);
                        cmd.Parameters.AddWithValue("@CheckOut", checkOut);
                        cmd.Parameters.AddWithValue("@Rate", Rate);
                        cmd.Parameters.AddWithValue("@BookingDate", DateTime.Now);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                string folderPath = @"C:\Receipts";
                Directory.CreateDirectory(folderPath);
                string fileName = $"ByteLodge_Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                string filePath = Path.Combine(folderPath, fileName);
                ReceiptGenerator.CreateReceipt(FullName, RoomType, Guest, checkIn, checkOut, Rate, filePath);

                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to generate receipt or save booking: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (Session.CurrentUser.Role == "Admin")
            {
                MainMenuForm mm = new MainMenuForm();
                mm.Show();
            }
            else
            {
                UserDashboard userDash = new UserDashboard();
                userDash.Show();
            }

            this.Hide();
        }
    }
}