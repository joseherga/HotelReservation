namespace HotelReservation
{
    partial class UserDashboard
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
            this.btnBrowseRooms = new System.Windows.Forms.Button();
            this.btnMyReservation = new System.Windows.Forms.Button();
            this.btnBookNow = new System.Windows.Forms.Button();
            this.btnUserLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseRooms
            // 
            this.btnBrowseRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseRooms.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseRooms.Location = new System.Drawing.Point(30, 79);
            this.btnBrowseRooms.Name = "btnBrowseRooms";
            this.btnBrowseRooms.Size = new System.Drawing.Size(108, 23);
            this.btnBrowseRooms.TabIndex = 0;
            this.btnBrowseRooms.Text = "Browse Rooms";
            this.btnBrowseRooms.UseVisualStyleBackColor = true;
            this.btnBrowseRooms.Click += new System.EventHandler(this.btnBrowseRooms_Click);
            // 
            // btnMyReservation
            // 
            this.btnMyReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyReservation.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyReservation.Location = new System.Drawing.Point(33, 79);
            this.btnMyReservation.Name = "btnMyReservation";
            this.btnMyReservation.Size = new System.Drawing.Size(105, 23);
            this.btnMyReservation.TabIndex = 1;
            this.btnMyReservation.Text = "My Reservations";
            this.btnMyReservation.UseVisualStyleBackColor = true;
            // 
            // btnBookNow
            // 
            this.btnBookNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookNow.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookNow.Location = new System.Drawing.Point(34, 79);
            this.btnBookNow.Name = "btnBookNow";
            this.btnBookNow.Size = new System.Drawing.Size(95, 23);
            this.btnBookNow.TabIndex = 2;
            this.btnBookNow.Text = "Book Now";
            this.btnBookNow.UseVisualStyleBackColor = true;
            this.btnBookNow.Click += new System.EventHandler(this.btnBookNow_Click);
            // 
            // btnUserLogout
            // 
            this.btnUserLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserLogout.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserLogout.Location = new System.Drawing.Point(45, 79);
            this.btnUserLogout.Name = "btnUserLogout";
            this.btnUserLogout.Size = new System.Drawing.Size(75, 23);
            this.btnUserLogout.TabIndex = 3;
            this.btnUserLogout.Text = "Logout";
            this.btnUserLogout.UseVisualStyleBackColor = true;
            this.btnUserLogout.Click += new System.EventHandler(this.btnUserLogout_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.label1.Location = new System.Drawing.Point(286, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Byte Lodge Hotel Reservation";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnBrowseRooms);
            this.panel1.Location = new System.Drawing.Point(57, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(161, 122);
            this.panel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::HotelReservation.Properties.Resources.browseicon;
            this.pictureBox1.Location = new System.Drawing.Point(44, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MistyRose;
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.btnMyReservation);
            this.panel2.Location = new System.Drawing.Point(308, 226);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 122);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::HotelReservation.Properties.Resources.reservationicon;
            this.pictureBox2.Location = new System.Drawing.Point(44, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(73, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MistyRose;
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.btnBookNow);
            this.panel3.Location = new System.Drawing.Point(555, 226);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(161, 122);
            this.panel3.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::HotelReservation.Properties.Resources.booknow;
            this.pictureBox3.Location = new System.Drawing.Point(46, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(73, 45);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MistyRose;
            this.panel4.Controls.Add(this.pictureBox4);
            this.panel4.Controls.Add(this.btnUserLogout);
            this.panel4.Location = new System.Drawing.Point(781, 226);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(161, 122);
            this.panel4.TabIndex = 8;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::HotelReservation.Properties.Resources.logouticons;
            this.pictureBox4.Location = new System.Drawing.Point(36, 16);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(73, 45);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel5.Controls.Add(this.label1);
            this.panel5.ForeColor = System.Drawing.Color.SeaShell;
            this.panel5.Location = new System.Drawing.Point(-9, -8);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(994, 92);
            this.panel5.TabIndex = 9;
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelReservation.Properties.Resources.bytelodge__1_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "UserDashboard";
            this.Text = "UserDashboard";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseRooms;
        private System.Windows.Forms.Button btnMyReservation;
        private System.Windows.Forms.Button btnBookNow;
        private System.Windows.Forms.Button btnUserLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel5;
    }
}