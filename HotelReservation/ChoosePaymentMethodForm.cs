using System;
using System.Windows.Forms;

namespace HotelReservation
{
    public partial class ChoosePaymentMethodForm : Form
    {
        public string FullName;
        public int Guest;
        public string RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;
        public decimal Rate;
        public int RoomID;

        public ChoosePaymentMethodForm()
        {
            InitializeComponent();
        }
        private void btnCard_Click(object sender, EventArgs e)
        {
            PaymentScreenForm ps = new PaymentScreenForm
            {
                FullName = FullName,
                RoomType = RoomType,
                Guest = Guest,
                checkIn = CheckIn,
                checkOut = CheckOut,
                Rate = Rate,
                RoomID = RoomID
            };
            ps.ShowDialog();
            this.Close();
        }
        private void btnGCash_Click(object sender, EventArgs e)
        {
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
            gcashForm.ShowDialog();
            this.Close();
        }
    }
}
