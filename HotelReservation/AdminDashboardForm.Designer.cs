namespace HotelReservation
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            this.btnSearchRooms = new System.Windows.Forms.Button();
            this.btnViewReservations = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageRooms = new System.Windows.Forms.Button();
            this.btnLogoutAdmin = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.adminMenuPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.adminAddReservation = new System.Windows.Forms.Panel();
            this.adminViewReservePanel = new ReaLTaiizor.Controls.Panel();
            this.panel1 = new ReaLTaiizor.Controls.Panel();
            this.panel2 = new ReaLTaiizor.Controls.Panel();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.adminMenuPanel.SuspendLayout();
            this.adminAddReservation.SuspendLayout();
            this.adminViewReservePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchRooms
            // 
            this.btnSearchRooms.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearchRooms.BackColor = System.Drawing.Color.AliceBlue;
            this.btnSearchRooms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSearchRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchRooms.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchRooms.Image = global::HotelReservation.Properties.Resources.add;
            this.btnSearchRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchRooms.Location = new System.Drawing.Point(-17, -14);
            this.btnSearchRooms.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearchRooms.Name = "btnSearchRooms";
            this.btnSearchRooms.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnSearchRooms.Size = new System.Drawing.Size(325, 90);
            this.btnSearchRooms.TabIndex = 0;
            this.btnSearchRooms.Text = "        ADD RESERVATION";
            this.btnSearchRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchRooms.UseVisualStyleBackColor = false;
            this.btnSearchRooms.Click += new System.EventHandler(this.btnSearchRooms_Click);
            // 
            // btnViewReservations
            // 
            this.btnViewReservations.BackColor = System.Drawing.Color.AliceBlue;
            this.btnViewReservations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReservations.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReservations.Image = ((System.Drawing.Image)(resources.GetObject("btnViewReservations.Image")));
            this.btnViewReservations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewReservations.Location = new System.Drawing.Point(-17, -14);
            this.btnViewReservations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewReservations.Name = "btnViewReservations";
            this.btnViewReservations.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnViewReservations.Size = new System.Drawing.Size(325, 90);
            this.btnViewReservations.TabIndex = 1;
            this.btnViewReservations.Text = "        VIEW RESERVATION";
            this.btnViewReservations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnViewReservations.UseVisualStyleBackColor = false;
            this.btnViewReservations.Click += new System.EventHandler(this.btnViewReservations_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.lblWelcome.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Location = new System.Drawing.Point(91, 15);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(461, 34);
            this.lblWelcome.TabIndex = 4;
            this.lblWelcome.Text = "Byte Lodge Admin Dashboard";
            // 
            // btnManageRooms
            // 
            this.btnManageRooms.BackColor = System.Drawing.Color.AliceBlue;
            this.btnManageRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageRooms.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageRooms.Image = ((System.Drawing.Image)(resources.GetObject("btnManageRooms.Image")));
            this.btnManageRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageRooms.Location = new System.Drawing.Point(-14, -17);
            this.btnManageRooms.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnManageRooms.Name = "btnManageRooms";
            this.btnManageRooms.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnManageRooms.Size = new System.Drawing.Size(325, 90);
            this.btnManageRooms.TabIndex = 1;
            this.btnManageRooms.Text = "        MANAGE ROOM";
            this.btnManageRooms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnManageRooms.UseVisualStyleBackColor = false;
            this.btnManageRooms.Click += new System.EventHandler(this.btnManageRooms_Click);
            // 
            // btnLogoutAdmin
            // 
            this.btnLogoutAdmin.BackColor = System.Drawing.Color.AliceBlue;
            this.btnLogoutAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoutAdmin.Font = new System.Drawing.Font("Segoe Fluent Icons", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogoutAdmin.Image = global::HotelReservation.Properties.Resources.logout1;
            this.btnLogoutAdmin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoutAdmin.Location = new System.Drawing.Point(-14, -17);
            this.btnLogoutAdmin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogoutAdmin.Name = "btnLogoutAdmin";
            this.btnLogoutAdmin.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.btnLogoutAdmin.Size = new System.Drawing.Size(325, 90);
            this.btnLogoutAdmin.TabIndex = 1;
            this.btnLogoutAdmin.Text = "        LOGOUT";
            this.btnLogoutAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoutAdmin.UseVisualStyleBackColor = false;
            this.btnLogoutAdmin.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.SteelBlue;
            this.panel5.Controls.Add(this.nightControlBox1);
            this.panel5.Controls.Add(this.pictureBox5);
            this.panel5.Controls.Add(this.lblWelcome);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1312, 75);
            this.panel5.TabIndex = 9;
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(1173, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 11;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::HotelReservation.Properties.Resources.adminicon;
            this.pictureBox5.Location = new System.Drawing.Point(16, 15);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(67, 49);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 5;
            this.pictureBox5.TabStop = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // adminMenuPanel
            // 
            this.adminMenuPanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.adminMenuPanel.Controls.Add(this.adminAddReservation);
            this.adminMenuPanel.Controls.Add(this.adminViewReservePanel);
            this.adminMenuPanel.Controls.Add(this.panel1);
            this.adminMenuPanel.Controls.Add(this.panel2);
            this.adminMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.adminMenuPanel.Location = new System.Drawing.Point(0, 75);
            this.adminMenuPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminMenuPanel.Name = "adminMenuPanel";
            this.adminMenuPanel.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.adminMenuPanel.Size = new System.Drawing.Size(300, 739);
            this.adminMenuPanel.TabIndex = 14;
            // 
            // adminAddReservation
            // 
            this.adminAddReservation.BackColor = System.Drawing.Color.LightSteelBlue;
            this.adminAddReservation.Controls.Add(this.btnSearchRooms);
            this.adminAddReservation.Location = new System.Drawing.Point(3, 32);
            this.adminAddReservation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminAddReservation.Name = "adminAddReservation";
            this.adminAddReservation.Padding = new System.Windows.Forms.Padding(0, 30, 0, 0);
            this.adminAddReservation.Size = new System.Drawing.Size(300, 60);
            this.adminAddReservation.TabIndex = 15;
            // 
            // adminViewReservePanel
            // 
            this.adminViewReservePanel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.adminViewReservePanel.Controls.Add(this.btnViewReservations);
            this.adminViewReservePanel.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.adminViewReservePanel.Location = new System.Drawing.Point(3, 96);
            this.adminViewReservePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.adminViewReservePanel.Name = "adminViewReservePanel";
            this.adminViewReservePanel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 0);
            this.adminViewReservePanel.Size = new System.Drawing.Size(300, 60);
            this.adminViewReservePanel.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.adminViewReservePanel.TabIndex = 15;
            this.adminViewReservePanel.Text = "panel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.Controls.Add(this.btnManageRooms);
            this.panel1.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panel1.Location = new System.Drawing.Point(3, 160);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(300, 60);
            this.panel1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel1.TabIndex = 15;
            this.panel1.Text = "panel1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.btnLogoutAdmin);
            this.panel2.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panel2.Location = new System.Drawing.Point(3, 224);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.panel2.Size = new System.Drawing.Size(300, 60);
            this.panel2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel2.TabIndex = 16;
            this.panel2.Text = "panel2";
            // 
            // AdminDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HotelReservation.Properties.Resources.bytelodge__4_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1312, 814);
            this.Controls.Add(this.adminMenuPanel);
            this.Controls.Add(this.panel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.mainMenu_Load);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.adminMenuPanel.ResumeLayout(false);
            this.adminAddReservation.ResumeLayout(false);
            this.adminViewReservePanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearchRooms;
        private System.Windows.Forms.Button btnViewReservations;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnManageRooms;
        private System.Windows.Forms.Button btnLogoutAdmin;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private System.Windows.Forms.Panel adminAddReservation;
        private System.Windows.Forms.FlowLayoutPanel adminMenuPanel;
        private ReaLTaiizor.Controls.Panel adminViewReservePanel;
        private ReaLTaiizor.Controls.Panel panel1;
        private ReaLTaiizor.Controls.Panel panel2;
    }
}