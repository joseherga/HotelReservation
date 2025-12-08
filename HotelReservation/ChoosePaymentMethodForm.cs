using System;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class ChoosePaymentMethodForm : Form
    {
        // Public fields to carry booking details into the payment forms
        public string FullName;
        public int Guest;
        public string RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;
        public decimal Rate;
        public int RoomID;

        public ChoosePaymentMethodForm()
        {
            InitializeComponent(); // Initialize UI components
        }

        private void btnCard_Click(object sender, EventArgs e)
        {
            // If user chooses Card payment, pass booking details into PaymentScreenForm
            PaymentScreenForm ps = new PaymentScreenForm
            {
                FullName = FullName,
                RoomType = RoomType,
                Guest = Guest,
                checkIn = CheckIn,   // note: property name is lowercase here
                checkOut = CheckOut, // matches PaymentScreenForm fields
                Rate = Rate,
                RoomID = RoomID
            };

            // Show card payment form as a dialog
            ps.ShowDialog();

            // Close this form after payment screen is opened
            this.Close();
        }

        private void btnGCash_Click(object sender, EventArgs e)
        {
            // If user chooses GCash payment, pass booking details into GCashPaymentForm
            GCashPaymentForm gcashForm = new GCashPaymentForm
            {
                FullName = FullName,
                RoomType = RoomType,
                Guest = Guest,
                CheckIn = CheckIn,
                CheckOut = CheckOut,
                Rate = Rate,
                RoomID = RoomID
            };

            // Show GCash payment form as a dialog
            gcashForm.ShowDialog();

            // Close this form after GCash payment screen is opened
            this.Close();
        }
    }
}