using System;

namespace HotelReservation
{
    partial class PaymentScreenForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxCardName = new System.Windows.Forms.TextBox();
            this.cardName = new System.Windows.Forms.Label();
            this.cardNumber = new System.Windows.Forms.Label();
            this.txtbxCardNumber = new System.Windows.Forms.TextBox();
            this.masktbExpiryDate = new System.Windows.Forms.MaskedTextBox();
            this.expiryDate = new System.Windows.Forms.Label();
            this.CVV = new System.Windows.Forms.Label();
            this.txtboxCVV = new System.Windows.Forms.TextBox();
            this.btnPayNow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.prntReceipt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.RoomDetails = new System.Windows.Forms.GroupBox();
            this.lblRemainingBalance = new System.Windows.Forms.Label();
            this.lblDownpayment = new System.Windows.Forms.Label();
            this.lblGuests = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblTotalNights = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.RoomDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(242, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Sans Serif Collection", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 54);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payment";
            // 
            // txtbxCardName
            // 
            this.txtbxCardName.Location = new System.Drawing.Point(16, 48);
            this.txtbxCardName.Name = "txtbxCardName";
            this.txtbxCardName.Size = new System.Drawing.Size(200, 20);
            this.txtbxCardName.TabIndex = 3;
            // 
            // cardName
            // 
            this.cardName.AutoSize = true;
            this.cardName.BackColor = System.Drawing.Color.Transparent;
            this.cardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardName.ForeColor = System.Drawing.Color.Black;
            this.cardName.Location = new System.Drawing.Point(13, 29);
            this.cardName.Name = "cardName";
            this.cardName.Size = new System.Drawing.Size(158, 16);
            this.cardName.TabIndex = 4;
            this.cardName.Text = "CARDHOLDER\'S NAME:";
            // 
            // cardNumber
            // 
            this.cardNumber.AutoSize = true;
            this.cardNumber.BackColor = System.Drawing.Color.Transparent;
            this.cardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardNumber.ForeColor = System.Drawing.Color.Black;
            this.cardNumber.Location = new System.Drawing.Point(13, 85);
            this.cardNumber.Name = "cardNumber";
            this.cardNumber.Size = new System.Drawing.Size(100, 15);
            this.cardNumber.TabIndex = 5;
            this.cardNumber.Text = "CARD NUMBER:";
            // 
            // txtbxCardNumber
            // 
            this.txtbxCardNumber.Location = new System.Drawing.Point(16, 103);
            this.txtbxCardNumber.Name = "txtbxCardNumber";
            this.txtbxCardNumber.Size = new System.Drawing.Size(200, 20);
            this.txtbxCardNumber.TabIndex = 6;
            // 
            // masktbExpiryDate
            // 
            this.masktbExpiryDate.Location = new System.Drawing.Point(294, 48);
            this.masktbExpiryDate.Mask = "00/00";
            this.masktbExpiryDate.Name = "masktbExpiryDate";
            this.masktbExpiryDate.Size = new System.Drawing.Size(42, 20);
            this.masktbExpiryDate.TabIndex = 7;
            this.masktbExpiryDate.ValidatingType = typeof(System.DateTime);
            // 
            // expiryDate
            // 
            this.expiryDate.AutoSize = true;
            this.expiryDate.BackColor = System.Drawing.Color.Transparent;
            this.expiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiryDate.ForeColor = System.Drawing.Color.Black;
            this.expiryDate.Location = new System.Drawing.Point(291, 29);
            this.expiryDate.Name = "expiryDate";
            this.expiryDate.Size = new System.Drawing.Size(131, 15);
            this.expiryDate.TabIndex = 8;
            this.expiryDate.Text = "EXPIRY DATE(MM/YY)";
            // 
            // CVV
            // 
            this.CVV.AutoSize = true;
            this.CVV.BackColor = System.Drawing.Color.Transparent;
            this.CVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CVV.ForeColor = System.Drawing.Color.Black;
            this.CVV.Location = new System.Drawing.Point(291, 85);
            this.CVV.Name = "CVV";
            this.CVV.Size = new System.Drawing.Size(32, 15);
            this.CVV.TabIndex = 9;
            this.CVV.Text = "CVV:";
            // 
            // txtboxCVV
            // 
            this.txtboxCVV.Location = new System.Drawing.Point(294, 103);
            this.txtboxCVV.Name = "txtboxCVV";
            this.txtboxCVV.PasswordChar = '*';
            this.txtboxCVV.Size = new System.Drawing.Size(42, 20);
            this.txtboxCVV.TabIndex = 10;
            // 
            // btnPayNow
            // 
            this.btnPayNow.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPayNow.Location = new System.Drawing.Point(141, 163);
            this.btnPayNow.Name = "btnPayNow";
            this.btnPayNow.Size = new System.Drawing.Size(75, 23);
            this.btnPayNow.TabIndex = 11;
            this.btnPayNow.Text = "Pay Now";
            this.btnPayNow.UseVisualStyleBackColor = true;
            this.btnPayNow.Click += new System.EventHandler(this.btnPayNow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.prntReceipt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnPayNow);
            this.panel1.Controls.Add(this.expiryDate);
            this.panel1.Controls.Add(this.txtboxCVV);
            this.panel1.Controls.Add(this.CVV);
            this.panel1.Controls.Add(this.masktbExpiryDate);
            this.panel1.Controls.Add(this.txtbxCardNumber);
            this.panel1.Controls.Add(this.cardNumber);
            this.panel1.Controls.Add(this.cardName);
            this.panel1.Controls.Add(this.txtbxCardName);
            this.panel1.Location = new System.Drawing.Point(35, 417);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 232);
            this.panel1.TabIndex = 12;
            // 
            // prntReceipt
            // 
            this.prntReceipt.ForeColor = System.Drawing.Color.Black;
            this.prntReceipt.Location = new System.Drawing.Point(342, 199);
            this.prntReceipt.Name = "prntReceipt";
            this.prntReceipt.Size = new System.Drawing.Size(70, 18);
            this.prntReceipt.TabIndex = 17;
            this.prntReceipt.Text = "Print Receipt";
            this.prntReceipt.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Your payment is processed securely.";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HotelReservation.Properties.Resources.padlock;
            this.pictureBox4.Location = new System.Drawing.Point(120, 204);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(21, 13);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HotelReservation.Properties.Resources.cvv;
            this.pictureBox3.Location = new System.Drawing.Point(342, 103);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotelReservation.Properties.Resources.padlock;
            this.pictureBox2.Location = new System.Drawing.Point(342, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(13, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelReservation.Properties.Resources.visa_mastercard_logos_wh429a8o742pgm38;
            this.pictureBox1.Location = new System.Drawing.Point(221, 48);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.lblCountdown);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox5);
            this.panel2.Location = new System.Drawing.Point(-96, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1086, 48);
            this.panel2.TabIndex = 24;
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(539, 14);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(69, 15);
            this.lblCountdown.TabIndex = 26;
            this.lblCountdown.Text = "Countdown";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::HotelReservation.Properties.Resources.payment;
            this.pictureBox6.Location = new System.Drawing.Point(102, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(75, 49);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::HotelReservation.Properties.Resources.booking;
            this.pictureBox5.Location = new System.Drawing.Point(12, 14);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(37, 31);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 22;
            this.pictureBox5.TabStop = false;
            // 
            // RoomDetails
            // 
            this.RoomDetails.BackColor = System.Drawing.Color.White;
            this.RoomDetails.Controls.Add(this.lblRemainingBalance);
            this.RoomDetails.Controls.Add(this.lblDownpayment);
            this.RoomDetails.Controls.Add(this.lblGuests);
            this.RoomDetails.Controls.Add(this.lblTotalCost);
            this.RoomDetails.Controls.Add(this.lblTotalNights);
            this.RoomDetails.Controls.Add(this.lblCheckOut);
            this.RoomDetails.Controls.Add(this.lblCheckIn);
            this.RoomDetails.Controls.Add(this.lblRate);
            this.RoomDetails.Controls.Add(this.lblRoomType);
            this.RoomDetails.Controls.Add(this.lblGuestName);
            this.RoomDetails.Location = new System.Drawing.Point(24, 76);
            this.RoomDetails.Margin = new System.Windows.Forms.Padding(2);
            this.RoomDetails.Name = "RoomDetails";
            this.RoomDetails.Padding = new System.Windows.Forms.Padding(2);
            this.RoomDetails.Size = new System.Drawing.Size(934, 313);
            this.RoomDetails.TabIndex = 25;
            this.RoomDetails.TabStop = false;
            this.RoomDetails.Text = "Room Details";
            // 
            // lblRemainingBalance
            // 
            this.lblRemainingBalance.AutoSize = true;
            this.lblRemainingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingBalance.Location = new System.Drawing.Point(15, 195);
            this.lblRemainingBalance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(208, 26);
            this.lblRemainingBalance.TabIndex = 9;
            this.lblRemainingBalance.Text = "Remaining Balance:";
            // 
            // lblDownpayment
            // 
            this.lblDownpayment.AutoSize = true;
            this.lblDownpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownpayment.Location = new System.Drawing.Point(15, 154);
            this.lblDownpayment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDownpayment.Name = "lblDownpayment";
            this.lblDownpayment.Size = new System.Drawing.Size(164, 26);
            this.lblDownpayment.TabIndex = 8;
            this.lblDownpayment.Text = "Downpayment: ";
            // 
            // lblGuests
            // 
            this.lblGuests.AutoSize = true;
            this.lblGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuests.Location = new System.Drawing.Point(450, 32);
            this.lblGuests.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuests.Name = "lblGuests";
            this.lblGuests.Size = new System.Drawing.Size(207, 26);
            this.lblGuests.TabIndex = 7;
            this.lblGuests.Text = "Number of Guest/s: ";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.Location = new System.Drawing.Point(450, 195);
            this.lblTotalCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(116, 26);
            this.lblTotalCost.TabIndex = 6;
            this.lblTotalCost.Text = "Total Cost:";
            // 
            // lblTotalNights
            // 
            this.lblTotalNights.AutoSize = true;
            this.lblTotalNights.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNights.Location = new System.Drawing.Point(450, 154);
            this.lblTotalNights.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalNights.Name = "lblTotalNights";
            this.lblTotalNights.Size = new System.Drawing.Size(133, 26);
            this.lblTotalNights.TabIndex = 5;
            this.lblTotalNights.Text = "Total Nights:";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.Location = new System.Drawing.Point(450, 114);
            this.lblCheckOut.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(122, 26);
            this.lblCheckOut.TabIndex = 4;
            this.lblCheckOut.Text = "Check-Out:";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.Location = new System.Drawing.Point(450, 73);
            this.lblCheckIn.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(111, 26);
            this.lblCheckIn.TabIndex = 3;
            this.lblCheckIn.Text = "Check-In: ";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.Location = new System.Drawing.Point(15, 114);
            this.lblRate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(158, 26);
            this.lblRate.TabIndex = 2;
            this.lblRate.Text = "Rate per Night:";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(15, 73);
            this.lblRoomType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(130, 26);
            this.lblRoomType.TabIndex = 1;
            this.lblRoomType.Text = "Room Type:";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.Location = new System.Drawing.Point(15, 32);
            this.lblGuestName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(82, 26);
            this.lblGuestName.TabIndex = 0;
            this.lblGuestName.Text = "Guest: ";
            // 
            // PaymentScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelReservation.Properties.Resources.bytelodge__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.RoomDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "PaymentScreenForm";
            this.Text = "PaymentScreenForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.RoomDetails.ResumeLayout(false);
            this.RoomDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion



        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbxCardName;
        private System.Windows.Forms.Label cardName;
        private System.Windows.Forms.Label cardNumber;
        private System.Windows.Forms.TextBox txtbxCardNumber;
        private System.Windows.Forms.MaskedTextBox masktbExpiryDate;
        private System.Windows.Forms.Label expiryDate;
        private System.Windows.Forms.Label CVV;
        private System.Windows.Forms.TextBox txtboxCVV;
        private System.Windows.Forms.Button btnPayNow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.GroupBox RoomDetails;
        private System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblTotalNights;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Button prntReceipt;
        private System.Windows.Forms.Label lblGuests;
        private System.Windows.Forms.Label lblDownpayment;
        private System.Windows.Forms.Label lblRemainingBalance;
        private System.Windows.Forms.Label lblCountdown;
    }
}