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
            this.SuspendLayout();
            // 
            // btnBrowseRooms
            // 
            this.btnBrowseRooms.Location = new System.Drawing.Point(183, 132);
            this.btnBrowseRooms.Name = "btnBrowseRooms";
            this.btnBrowseRooms.Size = new System.Drawing.Size(108, 33);
            this.btnBrowseRooms.TabIndex = 0;
            this.btnBrowseRooms.Text = "Browse Rooms";
            this.btnBrowseRooms.UseVisualStyleBackColor = true;
            // 
            // btnMyReservation
            // 
            this.btnMyReservation.Location = new System.Drawing.Point(183, 228);
            this.btnMyReservation.Name = "btnMyReservation";
            this.btnMyReservation.Size = new System.Drawing.Size(101, 28);
            this.btnMyReservation.TabIndex = 1;
            this.btnMyReservation.Text = "My Reservations";
            this.btnMyReservation.UseVisualStyleBackColor = true;
            // 
            // btnBookNow
            // 
            this.btnBookNow.Location = new System.Drawing.Point(424, 137);
            this.btnBookNow.Name = "btnBookNow";
            this.btnBookNow.Size = new System.Drawing.Size(75, 23);
            this.btnBookNow.TabIndex = 2;
            this.btnBookNow.Text = "Book Now";
            this.btnBookNow.UseVisualStyleBackColor = true;
            // 
            // btnUserLogout
            // 
            this.btnUserLogout.Location = new System.Drawing.Point(424, 231);
            this.btnUserLogout.Name = "btnUserLogout";
            this.btnUserLogout.Size = new System.Drawing.Size(75, 23);
            this.btnUserLogout.TabIndex = 3;
            this.btnUserLogout.Text = "Logout";
            this.btnUserLogout.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(286, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Byte Lodge Hotel Reservation";
            // 
            // UserDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnUserLogout);
            this.Controls.Add(this.btnBookNow);
            this.Controls.Add(this.btnMyReservation);
            this.Controls.Add(this.btnBrowseRooms);
            this.Name = "UserDashboard";
            this.Text = "UserDashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseRooms;
        private System.Windows.Forms.Button btnMyReservation;
        private System.Windows.Forms.Button btnBookNow;
        private System.Windows.Forms.Button btnUserLogout;
        private System.Windows.Forms.Label label1;
    }
}