using System;
using System.IO;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;

namespace HotelReservation
{
    public partial class GCashPaymentForm : Form
    {
        public string FullName;
        public int Guest;
        public string RoomType;
        public DateTime CheckIn;
        public DateTime CheckOut;
        public decimal Rate;
        public int RoomID;

        public GCashPaymentForm()
        {
            InitializeComponent();
        }

        private void GCashPaymentForm_Load(object sender, EventArgs e)
        {
            // Generate a QR code string (unique per transaction)
            string qrData = $"GCash Payment for {FullName} - {DateTime.Now:yyyyMMddHHmmss}";

            var writer = new BarcodeWriterPixelData
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Height = 200,
                    Width = 200,
                    Margin = 1
                }
            };

            var pixelData = writer.Write(qrData);

            using (var bitmap = new System.Drawing.Bitmap(pixelData.Width, pixelData.Height,
                System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                var bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, pixelData.Width, pixelData.Height),
                    System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
                try
                {
                    System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0,
                        pixelData.Pixels.Length);
                }
                finally
                {
                    bitmap.UnlockBits(bitmapData);
                }

                pictureBoxQR.Image = (System.Drawing.Image)bitmap.Clone();
            }
        }

        private void btnConfirmPayment_Click(object sender, EventArgs e)
        {
            // Simulate payment success
            MessageBox.Show("GCash Payment Successful!", "Payment Confirmed",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Generate receipt PDF
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Receipt_{FullName}_{DateTime.Now:yyyyMMddHHmmss}.pdf");

            ReceiptGenerator.CreateReceipt(FullName, RoomType, Guest, CheckIn, CheckOut, Rate, filePath);

            // Email the receipt using EmailHelper
            bool sent = EmailHelper.SendReceipt(Session.CurrentUser.Email, filePath);

            if (sent)
            {
                MessageBox.Show("Receipt emailed successfully!", "Email Sent",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
        }
    }
}
