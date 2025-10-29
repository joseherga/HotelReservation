namespace HotelReservation
{
    partial class BookingDetailsForm
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
            this.dgRooms = new System.Windows.Forms.DataGridView();
            this.dtCheckOut = new System.Windows.Forms.DateTimePicker();
            this.dtCheckIn = new System.Windows.Forms.DateTimePicker();
            this.cbRoomType = new System.Windows.Forms.ComboBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.cbGuests = new System.Windows.Forms.ComboBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.lblCheckOut = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblContactNum = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNumOfGuests = new System.Windows.Forms.Label();
            this.btnProceed = new System.Windows.Forms.Button();
            this.lblRoomRate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxBookingInfo = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxBookingInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgRooms
            // 
            this.dgRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRooms.Location = new System.Drawing.Point(423, 77);
            this.dgRooms.Name = "dgRooms";
            this.dgRooms.Size = new System.Drawing.Size(549, 337);
            this.dgRooms.TabIndex = 0;
            // 
            // dtCheckOut
            // 
            this.dtCheckOut.Location = new System.Drawing.Point(126, 163);
            this.dtCheckOut.Name = "dtCheckOut";
            this.dtCheckOut.Size = new System.Drawing.Size(208, 20);
            this.dtCheckOut.TabIndex = 2;
            // 
            // dtCheckIn
            // 
            this.dtCheckIn.Location = new System.Drawing.Point(126, 128);
            this.dtCheckIn.Name = "dtCheckIn";
            this.dtCheckIn.Size = new System.Drawing.Size(208, 20);
            this.dtCheckIn.TabIndex = 1;
            // 
            // cbRoomType
            // 
            this.cbRoomType.FormattingEnabled = true;
            this.cbRoomType.Location = new System.Drawing.Point(126, 199);
            this.cbRoomType.Name = "cbRoomType";
            this.cbRoomType.Size = new System.Drawing.Size(208, 21);
            this.cbRoomType.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(126, 93);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(208, 20);
            this.txtPhone.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(126, 59);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(55, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "Book Here:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(270, 432);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(126, 238);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(208, 20);
            this.txtRate.TabIndex = 20;
            // 
            // cbGuests
            // 
            this.cbGuests.FormattingEnabled = true;
            this.cbGuests.Location = new System.Drawing.Point(126, 276);
            this.cbGuests.Name = "cbGuests";
            this.cbGuests.Size = new System.Drawing.Size(208, 21);
            this.cbGuests.TabIndex = 14;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckIn.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckIn.Location = new System.Drawing.Point(27, 129);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(68, 16);
            this.lblCheckIn.TabIndex = 4;
            this.lblCheckIn.Text = "CHECK IN:";
            // 
            // lblCheckOut
            // 
            this.lblCheckOut.AutoSize = true;
            this.lblCheckOut.BackColor = System.Drawing.Color.Transparent;
            this.lblCheckOut.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckOut.Location = new System.Drawing.Point(15, 163);
            this.lblCheckOut.Name = "lblCheckOut";
            this.lblCheckOut.Size = new System.Drawing.Size(81, 16);
            this.lblCheckOut.TabIndex = 5;
            this.lblCheckOut.Text = "CHECK OUT:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(126, 26);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(208, 20);
            this.txtFullName.TabIndex = 8;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomType.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(20, 199);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(83, 16);
            this.lblRoomType.TabIndex = 7;
            this.lblRoomType.Text = "ROOM TYPE:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(15, 26);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(80, 16);
            this.lblFullName.TabIndex = 9;
            this.lblFullName.Text = "FULL NAME:";
            // 
            // lblContactNum
            // 
            this.lblContactNum.AutoSize = true;
            this.lblContactNum.BackColor = System.Drawing.Color.Transparent;
            this.lblContactNum.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNum.Location = new System.Drawing.Point(15, 97);
            this.lblContactNum.Name = "lblContactNum";
            this.lblContactNum.Size = new System.Drawing.Size(88, 16);
            this.lblContactNum.TabIndex = 10;
            this.lblContactNum.Text = "CONTACT NO.";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(44, 57);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(46, 16);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "EMAIL:";
            // 
            // lblNumOfGuests
            // 
            this.lblNumOfGuests.AutoSize = true;
            this.lblNumOfGuests.BackColor = System.Drawing.Color.Transparent;
            this.lblNumOfGuests.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumOfGuests.Location = new System.Drawing.Point(6, 276);
            this.lblNumOfGuests.Name = "lblNumOfGuests";
            this.lblNumOfGuests.Size = new System.Drawing.Size(114, 16);
            this.lblNumOfGuests.TabIndex = 15;
            this.lblNumOfGuests.Text = "NO. OF GUEST(S):";
            // 
            // btnProceed
            // 
            this.btnProceed.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnProceed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProceed.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProceed.Location = new System.Drawing.Point(138, 432);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(78, 23);
            this.btnProceed.TabIndex = 19;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = false;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // lblRoomRate
            // 
            this.lblRoomRate.AutoSize = true;
            this.lblRoomRate.BackColor = System.Drawing.Color.Transparent;
            this.lblRoomRate.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomRate.Location = new System.Drawing.Point(19, 236);
            this.lblRoomRate.Name = "lblRoomRate";
            this.lblRoomRate.Size = new System.Drawing.Size(84, 16);
            this.lblRoomRate.TabIndex = 21;
            this.lblRoomRate.Text = "ROOM RATE:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelReservation.Properties.Resources.booking;
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 54);
            this.panel1.TabIndex = 23;
            // 
            // groupBoxBookingInfo
            // 
            this.groupBoxBookingInfo.Controls.Add(this.lblRoomRate);
            this.groupBoxBookingInfo.Controls.Add(this.txtRate);
            this.groupBoxBookingInfo.Controls.Add(this.lblNumOfGuests);
            this.groupBoxBookingInfo.Controls.Add(this.cbGuests);
            this.groupBoxBookingInfo.Controls.Add(this.txtEmail);
            this.groupBoxBookingInfo.Controls.Add(this.lblEmail);
            this.groupBoxBookingInfo.Controls.Add(this.txtPhone);
            this.groupBoxBookingInfo.Controls.Add(this.lblContactNum);
            this.groupBoxBookingInfo.Controls.Add(this.lblFullName);
            this.groupBoxBookingInfo.Controls.Add(this.txtFullName);
            this.groupBoxBookingInfo.Controls.Add(this.lblRoomType);
            this.groupBoxBookingInfo.Controls.Add(this.cbRoomType);
            this.groupBoxBookingInfo.Controls.Add(this.lblCheckOut);
            this.groupBoxBookingInfo.Controls.Add(this.lblCheckIn);
            this.groupBoxBookingInfo.Controls.Add(this.dtCheckOut);
            this.groupBoxBookingInfo.Controls.Add(this.dtCheckIn);
            this.groupBoxBookingInfo.Location = new System.Drawing.Point(36, 77);
            this.groupBoxBookingInfo.Name = "groupBoxBookingInfo";
            this.groupBoxBookingInfo.Size = new System.Drawing.Size(355, 337);
            this.groupBoxBookingInfo.TabIndex = 24;
            this.groupBoxBookingInfo.TabStop = false;
            this.groupBoxBookingInfo.Text = "Booking Information";
            // 
            // BookingDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelReservation.Properties.Resources.bytelodge__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.groupBoxBookingInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgRooms);
            this.Name = "BookingDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookingDetailsForm";
            this.Load += new System.EventHandler(this.BookingDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxBookingInfo.ResumeLayout(false);
            this.groupBoxBookingInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRooms;
        private System.Windows.Forms.DateTimePicker dtCheckOut;
        private System.Windows.Forms.DateTimePicker dtCheckIn;
        private System.Windows.Forms.ComboBox cbRoomType;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtRate;
        private System.Windows.Forms.ComboBox cbGuests;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.Label lblCheckOut;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblRoomType;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblContactNum;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblNumOfGuests;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Label lblRoomRate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxBookingInfo;
    }
}