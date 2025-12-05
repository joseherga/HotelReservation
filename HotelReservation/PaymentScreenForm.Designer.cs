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
            this.RoomDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(323, 201);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
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
            this.label1.Location = new System.Drawing.Point(124, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 68);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payment";
            // 
            // txtbxCardName
            // 
            this.txtbxCardName.Location = new System.Drawing.Point(21, 59);
            this.txtbxCardName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbxCardName.Name = "txtbxCardName";
            this.txtbxCardName.Size = new System.Drawing.Size(265, 22);
            this.txtbxCardName.TabIndex = 3;
            // 
            // cardName
            // 
            this.cardName.AutoSize = true;
            this.cardName.BackColor = System.Drawing.Color.Transparent;
            this.cardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardName.ForeColor = System.Drawing.Color.Black;
            this.cardName.Location = new System.Drawing.Point(17, 36);
            this.cardName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cardName.Name = "cardName";
            this.cardName.Size = new System.Drawing.Size(202, 20);
            this.cardName.TabIndex = 4;
            this.cardName.Text = "CARDHOLDER\'S NAME:";
            // 
            // cardNumber
            // 
            this.cardNumber.AutoSize = true;
            this.cardNumber.BackColor = System.Drawing.Color.Transparent;
            this.cardNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardNumber.ForeColor = System.Drawing.Color.Black;
            this.cardNumber.Location = new System.Drawing.Point(17, 105);
            this.cardNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cardNumber.Name = "cardNumber";
            this.cardNumber.Size = new System.Drawing.Size(124, 18);
            this.cardNumber.TabIndex = 5;
            this.cardNumber.Text = "CARD NUMBER:";
            // 
            // txtbxCardNumber
            // 
            this.txtbxCardNumber.Location = new System.Drawing.Point(21, 127);
            this.txtbxCardNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbxCardNumber.Name = "txtbxCardNumber";
            this.txtbxCardNumber.Size = new System.Drawing.Size(265, 22);
            this.txtbxCardNumber.TabIndex = 6;
            // 
            // masktbExpiryDate
            // 
            this.masktbExpiryDate.Location = new System.Drawing.Point(392, 59);
            this.masktbExpiryDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.masktbExpiryDate.Mask = "00/00";
            this.masktbExpiryDate.Name = "masktbExpiryDate";
            this.masktbExpiryDate.Size = new System.Drawing.Size(55, 22);
            this.masktbExpiryDate.TabIndex = 7;
            this.masktbExpiryDate.ValidatingType = typeof(System.DateTime);
            // 
            // expiryDate
            // 
            this.expiryDate.AutoSize = true;
            this.expiryDate.BackColor = System.Drawing.Color.Transparent;
            this.expiryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.expiryDate.ForeColor = System.Drawing.Color.Black;
            this.expiryDate.Location = new System.Drawing.Point(388, 36);
            this.expiryDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.expiryDate.Name = "expiryDate";
            this.expiryDate.Size = new System.Drawing.Size(162, 18);
            this.expiryDate.TabIndex = 8;
            this.expiryDate.Text = "EXPIRY DATE(MM/YY)";
            // 
            // CVV
            // 
            this.CVV.AutoSize = true;
            this.CVV.BackColor = System.Drawing.Color.Transparent;
            this.CVV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CVV.ForeColor = System.Drawing.Color.Black;
            this.CVV.Location = new System.Drawing.Point(388, 105);
            this.CVV.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CVV.Name = "CVV";
            this.CVV.Size = new System.Drawing.Size(41, 18);
            this.CVV.TabIndex = 9;
            this.CVV.Text = "CVV:";
            // 
            // txtboxCVV
            // 
            this.txtboxCVV.Location = new System.Drawing.Point(392, 127);
            this.txtboxCVV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtboxCVV.Name = "txtboxCVV";
            this.txtboxCVV.PasswordChar = '*';
            this.txtboxCVV.Size = new System.Drawing.Size(55, 22);
            this.txtboxCVV.TabIndex = 10;
            // 
            // btnPayNow
            // 
            this.btnPayNow.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPayNow.Location = new System.Drawing.Point(188, 201);
            this.btnPayNow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPayNow.Name = "btnPayNow";
            this.btnPayNow.Size = new System.Drawing.Size(100, 28);
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
            this.panel1.Location = new System.Drawing.Point(47, 513);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(569, 286);
            this.panel1.TabIndex = 12;
            // 
            // prntReceipt
            // 
            this.prntReceipt.ForeColor = System.Drawing.Color.Black;
            this.prntReceipt.Location = new System.Drawing.Point(456, 245);
            this.prntReceipt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.prntReceipt.Name = "prntReceipt";
            this.prntReceipt.Size = new System.Drawing.Size(93, 22);
            this.prntReceipt.TabIndex = 17;
            this.prntReceipt.Text = "Print Receipt";
            this.prntReceipt.UseVisualStyleBackColor = true;
            this.prntReceipt.Click += new System.EventHandler(this.prntReceipt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 251);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Your payment is processed securely.";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HotelReservation.Properties.Resources.padlock;
            this.pictureBox4.Location = new System.Drawing.Point(160, 251);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(28, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HotelReservation.Properties.Resources.cvv;
            this.pictureBox3.Location = new System.Drawing.Point(456, 127);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotelReservation.Properties.Resources.padlock;
            this.pictureBox2.Location = new System.Drawing.Point(456, 59);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(17, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelReservation.Properties.Resources.visa_mastercard_logos_wh429a8o742pgm38;
            this.pictureBox1.Location = new System.Drawing.Point(295, 59);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 25);
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
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1312, 59);
            this.panel2.TabIndex = 24;
            // 
            // lblCountdown
            // 
            this.lblCountdown.AutoSize = true;
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(719, 17);
            this.lblCountdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(84, 18);
            this.lblCountdown.TabIndex = 26;
            this.lblCountdown.Text = "Countdown";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::HotelReservation.Properties.Resources.payment;
            this.pictureBox6.Location = new System.Drawing.Point(16, -1);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(100, 60);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 23;
            this.pictureBox6.TabStop = false;
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
            this.RoomDetails.Location = new System.Drawing.Point(32, 94);
            this.RoomDetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomDetails.Name = "RoomDetails";
            this.RoomDetails.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RoomDetails.Size = new System.Drawing.Size(1245, 385);
            this.RoomDetails.TabIndex = 25;
            this.RoomDetails.TabStop = false;
            this.RoomDetails.Text = "Room Details";
            // 
            // lblRemainingBalance
            // 
            this.lblRemainingBalance.AutoSize = true;
            this.lblRemainingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingBalance.Location = new System.Drawing.Point(20, 240);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(270, 32);
            this.lblRemainingBalance.TabIndex = 9;
            this.lblRemainingBalance.Text = "Remaining Balance:";
            // 
            // lblDownpayment
            // 
            this.lblDownpayment.AutoSize = true;
            this.lblDownpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownpayment.Location = new System.Drawing.Point(20, 190);
            this.lblDownpayment.Name = "lblDownpayment";
            this.lblDownpayment.Size = new System.Drawing.Size(210, 32);
            this.lblDownpayment.TabIndex = 8;
            this.lblDownpayment.Text = "Downpayment: ";
            // 
            // lblGuests
            // 
            this.lblGuests.AutoSize = true;
            this.lblGuests.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuests.Location = new System.Drawing.Point(600, 39);
            this.lblGuests.Name = "lblGuests";
            this.lblGuests.Size = new System.Drawing.Size(265, 32);
            this.lblGuests.TabIndex = 7;
            this.lblGuests.Text = "Number of Guest/s: ";
            // 
            // lblTotalCost
            // 
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCost.Location = new System.Drawing.Point(600, 240);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(151, 32);
            this.lblTotalCost.TabIndex = 6;
            this.lblTotalCost.Text = "Total Cost:";
            // 
            // lblTotalNights
            // 
            this.lblTotalNights.AutoSize = true;
            this.lblTotalNights.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalNights.Location = new System.Drawing.Point(600, 190);
            this.lblTotalNights.Name = "lblTotalNights";
            this.lblTotalNights.Size = new System.Drawing.Size(174, 32);
            this.lblTotalNights.TabIndex = 5;
            this.lblTotalNights.Text = "Total Nights:";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.Location = new System.Drawing.Point(600, 140);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(157, 32);
            this.lblCheckOut.TabIndex = 4;
            this.lblCheckOut.Text = "Check-Out:";
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.Location = new System.Drawing.Point(600, 90);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(141, 32);
            this.lblCheckIn.TabIndex = 3;
            this.lblCheckIn.Text = "Check-In: ";
            // 
            // lblRate
            // 
            this.lblRate.AutoSize = true;
            this.lblRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRate.Location = new System.Drawing.Point(20, 140);
            this.lblRate.Name = "lblRate";
            this.lblRate.Size = new System.Drawing.Size(204, 32);
            this.lblRate.TabIndex = 2;
            this.lblRate.Text = "Rate per Night:";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(20, 90);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(167, 32);
            this.lblRoomType.TabIndex = 1;
            this.lblRoomType.Text = "Room Type:";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.Location = new System.Drawing.Point(20, 39);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(105, 32);
            this.lblGuestName.TabIndex = 0;
            this.lblGuestName.Text = "Guest: ";
            // 
            // PaymentScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelReservation.Properties.Resources.bytelodge__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1312, 814);
            this.Controls.Add(this.RoomDetails);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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