using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class PaymentScreenForm : Form
    {
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

        private void label3_Click(object sender, EventArgs e)
        {

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
                MessageBox.Show("Please fill in all payment details.", "Incomplete Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Payment Successful! Thank you for your reservation.", "Payment Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void txtboxCVV_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
    }
}
